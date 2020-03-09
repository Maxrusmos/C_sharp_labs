using System;
using MatrixOp;
using CExeption;

namespace lab10 {
  class Program {
    static void Main(string[] args) {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("Введите размерность матрицы: ");
      var nn = Console.ReadLine();

      if (!int.TryParse(nn, out int number)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Размерность не является числом");
        Environment.Exit(1);
      }

      int n = Convert.ToInt32(nn);
      if (n < 0) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Размерность не может быть отрицательной");
        Environment.Exit(2);
      }
      Console.WriteLine();

      Matrix matrixA = new Matrix(n);
      Matrix matrixB = new Matrix(n);
      Matrix matrixResult = new Matrix(n);

      Console.ForegroundColor = ConsoleColor.Magenta;
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
      matrixA.ReadMatrix();
      Console.WriteLine();

      Console.WriteLine("Транспонированная матрица A:");
      matrixResult = Matrix.TranspositionMatrix(matrixA);
      matrixResult.ReadMatrix();
      Console.WriteLine();

      Console.WriteLine("Определитель матрицы A:");
      Console.WriteLine(Matrix.DeterminantMatrix(matrixA));
      Console.WriteLine();

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Матрица В: ");
      matrixB.ReadMatrix();
      Console.WriteLine();

      Console.WriteLine("Транспонированная матрица B:");
      matrixResult = Matrix.TranspositionMatrix(matrixB);
      matrixResult.ReadMatrix();
      Console.WriteLine();

      Console.WriteLine("Определитель матрицы B:");
      Console.WriteLine(Matrix.DeterminantMatrix(matrixB));
      Console.WriteLine();

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Сумма матриц A и B:");
      matrixResult = Matrix.SumMatrix(matrixA, matrixB);
      matrixResult.ReadMatrix();
      Console.WriteLine();

      Console.WriteLine("Умножение матрицы A на матрицу B:");
      matrixResult = Matrix.CompositionMatrix(matrixA, matrixB);
      matrixResult.ReadMatrix();
      Console.WriteLine();

      Console.WriteLine("Деление матрицы A на матрицу B:");
      try {
        matrixResult = Matrix.DivisionMatrix(matrixA, matrixB);
        matrixResult.ReadMatrix();
      }
      catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }
      Console.WriteLine();

      //Console.ForegroundColor = ConsoleColor.Yellow;
      //Console.WriteLine("Проверка конструкторов");
      //try {
      //  Matrix A = new Matrix(2, 1, 2, 3);
      //  A.ReadMatrix();
      //}
      //catch(CustomException ex) {
      //  Console.ForegroundColor = ConsoleColor.Red;
      //  Console.WriteLine(ex.Message);
      //}
      //Console.WriteLine();
    }
  }
}
