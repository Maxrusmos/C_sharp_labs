using System;
using AlphabeticalOrder;

namespace lab06 {
  class Program {
    static void Main(string[] args) {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("Введите слова, которые хотите отсортировать по алфавитному порядку: ");
      var mainStr = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

      var AlphabeticalOrderStr = "";
      var lastLetterStr = "";

      AlphabeticalOrder.AlphabeticalOrder.SortAlphabeticalOrder(mainStr, out AlphabeticalOrderStr, out lastLetterStr);

      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write("Слова в алфавитном порядке: " + AlphabeticalOrderStr);
      Console.WriteLine("\n");
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write("Слово из последних символов: " + lastLetterStr);
      Console.WriteLine("\n");
    }
  }
}
