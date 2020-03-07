using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FileW {
  class FileWork {
    public static Dictionary<string, int> wordsDict = new Dictionary<string, int>();

    public static void ParseFile(string fileName) {
      var pathPart = @"C:\Users\vmaxi\Desktop\3_6sem\РПКС\labs\lab12\lab12\";
      var count = 0;
      var words = new List<string>();
      try {
        using (StreamReader sr = new StreamReader(pathPart + fileName)) {
          while (!sr.EndOfStream) {
            string strFromFile = sr.ReadLine();
            string[] wordsArr = strFromFile.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < wordsArr.Length; i++) {
              words.Add(wordsArr[i]);
            }
          }
        }
      }
      catch (FileNotFoundException e) {
        Console.WriteLine(e.Message);
      }

      var newArr = new string[words.Count];
      for (int i = 0; i < newArr.Length; i++) {
        newArr[i] = words[i];
      }

      var maxCount = 0;
      for (int i = 0; i < newArr.Length; i++) {
        count = 0;
        for (int j = 0; j < newArr.Length; j++) {
          if (newArr[i] == newArr[j]) {
            count++;
          }
        }
        if (!wordsDict.ContainsKey(newArr[i])) {
          wordsDict.Add(newArr[i], count);
        }
        if (maxCount < count) {
          maxCount = count;
        }
      }

      foreach (KeyValuePair<string, int> keyValue in wordsDict) {
        Console.WriteLine(keyValue.Key + " : " + keyValue.Value);
      }
      Console.WriteLine();

      Console.WriteLine("Слова, которые встречаются наибольшее количество раз: ");
      foreach (KeyValuePair<string, int> kvp in wordsDict.Where(f => (f.Value == maxCount))) {
        Console.WriteLine(kvp.Key);
      }

      Console.Write("Введите слово, информацию о котором хотите узнать: ");
      var yourWord = Console.ReadLine();
      if (!wordsDict.ContainsKey(yourWord)) {
        Console.WriteLine("Такого слова не найдено");
      } else {
        foreach (KeyValuePair<string, int> kvp in wordsDict.Where(f => (f.Key == yourWord))) {
          Console.WriteLine("Количество символов в слове " + kvp.Key.Length);
          Console.WriteLine("Слово " + yourWord + " повторяется в тексте " + kvp.Value);
        }
      }
    }
  }
}