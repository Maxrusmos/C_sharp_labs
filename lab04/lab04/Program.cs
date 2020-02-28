using System;
using System.Linq;
using ToNumberSystem;

namespace lab04 {
  class Program {
    static void Main(string[] args) {
      int[] values = new int[2];

      if (args.Select((value, index) => int.TryParse(args[index], out values[index])).Any(parseResult => !parseResult)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Какой-либо из аргументов не является числом");
        System.Environment.Exit(1);
      }

      if (values[1] < 2 || values[1] > 36) {
        Console.WriteLine("Введена некорректная система счисления");
        System.Environment.Exit(2);
      }
      Console.WriteLine(ToNumberSystem.ToNumberSystem.ToNS(values[0], values[1]));
    }
  }
}
