using System;
using AlgebraicAverage;
using GeometricAverage;

namespace lab03 {
  class Program {
    static void Main(string[] args) {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("Введите последовательность чисел, для которой хотите расчитать среднее алгебраическое: ");
      string algStr = Console.ReadLine();
      algStr = algStr.Replace(".", ",");
      string[] numAlgStr = algStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      Console.WriteLine("\nСреднее алгебраическое: " + AlgebraicAverage.AlgebraicAverage.AlgAverage(numAlgStr));

      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("\n###########################################\n");

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write("Введите последовательность чисел, для которой хотите расчитать среднее геометрическое: ");
      string geomStr = Console.ReadLine();
      geomStr = geomStr.Replace(".", ",");
      string[] numGeomStr = geomStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      Console.WriteLine("\nСреднее геометрическое: " + GeometricAverage.GeometricAverage.GeomAverage(numGeomStr) + "\n");
    }
  }
}