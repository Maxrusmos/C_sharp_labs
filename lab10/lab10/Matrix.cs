using CExeption;
using System;
using System.Collections;

namespace MatrixOp {
  class Matrix : IEnumerable, ICloneable {
    private int n;
    private double[,] mass;
    public IEnumerator GetEnumerator() {
      return mass.GetEnumerator();
    }

    public object Clone() {
      return this.MemberwiseClone();
    }

    private const double EPS = 1E-9;

    public Matrix() { }

    public int N {
      get {
        return n;
      }
      set {
        if (value > 0) {
          n = value;
        }
      }
    }

    public Matrix(int n) {
      this.n = n;
      mass = new double[this.n, this.n];
    }

    public Matrix(int n, int lowerBorder, int upperBorder) {
      this.n = n;
      Random r = new Random();
      mass = new double[this.n, this.n];
      for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
          mass[i, j] = r.Next(lowerBorder, upperBorder);
        }
      }
    }

    public Matrix(int n, params int[] elems) {
      this.n = n;
      if (n != elems.Length) {
        Console.ForegroundColor = ConsoleColor.Red;
        throw new CustomException("Неверное колическтво аргументов" + Environment.NewLine);
      }
      mass = new double[this.n, this.n];
      for (int i = 0; i < elems.Length; i++) {
        mass[i / n, i % n] = elems[i];
      }
    }

    public double this[int i, int j] {
      get {
        return mass[i, j];
      }
      set {
        mass[i, j] = value;
      }
    }

    // Ввод матрицы с клавиатуры
    public void WriteMatrix() {
      for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
          Console.Write("Введите элемент матрицы " + (i + 1) + " : " + (j + 1) + ": ");
          var matrixElem = Console.ReadLine();
          if (!double.TryParse(matrixElem, out double number)) {
            Console.ForegroundColor = ConsoleColor.Red;
            throw new CustomException("Элемент матрицы не является числом" + Environment.NewLine);
          }
          mass[i, j] = Convert.ToDouble(matrixElem);
        }
      }
    }

    // Вывод матрицы
    public void ReadMatrix() {
      for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
          Console.Write(Math.Round(mass[i, j], 1) + "\t");
        }
        Console.WriteLine();
      }
    }

    // Умножение матрицы А на число
    public static Matrix CompositionWhithNum(Matrix a, double num) {
      Matrix resMass = new Matrix(a.N);
      for (int i = 0; i < a.N; i++) {
        for (int j = 0; j < a.N; j++) {
          resMass[i, j] = a[i, j] * num;
        }
      }
      return resMass;
    }

    // Умножение матрицы А на матрицу Б
    public static Matrix CompositionMatrix(Matrix a, Matrix b) {
      Matrix resMass = new Matrix(a.N);
      for (int i = 0; i < a.N; i++)
        for (int j = 0; j < b.N; j++)
          for (int k = 0; k < b.N; k++)
            resMass[i, j] += a[i, k] * b[k, j];

      return resMass;
    }

    //деление матрицы A на матрицу B
    public static Matrix DivisionMatrix(Matrix a, Matrix b) {
      return Matrix.CompositionMatrix(a, Matrix.ReverseMatrix(b));
    }

    // Сумма матриц
    public static Matrix SumMatrix(Matrix a, Matrix b) {
      Matrix resMass = new Matrix(a.N);
      for (int i = 0; i < a.N; i++) {
        for (int j = 0; j < b.N; j++) {
          resMass[i, j] = a[i, j] + b[i, j];
        }
      }
      return resMass;
    }

    //транспонирование
    public static Matrix TranspositionMatrix(Matrix a) {
      Matrix resMass = new Matrix(a.N);
      for (int i = 0; i < a.N; i++) {
        for (int j = 0; j < a.N; j++) {
          resMass[i, j] = a[j, i];
        }
      }
      return resMass;
    }

    public static double DeterminantMatrix(Matrix detMatrix) {
      var det = 1.0;
      double[][] a = new double[detMatrix.N][];
      double[][] b = new double[1][];
      b[0] = new double[detMatrix.N];

      for (int i = 0; i < detMatrix.N; i++) {
        a[i] = new double[detMatrix.N];
        for (int j = 0; j < detMatrix.N; j++) {
          a[i][j] = detMatrix[i, j];
        }
      }

      for (int i = 0; i < detMatrix.N; ++i) { 
        var k = i;
        for (int j = i + 1; j < detMatrix.N; ++j) {
          if (Math.Abs(a[j][i]) > Math.Abs(a[k][i]))
            k = j;
        }
         
        if (Math.Abs(a[k] [i]) < EPS) {
          det = 0.0;
          break;
        }

        b[0] = a[i];
        a[i] = a[k];
        a[k] = b[0];

        if (i != k) {
          det = -det;
        }

        det *= a[i][i];
        for (int j = i + 1; j < detMatrix.N; ++j) {
          a[i][j] /= a[i][i];
        }
          
        for (int j = 0; j < detMatrix.N; ++j) {
          if ((j != i) && (Math.Abs(a[j][i]) > EPS)) {
            for (k = i + 1; k < detMatrix.N; ++k) {
              a[j][k] -= a[i][k] * a[j][i];
            }               
          }            
        }  
      }
      return det;
    }

    public static Matrix ReverseMatrix(Matrix a) {
      Matrix resMass = new Matrix(a.N);
      Matrix AlgebraicAdditionsMatrix = new Matrix(a.N);
      for (int i = 0; i < a.N; i++) {
        for (int j = 0; j < a.N; j++) {
          AlgebraicAdditionsMatrix[i, j] = Math.Pow(-1, i + j) * DeterminantMatrix(DeleteRowCol(i, j, a));
        }
      }
      AlgebraicAdditionsMatrix = Matrix.TranspositionMatrix(AlgebraicAdditionsMatrix);
      resMass = Matrix.CompositionWhithNum(AlgebraicAdditionsMatrix, 1 / Matrix.DeterminantMatrix(a));
      return resMass;
    }

    public static Matrix DeleteRowCol(int row, int col, Matrix a) { 
      Matrix resMass = new Matrix(a.N - 1);
      for (int i = 0; i < a.N-1; i++) {
        if (i < row) {
          for (int j = 0; j < a.N - 1; j++) { 
            if (j < col) {
              resMass[i, j] = a[i, j];
            } else {
              resMass[i, j] = a[i, j + 1];
            }
          }
        } else {
          for (int j = 0; j < a.N - 1; j++) {
            if (j < col) {
              resMass[i, j] = a[i + 1, j];
            } else {
              resMass[i, j] = a[i + 1, j + 1];
            }
          }
        }
      }
      return resMass;
    }

    ~Matrix() { }
  }
}
