using System;
using System.Numerics;
using System.Linq;
using Cardano;
using VietaCordano;

//РЕШЕНИЕ КУБИЧЕСКИХ УРАВНЕНИЙ 
namespace lab01 {
  class Program {
    static void Main(string[] args) {
      double[] values = new double[4];
    
      if (args.Select((value, index) => double.TryParse(args[index], out values[index])).Any(parseResult => !parseResult)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Какой-либо из аргументов не является числом");
        System.Environment.Exit(1);
      }

      if (args.Length != 4) {
        Console.WriteLine("Переданны не все аргументы");
        System.Environment.Exit(2);
      } 

      if (values[0] == 0.0) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Уравнение не является кубическим");
        System.Environment.Exit(3);
      }
 
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("Ваше уравнение: ");
      Console.WriteLine("(" + values[0] + ")" + "x^3 + " + "(" + values[1] + ")" + "*x^2 + " + "(" + values[2] + ")" + "*x + " + "(" + values[3] + ")" + " = 0\n");
      
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Метод Кардано");

      Complex[] result = Cardano.Cardano.CordanoMethod(values[0], values[1], values[2], values[3]);
      for (int i = 0; i < 3; i++) {
        Console.WriteLine("x" + (i+1) + " = " + result[i]);
      }

      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("\n###########################################\n");
      Console.ForegroundColor = ConsoleColor.Cyan;

      Console.WriteLine("Метод Виета-Кардано");
      Complex[] result1 = VietaCordano.VietaCordano.VietaCordanoMethod(values[0], values[1], values[2], values[3]);
      for (int i = 0; i < 3; i++) {
        Console.WriteLine("x" + (i+1) + " = " + result1[i]);
      }
    }
  }
}
