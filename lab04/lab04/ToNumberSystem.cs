using System;

namespace ToNumberSystem {
  public class ToNumberSystem {
    private static string correct(int remains) {
      string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                           "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
      string remainStr = "";
      string result = "";

      if (remains > 9) {
        remainStr = remains.ToString();
        remainStr = letters[int.Parse(remainStr) - 10];
        result = remainStr + result;
      } else {
        result = Convert.ToString(remains) + result;
      }
      return result;
    }

    public static string ToNS(int number, int numBase) {
      var ourNum = number;
      string result = "";
      int remains = 0;

      if (number > 0) {
        while (number / numBase != 0) {
          remains = number % numBase;
          result = correct(remains) + result;
          number = number / numBase;
        }
        result = Convert.ToString(correct(number % numBase)) + result;
      }

      result = "Число " + ourNum + " в " + numBase + "-й системе = " + result;
      return result;
    }
  }
}
