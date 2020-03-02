using System;
using lab10;

namespace lab10 {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Введите размерность матрицы: ");
      int nn = Convert.ToInt32(Console.ReadLine());
      // Инициализация
      Matrix mass1 = new Matrix(nn);
      Matrix mass2 = new Matrix(nn);
      Matrix mass3 = new Matrix(nn);
      Matrix mass4 = new Matrix(nn);
      Matrix mass5 = new Matrix(nn);
      Matrix mass6 = new Matrix(nn);
      Matrix mass7 = new Matrix(nn);
      Matrix mass8 = new Matrix(nn);

      Console.WriteLine("ввод Матрица А: ");
      mass1.WriteMatrix();
      Console.WriteLine("Ввод Матрица B: ");
      mass2.WriteMatrix();

      Console.WriteLine("Матрица А: ");
      mass1.ReadMatrix();
      Console.WriteLine();
      Console.WriteLine("Матрица В: ");
      Console.WriteLine();
      mass2.ReadMatrix();

      Console.WriteLine("Транспонированная матрица A");
      mass7 = Matrix.transpositionMatrix(mass1);
      mass7.ReadMatrix();
    }
  }
}
