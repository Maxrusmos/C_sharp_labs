using System;
using System.Collections.Generic;
using System.Text;

namespace SearchNeedWord {
  public class SearchNeedWord {
    public static void SearchWord(string[] strArr, string word, out string[] newStrArr, out int counter) {
      counter = 0;
      newStrArr = strArr;

      for (int i = 0; i < strArr.Length; i++) {
        if (strArr[i] == word) {
          counter++;
        }
      }
      if (counter != 0) {
        newStrArr[strArr.Length - 2] = word;
      }
    }
  }
}
