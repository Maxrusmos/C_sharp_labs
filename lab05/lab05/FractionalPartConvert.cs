using System;
using System.Collections.Generic;
using System.Linq;
using WholePartConvert;

namespace FractionalPartConvert {
  public static class FractionalPartConvert {
    private static string SearchPeriod(string fractionalPart) {
      Dictionary<char, int> periodDict = new Dictionary<char, int>();
      var periodCount = 0;
      var count = 0;
      var period = "";

      for (int i = 0; i < fractionalPart.Length; i++) {
        for (int j = 0; j < fractionalPart.Length; j++) {
          if (fractionalPart[i] == fractionalPart[j])
            count++;
        }

        if (!periodDict.ContainsKey(fractionalPart[i])) {
          periodDict.Add(fractionalPart[i], count);
        }

        if (periodCount < count) {
          periodCount = count;
        }
        count = 0;
      }

      var notPeriod = "";
      foreach (KeyValuePair<char, int> kvp in periodDict.Where(f => f.Value < (-periodCount / 2.0) - periodCount)) {
        Console.WriteLine(kvp.Key + " : " + kvp.Value);
        notPeriod = notPeriod + kvp.Key;
      }

      foreach (KeyValuePair<char, int> kvp in periodDict.Where(f => (f.Value == periodCount) || (f.Value == periodCount - 1))) {
        Console.WriteLine(kvp.Key + " : " + kvp.Value);
        period = period + kvp.Key;
      }
      Console.WriteLine(notPeriod + "(" + period + ")");
      return notPeriod + "(" + period + ")";
    }

    public static string FToNS(double fractionalNumber, int numBase) {
      var tmpNum = 1.0;
      var result = "";

      int discharge = 0;
      while (discharge != 100) {
        tmpNum = fractionalNumber * numBase;
        result = result + WholePartConvert.WholePartConvert.correct(int.Parse(Convert.ToString(tmpNum).Split(',')[0]));
        if (Convert.ToString(tmpNum).Split(',').Length == 1) {
          break;
        } else {
          fractionalNumber = double.Parse("0," + Convert.ToString(tmpNum).Split(',')[1]);
        }
        discharge++;
      }
      SearchPeriod(result);
      return result;
    }
  }
}
