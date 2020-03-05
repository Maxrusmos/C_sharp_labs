using System;
using UpperWord;

namespace lab08 {
  class Program {
    static void Main(string[] args) {
      Console.Write("Введите произвольную строку: ");
      var mainStr = Console.ReadLine();
      var strArr = mainStr.Split(new char[] { ' ' , '\t' }, StringSplitOptions.RemoveEmptyEntries);
      var newStrArr = strArr;

      if (mainStr.Length == 0) {
        Console.WriteLine("Вы ничего не ввели");
        Environment.Exit(1);
      }

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Исходная строка: " + mainStr);
      Console.Write("Введите слово: ");
      var word = Console.ReadLine();
      var wordsCount = default(int);

      try {
        wordsCount = SearchNeedWord.SearchNeedWord.SearchWord(strArr, word);
        Console.WriteLine("Количество таких слов в строке: " + wordsCount);
      }
      catch (ArgumentNullException ex) {
        Console.WriteLine(ex.Message);
      }
      catch (ArgumentException ex) {
        Console.WriteLine(ex.Message);
      }

      Console.Write("Введите слово, на которое хотите поменять предпоследнее слово в строке: ");
      var changeWord = Console.ReadLine();
      try {
        SearchNeedWord.SearchNeedWord.Change(strArr, changeWord);
        Console.Write("Измененная строка: ");
        for (int i = 0; i < newStrArr.Length; i++) {
          Console.Write(newStrArr[i] + " ");
        }
      }
      catch (ArgumentNullException ex) {
        Console.WriteLine(ex.Message);
      }
      catch (ArgumentException ex) {
        Console.WriteLine(ex.Message);
      }

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine();
      Console.Write("Введите k: ");
      var kWord = Console.ReadLine();

      try {
        var str = UpperWord.UpperWord.SeachKUpper(kWord, strArr);
        Console.WriteLine("Слово с заглавной буквы под номером " + kWord + ": " + str);
      }
      catch (ArgumentException ex) {    
        Console.WriteLine(ex.Message);
      }
      Console.Read();
    }
  }
}
