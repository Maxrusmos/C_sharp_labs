using System;

namespace GeometricAverage {
  public class GeometricAverage {

    private const double Eps = 1e-14;

    public static double GeomAverage(string[] numStr) {
      if (numStr.Length == 0) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Вы ничего не ввели.");
        System.Environment.Exit(1);
      }

      double[] Arr = new double[numStr.Length];

      for (int i = 0; i < numStr.Length; i++) {
        if (!double.TryParse(numStr[i], out double number)) {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Какой-либо из аргументов не является числом");
          System.Environment.Exit(2);
        }
      }

      for (int i = 0; i < numStr.Length; i++) {
        Arr[i] = Convert.ToDouble(numStr[i]);
      }
      
      var composition = 1.0;
      for (int i = 0; i < Arr.Length; i++) {
        composition *= Arr[i];
      }

      if (composition < Eps) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Геометрическое среднее может быть найдено тогда, и только тогда, если выборка состоит из положительных чисел.");
        System.Environment.Exit(3);
      }

      return Math.Pow(composition, 1.0 / Arr.Length);
    }
  }
}