using System;
using MatrixOp;
using CExeption;

namespace lab10 {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Введите размерность матрицы: ");
      var nn = Console.ReadLine();
      if (!int.TryParse(nn, out int number)) {
        Console.ForegroundColor = ConsoleColor.Red;
        throw new CustomException("Размерность матриц не является числом " + Environment.NewLine);
      }

      int n = Convert.ToInt32(nn);

      // Инициализация
      Matrix matrixA = new Matrix(n);
      Matrix matrixB = new Matrix(n);
      Matrix mass3 = new Matrix(n);
      Matrix mass4 = new Matrix(n);
      Matrix mass5 = new Matrix(n);
      Matrix mass6 = new Matrix(n);
      Matrix mass7 = new Matrix(n);
      Matrix mass8 = new Matrix(n);

      Console.WriteLine("Ввод первой матрицы (A)");
      matrixA.WriteMatrix();
      Console.WriteLine("Ввод второй матрицы (B)");
      matrixB.WriteMatrix();

      Console.WriteLine("Матрица А: ");
      matrixA.ReadMatrix();
      Console.WriteLine();
      Console.WriteLine("Матрица В: ");
      Console.WriteLine();
      matrixB.ReadMatrix();

      Console.WriteLine("Транспонированная матрица A");
      mass7 = Matrix.transpositionMatrix(matrixA);
      mass7.ReadMatrix();

      foreach (var kek in mass7) {
        Console.WriteLine(kek);
      } 
    }
  }
}
