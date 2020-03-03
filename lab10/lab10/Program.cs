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
        throw new CustomException("Размерность матриц не является числом " + Environment.NewLine);
      }

      int n = Convert.ToInt32(nn);
      Console.WriteLine();
      Matrix matrixA = new Matrix(n);
      Matrix matrixB = new Matrix(n);
      Matrix matrixResult = new Matrix(n);

      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("Ввод первой матрицы (A)");
      matrixA.WriteMatrix();
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Ввод второй матрицы (B)");
      matrixB.WriteMatrix();
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
      if (Matrix.DeterminantMatrix(matrixB) == 0) {
        Console.ForegroundColor = ConsoleColor.Red;
        throw new CustomException("Определитель матрицы B равен нулю. Матрица вырожденная" + Environment.NewLine);
      }
      matrixResult = Matrix.CompositionMatrix(matrixA, matrixB);
      matrixResult.ReadMatrix();
      Console.WriteLine();
    }
  }
}
