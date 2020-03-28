using System;
using MatrixOp;
using CExeption;
using PolynomOp;

namespace lab10 {
  class Program {
    static void Main(string[] args) {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"МАТРИЦЫ {Environment.NewLine}");
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("Матрица A:");
      Matrix A = new Matrix(3);
      Console.WriteLine(A.ToString());
      Console.WriteLine("Транспонированая матрица:");
      Console.WriteLine(Matrix.TranspositionMatrix(A).ToString());
      Console.WriteLine("A * 34:" + Environment.NewLine + (A * 34).ToString() + Environment.NewLine);
      Console.WriteLine("A ^ 4:" + Environment.NewLine + Matrix.MatrixPow(A, 4).ToString());
      Console.WriteLine($"Определитель матрицы A = {Matrix.DeterminantMatrix(A)} {Environment.NewLine}");
      Console.WriteLine("Обратная матрица:");
      try {
        Console.WriteLine(Matrix.ReverseMatrix(A));
      } catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }

      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("-----------------------------------" + Environment.NewLine);

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Матрица B:");
      Matrix B = new Matrix(2);
      Console.WriteLine(B.ToString());
      Console.WriteLine("Транспонированая матрица:");
      Console.WriteLine(Matrix.TranspositionMatrix(B).ToString());
      Console.WriteLine("B * 11:" + Environment.NewLine + (B * 11).ToString() + Environment.NewLine);
      Console.WriteLine("B ^ 2:" + Environment.NewLine + Matrix.MatrixPow(B, 2).ToString());
      Console.WriteLine($"Определитель матрицы B = {Matrix.DeterminantMatrix(B)} {Environment.NewLine}");
      Console.WriteLine("Обратная матрица:");
      try {
        Console.WriteLine(Matrix.ReverseMatrix(B));
      } catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }

      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("-----------------------------------" + Environment.NewLine);

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine($"Операции с матрицами A и B: {Environment.NewLine}");
      try {
        Console.WriteLine($"A + B: {Environment.NewLine}{(A + B).ToString()}");
        Console.WriteLine($"A * B: {Environment.NewLine}{(A * B).ToString()}");
      } catch (CustomException ex) {
        Console.WriteLine(ex.Message);
      }
      try {
        Console.WriteLine($"A / B: {Environment.NewLine}{(A / B).ToString()}");
      }
      catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }

      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("-----------------------------------" + Environment.NewLine);

      Console.WriteLine($"ПОЛИНОМЫ С ОБЫЧНЫМИ КОЭФФИЦИЕНТАМИ {Environment.NewLine}");
      Console.ForegroundColor = ConsoleColor.Magenta;

      var matrixArr1 = new Matrix[2]{ A, B };
      var matrixArr2 = new Matrix[2] { B, B };

      var aPolynom = new Polynom<int>(2, 1, 5, 3);
      Console.WriteLine($"Полином Ap = {aPolynom.ToString()}");
      Console.WriteLine($"Ap * 2 = {(aPolynom * 2).ToString()}");
      Console.WriteLine($"Значение полинома в точке 4 = {aPolynom.PolynomInDot(4).ToString()}");
      Console.WriteLine($"Ap^4 = {Polynom<int>.PolynomPow(aPolynom, 4).ToString()}{Environment.NewLine}");

      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("-----------------------------------" + Environment.NewLine);

      Console.ForegroundColor = ConsoleColor.Cyan;
      var bPolynom = new Polynom<int>(1, 1, 3);
      Console.WriteLine($"Полином Bp = {bPolynom.ToString()}");
      Console.WriteLine($"Bp * 3 = {(bPolynom * 3).ToString()}");
      Console.WriteLine($"Значение полинома в точке 2 = {(bPolynom.PolynomInDot(2)).ToString()}");
      Console.WriteLine($"Bp^2 = {Polynom<int>.PolynomPow(bPolynom, 2).ToString()}{Environment.NewLine}");

      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("-----------------------------------" + Environment.NewLine);

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Операции с полиномами Ap и Bp:");
      Console.WriteLine($"Ap + Bp = {(aPolynom + bPolynom).ToString()}");
      Console.WriteLine($"Ap - Bp = {(aPolynom - bPolynom).ToString()}");
      Console.WriteLine($"Ap * Bp = {(aPolynom * bPolynom).ToString()}");
      Console.WriteLine($"Композиция полиномов: {Polynom<int>.CompositionPolynimWithPolynom(aPolynom, bPolynom).ToString()}{Environment.NewLine}");

      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("-----------------------------------" + Environment.NewLine);

      Console.WriteLine($"ПОЛИНОМЫ С МАТРИЧНЫМИ КОЭФФИЦИЕНТАМИ {Environment.NewLine}");
      Console.ForegroundColor = ConsoleColor.Magenta;

      var cPolynom = new Polynom<Matrix>(2, A, B, B);
      Console.WriteLine($"Полином Сp:{Environment.NewLine}{cPolynom.ToString()}");
      try {
        Console.WriteLine($"Cp^4:{Environment.NewLine}{Polynom<Matrix>.PolynomPow(cPolynom, 4).ToString()}{Environment.NewLine}");
      } catch (CustomException ex) {
        Console.WriteLine(ex.Message);
      }

      Console.ForegroundColor = ConsoleColor.Cyan;
      var dPolynom = new Polynom<Matrix>(1, B, A);
      Console.WriteLine($"Полином Dp:{Environment.NewLine}{dPolynom.ToString()}");

      try {
        Console.WriteLine($"Dp^2:{Environment.NewLine}{Polynom<Matrix>.PolynomPow(dPolynom, 2).ToString()}{Environment.NewLine}");
      } catch (CustomException ex) {
        Console.WriteLine(ex.Message);
      }
     

      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("-----------------------------------" + Environment.NewLine);

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Операции с полиномами Cp и Dp:");
      try {
        Console.WriteLine($"Cp + Dp:{Environment.NewLine}{(cPolynom + dPolynom).ToString()}");
        Console.WriteLine($"Cp - Dp:{Environment.NewLine}{(cPolynom - dPolynom).ToString()}");
        Console.WriteLine($"Cp * Dp:{Environment.NewLine}{(cPolynom * dPolynom).ToString()}");
      } catch(CustomException ex) {
        Console.WriteLine(ex.Message);
      }

      //Console.WriteLine($"Композиция полиномов: {Polynom<Matrix>.CompositionPolynimWithPolynom(cPolynom, dPolynom).ToString()}{Environment.NewLine}");
      //Console.WriteLine(Polynom<int>.CompositionPolynimWithPolynom(bPolynom, aPolynom).ToString());
      //Console.WriteLine(Polynom<int>.PolynomComposition(dPolynom, cPolynom).ToString());
    }
  }
}
