using System;
using System.Collections.Generic;
using System.Text;

namespace UpperWord {
  public static class UpperWord {
    public static string SeachKUpper(string kStr, string[]strArr) {
      int k = int.Parse(kStr);

      var counter = 0;
      for (int i = 0; i < strArr.Length; i++) {
        if (strArr[i][0] == strArr[i].ToUpper()[0]) {
          counter++;
        }
      }

      if (k > counter) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("В строке нет столько слов начинающихся с заглавной буквы.");
        System.Environment.Exit(2);
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
