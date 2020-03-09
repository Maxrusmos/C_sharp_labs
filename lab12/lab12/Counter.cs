using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FileW;

namespace CounterOp {
  public static class Counter {
    public static void DictCounter() {
      Dictionary<string, int> wordsDict = FileW.FileWork.ParseFile();

      var maxElem = wordsDict.Aggregate((x, y) => x.Value > y.Value ? x : y);
      //var maxElem1 = wordsDict.Max(kvp => kvp.Value);
      Console.WriteLine("Слова, которые встречаются наибольшее количество раз: ");
      foreach (KeyValuePair<string, int> kvp in wordsDict.Where(f => (f.Value == maxElem.Value))) {
        Console.WriteLine(kvp.Key);
      }
    }

    public static string DictSearch(string yourWord, Dictionary<string, int> wordsDict) {
      if (!wordsDict.ContainsKey(yourWord)) {
        Console.WriteLine("Такого слова не найдено");
      } else {
        foreach (KeyValuePair<string, int> kvp in wordsDict.Where(f => (f.Key == yourWord))) {
          Console.WriteLine("Количество символов в слове " + kvp.Key.Length);
          Console.WriteLine("Слово " + yourWord + " повторяется в тексте " + kvp.Value);
        }
      }
      return "";
    }
  }
}
