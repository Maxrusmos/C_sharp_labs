using System;

namespace AlphabeticalOrder {
  public class AlphabeticalOrder {
    public static void SortAlphabeticalOrder(string[] mainStr, out string AlphabeticalOrderStr, out string lastLetterStr) {
      lastLetterStr = "";
      AlphabeticalOrderStr = "";
      for (int i = 0; i < mainStr.Length - 1; i++) {
        for (int j = 0; j < mainStr.Length - i - 1; j++) {
          if (mainStr[j + 1].CompareTo(mainStr[j]) < 0) {
            var temp = mainStr[j + 1];
            mainStr[j + 1] = mainStr[j];
            mainStr[j] = temp;
          }
        }
      }

      foreach (string str in mainStr) {
        lastLetterStr = lastLetterStr + str[str.Length - 1];
        AlphabeticalOrderStr = AlphabeticalOrderStr + str + " ";
      }
    }
  }
}
