using System;
using System.Collections.Generic;
using System.Text;

namespace UpperWord {
  public static class UpperWord {
    public static string SeachKUpper(string kStr, string[]strArr) {
      if (!int.TryParse(kStr, out int number)) {
        throw new ArgumentException("k не число", nameof(kStr));
      }

      int k = int.Parse(kStr);
      var counter = 0;
      for (int i = 0; i < strArr.Length; i++) {
        if (strArr[i][0] == strArr[i].ToUpper()[0]) {
          counter++;
        }
      }

      if (k > counter) {
        throw new ArgumentException("В строке нет столько слов начинающихся с больших букв", nameof(strArr));
      }
      if (k < 0) {
        throw new ArgumentException("K не может быть отрицательным", nameof(k));
      }

      string[] strArrUpper = new string[counter + 1];

      counter = 0;
      for (int i = 0; i < strArr.Length; i++) {
        if (strArr[i][0] == strArr[i].ToUpper()[0]) {
          strArrUpper[counter] = strArr[i];
          counter++;
        }
      }
      return strArrUpper[k - 1];
    }
  }
}
