using System;
using MatrixOp;
using CExeption;

namespace lab10 {
  class Program {
    static void Main(string[] args) {
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.Write("Введите размерность матрицы A: ");
      var nA = Console.ReadLine();

      if (!int.TryParse(nA, out int number)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Размерность не является числом");
        Environment.Exit(1);
      }

      int n1 = Convert.ToInt32(nA);
      if (n1< 0) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Размерность не может быть отрицательной");
        Environment.Exit(2);
      }
      Console.WriteLine();

      Matrix matrixA = new Matrix(n1);
      Matrix matrixResult = new Matrix(n1);

      Console.WriteLine("Ввод первой матрицы (A)");
      try {
        matrixA.WriteMatrix();
      }
      catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }
      Console.WriteLine();

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write("Введите размерность матрицы B: ");
      var nB = Console.ReadLine();
      if (!int.TryParse(nB, out int number1)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Размерность не является числом");
        Environment.Exit(2);
      }

      int n2 = Convert.ToInt32(nB);
      Matrix matrixB = new Matrix(n2);

      Console.WriteLine("Ввод второй матрицы (B)");
      try {
        matrixB.WriteMatrix();
      }
      catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }
      Console.WriteLine();

      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("Матрица А: ");
      Console.WriteLine(matrixA.ToString()); 

      Console.WriteLine("Транспонированная матрица A:");
      matrixResult = Matrix.TranspositionMatrix(matrixA);
      Console.WriteLine(matrixResult.ToString()); 
      Console.WriteLine();

      Console.WriteLine("Определитель матрицы A:");
      Console.WriteLine(Matrix.DeterminantMatrix(matrixA));
      Console.WriteLine();

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Матрица В: ");
      Console.WriteLine(matrixB.ToString());

      Console.WriteLine("Транспонированная матрица B:");
      matrixResult = Matrix.TranspositionMatrix(matrixB);
      Console.WriteLine(matrixResult.ToString());

      Console.WriteLine("Определитель матрицы B:");
      Console.WriteLine(Matrix.DeterminantMatrix(matrixB));
      Console.WriteLine();

      Console.ForegroundColor = ConsoleColor.Yellow;
      try {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Сумма матриц A и B:");
        matrixResult = Matrix.SumMatrix(matrixA, matrixB);      
        Console.WriteLine(matrixResult.ToString());
      }
      catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }

      try {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Умножение матрицы A на матрицу B:");
        matrixResult = Matrix.CompositionMatrix(matrixA, matrixB);
        Console.WriteLine(matrixResult.ToString());
      }
      catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }

      Console.WriteLine("Деление матрицы A на матрицу B:");
      try {
        Console.ForegroundColor = ConsoleColor.Yellow;
        matrixResult = Matrix.DivisionMatrix(matrixA, matrixB);
        Console.WriteLine(matrixResult.ToString());
      }
      catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }
      Console.WriteLine();
    }
  }
}
