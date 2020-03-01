using System;

namespace CorrectEnter {
  public static class CorrectEnter {
    public static void CorrectEnterNum(string wholePart, string fractionalPart) {
      if (!int.TryParse(wholePart, out int number1)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Целая часть не является числом.");
        System.Environment.Exit(1);
      }

      if (!double.TryParse(fractionalPart, out double number2)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Дробная часть не является числом.");
        System.Environment.Exit(1);
      }
    }

    public static void CorrectEnterBase(string numBase) {
      if (!int.TryParse(numBase, out int number)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Система счисления не является числом.");
        System.Environment.Exit(1);
      }

      if (int.Parse(numBase) < 2 || int.Parse(numBase) > 36) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Система счисления является некорректной.");
        System.Environment.Exit(2);
      }
    }

    public static void CorrectEnterFile(string num) {
      if (!double.TryParse(num, out double number1)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Число в файле является некорректным.");
        System.Environment.Exit(3);
      }
    }
  }
}
