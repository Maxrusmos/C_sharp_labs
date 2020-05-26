using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roma {
  class sknfSdnfFromFile {
    public static StringBuilder Builder() {
      var expr = "";
      var buildFormulas = new StringBuilder();

      System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\vmaxi\Desktop\3_6sem\РПКС\ff.txt");
      while ((expr = file.ReadLine()) != null) {
        var rpn = Calc.GetRPN(expr).ToArray();
        Console.WriteLine(rpn);

        LinkedList<String> sdnf = new LinkedList<string>();
        LinkedList<String> sknf = new LinkedList<string>();

        var varValues = new Dictionary<char, int>();
        var headerShown = false;

        foreach (var combination in Calc.GetAllCombinations(Calc.GetVariables(expr), 0, varValues)) {
          var res = Calc.Calculate(rpn, varValues);
          string str = "";

          if (res) {
            foreach (var val in varValues) {
              if (val.Value == 0) str += "!" + val.Key + " + ";

              else str += val.Key + " + ";
            }
            if (str.EndsWith("")) {
              str = str.Substring(0, str.Length - 3);
            }
            sdnf.AddLast(str);
          } else {
            foreach (var val in varValues) {
              if (val.Value == 1) str += "!" + val.Key + " * ";

              else str += val.Key + " * ";
            }
            if (str.EndsWith("")) {
              str = str.Substring(0, str.Length - 3);
            }
            sknf.AddLast(str);
          }

          if (!headerShown) {
            foreach (var var in varValues.Keys)
              buildFormulas.Append(var + "\t");
            buildFormulas.Append(expr + Environment.NewLine);
            headerShown = true;
          }

          foreach (var var in varValues.Values)
            buildFormulas.Append(var + "\t");
          if (res)
            buildFormulas.Append('1' + Environment.NewLine);
          else
            buildFormulas.Append('0' + Environment.NewLine);
        }

        buildFormulas.Append("sdnf: " + Environment.NewLine);
        uint cnt = 0;
        foreach (var val in sdnf) {
          if (cnt++ == 0)
            buildFormulas.Append("(" + val + ")");
          else {
            buildFormulas.Append(" + (" + val + ")");
          }
        }
        buildFormulas.Append(" = 1");

        buildFormulas.Append(Environment.NewLine);

        buildFormulas.Append("sknf: " + Environment.NewLine);
        cnt = 0;
        foreach (var val in sknf) {
          if (cnt++ == 0)
            buildFormulas.Append("(" + val + ")");
          else {
            buildFormulas.Append(" * (" + val + ")");
          }
        }
        buildFormulas.Append(" = 0\n\n");
      }
      file.Close();
      return buildFormulas;
    }
  }
}
