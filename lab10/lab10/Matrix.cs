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

    // Создаем конструкторы матрицы
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

    // Задаем аксессоры для работы с полями вне класса Matrix
    public Matrix(int n) {
      this.n = n;
      mass = new double[this.n, this.n];
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
          Console.Write(mass[i, j] + "\t");
        }
        Console.WriteLine();
      }
    }

    // Умножение матрицы А на число
    public static Matrix compositionWhithNum(Matrix a, int num) {
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
      Matrix resMass = new Matrix(a.N);
      for (int i = 0; i < a.N; i++) {
        for (int j = 0; j < b.N; j++) {
          for (int k = 0; k < b.N; k++) {
            resMass[i, j] += a[i, k] * 1 / b[k, j];
          }
        }
      }
      return resMass;
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

    ~Matrix() { }
  }
}
