using System;
using CExeption;

namespace CorrectOp {
  class CorrectEnter {
    public static int CorrectParsePower(string power) {
      if (!int.TryParse(power, out int number) || int.Parse(power) < 1) {
        throw new CustomException("Максимальная степень введена некорректно" + Environment.NewLine);
      } else return number;
    }

    public static void CorrectParseKoef(string[] koefArr) {
      foreach (string str in koefArr) {
        if (!double.TryParse(str, out double number)) {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Какой-то из коэффициентов не является числом" + Environment.NewLine);
          Environment.Exit(1);
        }
      }
    }

    public static double CorrectParseDot(string dot) {
      if (!double.TryParse(dot, out double number)) {
        throw new CustomException("Точка введена некорректно" + Environment.NewLine);
      } else return number;
    }
  }
}
