using System;
using MatrixOp;
using CExeption;
using PolynomOp;
using CorrectOp;

namespace lab10 {
  class Program {
    static void Main(string[] args) {
      //Console.ForegroundColor = ConsoleColor.Magenta;
      //Console.Write("Введите размерность матрицы A: ");
      //var nA = Console.ReadLine();

      //if (!int.TryParse(nA, out int number)) {
      //  Console.ForegroundColor = ConsoleColor.Red;
      //  Console.WriteLine("Размерность не является числом");
      //  Environment.Exit(1);
      //}

      //int n1 = Convert.ToInt32(nA);
      //if (n1< 0) {
      //  Console.ForegroundColor = ConsoleColor.Red;
      //  Console.WriteLine("Размерность не может быть отрицательной");
      //  Environment.Exit(2);
      //}
      //Console.WriteLine();

      //Matrix matrixA = new Matrix(n1);
      //Matrix matrixResult = new Matrix(n1);

      //Console.WriteLine("Ввод первой матрицы (A)");
      //try {
      //  matrixA.WriteMatrix();
      //}
      //catch (CustomException ex) {
      //  Console.ForegroundColor = ConsoleColor.Red;
      //  Console.WriteLine(ex.Message);
      //}
      //Console.WriteLine();

      //Console.ForegroundColor = ConsoleColor.Cyan;
      //Console.Write("Введите размерность матрицы B: ");
      //var nB = Console.ReadLine();
      //if (!int.TryParse(nB, out int number1)) {
      //  Console.ForegroundColor = ConsoleColor.Red;
      //  Console.WriteLine("Размерность не является числом");
      //  Environment.Exit(2);
      //}

      //int n2 = Convert.ToInt32(nB);
      //Matrix matrixB = new Matrix(n2);

      //Console.WriteLine("Ввод второй матрицы (B)");
      //try {
      //  matrixB.WriteMatrix();
      //}
      //catch (CustomException ex) {
      //  Console.ForegroundColor = ConsoleColor.Red;
      //  Console.WriteLine(ex.Message);
      //}
      //Console.WriteLine();

      //Console.ForegroundColor = ConsoleColor.Magenta;
      //Console.WriteLine("Матрица А: ");
      //Console.WriteLine(matrixA.ToString()); 

      //Console.WriteLine("Транспонированная матрица A:");
      //matrixResult = Matrix.TranspositionMatrix(matrixA);
      //Console.WriteLine(matrixResult.ToString()); 
      //Console.WriteLine();

      //Console.WriteLine("Определитель матрицы A:");
      //Console.WriteLine(Matrix.DeterminantMatrix(matrixA));
      //Console.WriteLine();

      //Console.ForegroundColor = ConsoleColor.Cyan;
      //Console.WriteLine("Матрица В: ");
      //Console.WriteLine(matrixB.ToString());

      //Console.WriteLine("Транспонированная матрица B:");
      //matrixResult = Matrix.TranspositionMatrix(matrixB);
      //Console.WriteLine(matrixResult.ToString());

      //Console.WriteLine("Определитель матрицы B:");
      //Console.WriteLine(Matrix.DeterminantMatrix(matrixB));
      //Console.WriteLine();

      //Console.ForegroundColor = ConsoleColor.Yellow;
      //try {
      //  Console.ForegroundColor = ConsoleColor.Yellow;
      //  Console.WriteLine("Сумма матриц A и B:");
      //  matrixResult = Matrix.SumMatrix(matrixA, matrixB);      
      //  Console.WriteLine(matrixResult.ToString());
      //}
      //catch (CustomException ex) {
      //  Console.ForegroundColor = ConsoleColor.Red;
      //  Console.WriteLine(ex.Message);
      //}

      //try {
      //  Console.ForegroundColor = ConsoleColor.Yellow;
      //  Console.WriteLine("Умножение матрицы A на матрицу B:");
      //  matrixResult = Matrix.CompositionMatrix(matrixA, matrixB);
      //  Console.WriteLine(matrixResult.ToString());
      //}
      //catch (CustomException ex) {
      //  Console.ForegroundColor = ConsoleColor.Red;
      //  Console.WriteLine(ex.Message);
      //}

      //Console.WriteLine("Деление матрицы A на матрицу B:");
      //try {
      //  Console.ForegroundColor = ConsoleColor.Yellow;
      //  matrixResult = Matrix.DivisionMatrix(matrixA, matrixB);
      //  Console.WriteLine(matrixResult.ToString());
      //}
      //catch (CustomException ex) {
      //  Console.ForegroundColor = ConsoleColor.Red;
      //  Console.WriteLine(ex.Message);
      //}
      //Console.WriteLine();


      var dot = 0.0; //точка, в которой искать зачение полинома

      //ввод первого полинома
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.Write("Введите максимальную степень первого полинома: ");
      var maxPowerFirst = 0;
      try {
        maxPowerFirst = CorrectEnter.CorrectParsePower(Console.ReadLine());
      } 
      catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Environment.Exit(1);
      }
      var powerArrFirst = new int[maxPowerFirst + 1];
      for (int i = 0; i < powerArrFirst.Length; i++) {
        powerArrFirst[i] = maxPowerFirst--;
      }

      Console.Write("Введите коэффициетны при каждой степени полинома через пробел: ");
      var koefArrFirst = Console.ReadLine().Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
      CorrectEnter.CorrectParseKoef(koefArrFirst);
      double[] koefFirst = new double[powerArrFirst.Length];
      for (int i = 0; i < koefArrFirst.Length; i++) {
        koefFirst[i] = double.Parse(koefArrFirst[i]);
      }
      Polinom A = new Polinom(koefFirst, powerArrFirst);
      Console.WriteLine("A = " + A.ToString());
      Console.WriteLine();
      Console.Write("Введите точку, в которой хотите найти значение полинома: ");
      try {
        dot = CorrectEnter.CorrectParseDot(Console.ReadLine());
        Console.WriteLine("Значене полинома A в точке " + dot + ": " + Polinom.EvalDot(dot, A));
      }
      catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }


      //ввод второго многочлена
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine();
      Console.Write("Введите максимальную степень второго полинома: ");
      var maxPowerSecond = 0;
      try {
        maxPowerSecond = CorrectEnter.CorrectParsePower(Console.ReadLine());
      }
      catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Environment.Exit(2);
      }
      var powerArrSecond = new int[maxPowerSecond + 1];
      for (int i = 0; i < powerArrSecond.Length; i++) {
        powerArrSecond[i] = maxPowerSecond--;
      }

      Console.Write("Введите коэффициетны при каждой степени полинома через пробел: ");
      var koefArrSecond = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      CorrectEnter.CorrectParseKoef(koefArrSecond);
      double[] koefSecond = new double[powerArrSecond.Length];
      for (int i = 0; i < koefArrSecond.Length; i++) {
        koefSecond[i] = double.Parse(koefArrSecond[i]);
      }
      Polinom B = new Polinom(koefSecond, powerArrSecond);
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("B = " + B.ToString());
      Console.WriteLine();
      Console.Write("Введите точку, в которой хотите найти значение полинома: ");
      try {
        dot = CorrectEnter.CorrectParseDot(Console.ReadLine());
        Console.WriteLine("Значене полинома B в точке " + dot + ": " + Polinom.EvalDot(dot, B));
      }
      catch (CustomException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }

      //операции над полиномами
      Console.WriteLine(Environment.NewLine);
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("A + B = " + (A + B).ToString());
      Console.WriteLine();

      Console.Write("A - B = " + (A - B).ToString());
      Console.WriteLine();

      Console.Write("A * B = " + (A  * B).ToString());
      Console.WriteLine();

      Console.Write("Композиция A и B = " + Polinom.PolinomComposition(A, B).ToString());
      Console.WriteLine();
    }
  }
}
