using System;
using System.Linq;

namespace SearchNeedWord {
  public class SearchNeedWord {
    public static int SearchWord(string[] strArr, string word) {
      return strArr.Count(str => str.Equals(word));
    }

    public static void Change(string[] strArr, string word) {
      if (strArr is null) {
        throw new ArgumentNullException("Strings array is null.", nameof(strArr));
      }
      if (strArr.Length < 2) {
        throw new ArgumentException("Strings array length is lower than 2");
      }
      strArr[strArr.Length - 2] = word;
    }
  }
}
