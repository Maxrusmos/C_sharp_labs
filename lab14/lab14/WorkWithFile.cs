using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MVVM {
  public class WorkWithFile {
    public static string PreparingToWriteToFile(string formula, StringBuilder resultText, int counter) {
      resultText.Append(counter + ") ");
      List<Token> rpn = Arithmetic.ReversePolishNotation(formula);
      foreach (var token in rpn) {
        resultText.Append(token.Value);
      }
      resultText.Append(Environment.NewLine);
      Dictionary<string, bool> variables = Arithmetic.GetVariables(rpn);
      var arrTable = Arithmetic.TruthTable(rpn, variables);
      for (int i = 0; i < (int)Math.Pow(2, variables.Count); i++) {
        for (int j = 0; j < variables.Count + 1; j++) {
          resultText.Append(arrTable[i, j]);
        }
        resultText.Append(Environment.NewLine);
      }
      resultText.Append(Arithmetic.Sknf(arrTable, variables, rpn) + Environment.NewLine
        + Arithmetic.Sdnf(arrTable, variables, rpn) + Environment.NewLine);
      resultText.Append("-----------------------------------------------------------------------" + Environment.NewLine);
      return resultText.ToString();
    }

    public static async Task WriteToFile(string resultText) {
      SaveFileDialog dlg = new SaveFileDialog();
      dlg.FileName = "result";
      dlg.DefaultExt = ".txt"; 
      dlg.Filter = "Text documents (.txt)|*.txt";
      var result = dlg.ShowDialog();
      if (result == true) {
        using (FileStream fstream = new FileStream(dlg.FileName, FileMode.OpenOrCreate)) {
          byte[] array = System.Text.Encoding.Default.GetBytes(resultText);
          await fstream.WriteAsync(array, 0, array.Length);
        }
      }
    }
  }
}
