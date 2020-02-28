using System;

namespace AlgebraicAverage {
  public class AlgebraicAverage {
    public static double AlgAverage(string[] numStr) {
      if (numStr.Length == 0) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Вы ничего не ввели.");
        System.Environment.Exit(1);
      } 

      double[] Arr = new double[numStr.Length];
      var flag = false;

      for (int i = 0; i < numStr.Length; i++) {
        int charSum = 0;
        if (!double.TryParse(numStr[i], out double number)) {
          flag = true;
          if (numStr[i].Length > 1) {
            for (int j = 0; j < numStr[i].Length; j++) {
              charSum += numStr[i][j];
            }
            Arr[i] = charSum;
          } else {
            foreach (char c in numStr[i]) {
              Arr[i] = c;
            }
          }
        } else {
          Arr[i] = Convert.ToDouble(numStr[i]);
        }
      }

      if (flag) {
        Console.Write("Ваша последовательность преобрела вид: ");
        for (int i = 0; i < Arr.Length; i++) {
          Console.Write(Arr[i] + " ");
        }
      }

      var Sum = 0.0;
      for (int i = 0; i < Arr.Length; i++) {
        Sum += Arr[i];
      }
      
      return Sum / Arr.Length; ;
    }
  }
}