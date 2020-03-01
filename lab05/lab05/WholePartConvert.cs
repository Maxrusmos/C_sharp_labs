using System;

namespace WholePartConvert {
  public static class WholePartConvert {
    public static string correct(int remains) {
      string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                           "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
      var remainStr = "";
      var result = "";

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
      var result = "";
      int remains = 0;

      if (number >= 0) {
        while (number / numBase != 0) {
          remains = number % numBase;
          result = correct(remains) + result;
          number = number / numBase;
        }
        result = Convert.ToString(correct(number % numBase)) + result;
      }

      return result;
    }
  }
}
