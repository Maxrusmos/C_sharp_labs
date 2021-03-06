﻿using System;
using Dichotomy;

namespace lab09 {
  class Program {
    static void Main(string[] args) {
      Dichotomy.Dichotomy.delegateEquation GetEq = new Dichotomy.Dichotomy.delegateEquation(Dichotomy.Dichotomy.EquationGet);
      Console.WriteLine("Введите границы интервала.");
      Console.Write("Введите нижнюю границу: ");
      var lowerBorder = Console.ReadLine();

      if (!double.TryParse(lowerBorder, out double number1)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Нижняя граница не является числом");
        Environment.Exit(1);
      }

      Console.Write("Введите верхнюю границу: ");
      var upperBorder = Console.ReadLine();

      if (!double.TryParse(lowerBorder, out double number2)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Верхняя граница не является числом");
        Environment.Exit(2);
      }

      if (double.Parse(lowerBorder) > double.Parse(upperBorder)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Верхняя граница оказалась больше чем нижняя");
        Environment.Exit(3);
      }

      Console.Write("Введите точность: ");
      var accuracy = Console.ReadLine();

      if (!double.TryParse(accuracy, out double number3)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Введенная точность не является числом");
        Environment.Exit(4);
      }

      Console.WriteLine(Dichotomy.Dichotomy.DichotomySolve(double.Parse(lowerBorder),
        double.Parse(upperBorder), GetEq, double.Parse(accuracy)));
    }
  }
}