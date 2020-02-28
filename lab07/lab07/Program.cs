using System;
using System.Text;
using StrSort;

namespace lab07 {
  class Program {
    static void Main(string[] args) {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("Введите строку: ");
      var str = Console.ReadLine();
      var strBuild = new StringBuilder(str);

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Отсортированная строка: " + StrSort.StrSort.AscendingOrder(strBuild) + "/n");      
    }
  }
}
