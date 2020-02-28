using System;
using System.Linq;

namespace lab04 {
  class Program {
    static void Main(string[] args) {
      int[] values = new int[2];

      if (args.Select((value, index) => int.TryParse(args[index], out values[index])).Any(parseResult => !parseResult)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Какой-либо из аргументов не является числом");
        System.Environment.Exit(1);
      }

      string result = ""; 
      int temp = 0;
      int number = values[0];

      if (values[0] > 0) {
        while (values[0] >= (values[1] - 1)) {
          temp = values[0] % values[1];
          values[0] = (values[0] - temp) / values[1];
          result = Convert.ToString(temp) + result;
        }
      }
      Console.WriteLine(Convert.ToString(number, values[1]));

      result = Convert.ToString(values[0]) + result;
      Console.WriteLine("Число " + number +  " в " + values[1] + "-й системе = " + result);
    }
  }
}
