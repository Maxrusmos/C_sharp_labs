using CExeption;
using System;
using System.Collections;
using System.Text;

namespace MatrixOp {
  public sealed class Matrix : IEnumerable, ICloneable, IComparable, IComparable<Matrix> {
    private double[,] mass;

    public int CompareTo(Matrix A) {
      var ca1 = DeterminantMatrix(this);
      var ca2 = DeterminantMatrix(A);
      if (ca1 > ca2) {
        return 1;
      } else if (ca1 < ca2) {
        return -1;
      } else {
        return 0;
      }
    }

    public int CompareTo(object obj) {
      if (!(obj is Matrix)) {
        throw new ArgumentException("Не могу сравнить значения", nameof(obj));
      }
      if (obj is null) {
        throw new ArgumentException("NULL", nameof(obj));
      }
      return CompareTo((Matrix)obj);
    }

    public IEnumerator GetEnumerator() {
      return mass.GetEnumerator();
    }

    public object Clone() {
      double[,] newMass = new double[mass.Length, mass.Length];
      for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; i++) {
          newMass[i, j] = mass[i, j];
        }
      }
      return newMass;
    }

    private const double EPS = 1E-15;

    public Matrix() { }

    public int N =>
      mass.GetLength(0);

    public Matrix(int n) {
      mass = new double[n, n];
    }

    public Matrix(int n, int lowerBorder, int upperBorder) {
      Random r = new Random();
      mass = new double[n, n];
      for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
          mass[i, j] = r.Next(lowerBorder, upperBorder);
        }
      }
    }

    public Matrix(int n, params int[] elems) {
      mass = new double[n, n];
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

    //ввод матрицы
    public void WriteMatrix() {
      for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
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

    //вывод матрицы
    public override string ToString() {
      StringBuilder strMatrix = new StringBuilder();
      for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
          strMatrix.Append(Math.Round(mass[i, j], 1).ToString() + "\t");
        }      
        strMatrix.Append(Environment.NewLine);       
      }
      return strMatrix.ToString();
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

    public static Matrix operator *(Matrix a, double num) {
      return CompositionWhithNum(a, num);
    }

    // Умножение матрицы А на матрицу B
    public static Matrix CompositionMatrix(Matrix a, Matrix b) {
      if (a.N != b.N) {
        throw new CustomException($"Эти матрицы нельзя перемножить{Environment.NewLine}");
      }
      Matrix resMass = new Matrix(a.N); 
      for (int i = 0; i < a.N; i++)
        for (int j = 0; j < b.N; j++)
          for (int k = 0; k < b.N; k++)
            resMass[i, j] += a[i, k] * b[k, j];

      return resMass;
    }

    public static Matrix operator *(Matrix a, Matrix b) {
      return CompositionMatrix(a, b);
    }

    //возведение матрицы в степень
    public static Matrix MatrixPow(Matrix A, int pow) {
      var resultMatrix = A;
      for (int i = 0; i < pow - 1; i++) {
        resultMatrix *= A;
      }
      return resultMatrix;
    }

    //деление матрицы A на матрицу B
    public static Matrix DivisionMatrix(Matrix a, Matrix b) {
      return Matrix.CompositionMatrix(a, Matrix.ReverseMatrix(b));
    }

    public static Matrix operator /(Matrix a, Matrix b) {
      return DivisionMatrix(a, b);
    }

    // Сумма матриц
    public static Matrix SumMatrix(Matrix a, Matrix b) {
      if (a.N != b.N) {
        throw new CustomException("Размерности матриц не совпадают" + Environment.NewLine);
      }
      Matrix resMass = new Matrix(a.N);
      for (int i = 0; i < a.N; i++) {
        for (int j = 0; j < b.N; j++) {
          resMass[i, j] = a[i, j] + b[i, j];
        }
      }
      return resMass;
    }

    public static Matrix operator +(Matrix a, Matrix b) {
      return SumMatrix(a, b);
    }

    // Сумма матриц
    public static Matrix DifferenceMatrix(Matrix a, Matrix b) {
      if (a.N != b.N) {
        throw new CustomException("Размерности матриц не совпадают" + Environment.NewLine);
      }
      Matrix resMass = new Matrix(a.N);
      for (int i = 0; i < a.N; i++) {
        for (int j = 0; j < b.N; j++) {
          resMass[i, j] = a[i, j] - b[i, j];
        }
      }
      return resMass;
    }

    public static Matrix operator -(Matrix a, Matrix b) {
      return DifferenceMatrix(a, b);
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

    //определитель
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

    //обратная матрица
    public static Matrix ReverseMatrix(Matrix a) {
      Matrix resMass = new Matrix(a.N);
      Matrix AlgebraicAdditionsMatrix = new Matrix(a.N);
      if (Math.Abs(DeterminantMatrix(a)) < EPS) {
        throw new CustomException("Определитель матрицы равен 0. Матрицa вырожденная" + Environment.NewLine);
      }
      for (int i = 0; i < a.N; i++) {
        for (int j = 0; j < a.N; j++) {
          AlgebraicAdditionsMatrix[i, j] = Math.Pow(-1, i + j) * DeterminantMatrix(DeleteRowCol(i, j, a));
        }
      }
      AlgebraicAdditionsMatrix = TranspositionMatrix(AlgebraicAdditionsMatrix);
      resMass = CompositionWhithNum(AlgebraicAdditionsMatrix, 1 / DeterminantMatrix(a));
      return resMass;
    }

    //миноры
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
  }
}
