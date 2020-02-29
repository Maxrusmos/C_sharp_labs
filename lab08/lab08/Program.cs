using System;
using SearchNeedWord;
using UpperWord;

namespace lab08 {
  class Program {
    static void Main(string[] args) {
      var mainStr = "lol Kek Lol kek chebureck Lol kek kek Chebureck lol g chebureck Lol LOL Kek";
      var tmpArr = mainStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      var strArr = mainStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      var newStrArr = strArr;
      var counter = 0;

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Исходная строка: " + mainStr);
      Console.Write("Введите слово: ");
      string word = Console.ReadLine();
      SearchNeedWord.SearchNeedWord.SearchWord(strArr, word, out newStrArr, out counter);

      if (counter == 0) {
        Console.WriteLine("В строке нет введенного слова.");
      } else {
        Console.WriteLine("Количество таких слов в строке: " + counter);
        Console.Write("Измененная строка: ");
        for (int i = 0; i < newStrArr.Length; i++) {
          Console.Write(newStrArr[i] + " ");
        }
      }

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine();
      Console.Write("Введите k: ");
      var kWord = Console.ReadLine();

      if (!int.TryParse(kWord, out int number)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("k не является числом");
        System.Environment.Exit(1);
      }
      Console.WriteLine("Слово с заглавной буквы под номером " + kWord + ": " + UpperWord.UpperWord.SeachKUpper(kWord, tmpArr)); 
    }
  }
}
