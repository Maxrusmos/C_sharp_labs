using System;
using System.Collections.Generic;
using System.Text;

namespace lab10 {
  class Matrix {
    private int n;
    private int[,] mass;

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
      mass = new int[this.n, this.n];
    }

    public int this[int i, int j] {
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
          Console.WriteLine("Введите элемент матрицы " + i + 1 + " : " + j + 1);
          mass[i, j] = Convert.ToInt32(Console.ReadLine());
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
    public static Matrix compositionMatrix(Matrix a, Matrix b) {
      Matrix resMass = new Matrix(a.N);
      for (int i = 0; i < a.N; i++)
        for (int j = 0; j < b.N; j++)
          for (int k = 0; k < b.N; k++)
            resMass[i, j] += a[i, k] * b[k, j];

      return resMass;
    }

    // Метод вычитания матрицы Б из матрицы А
    public static Matrix differenceMatrix(Matrix a, Matrix b) {
      Matrix resMass = new Matrix(a.N);
      for (int i = 0; i < a.N; i++) {
        for (int j = 0; j < b.N; j++) {
          resMass[i, j] = a[i, j] - b[i, j];
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

    //транспоирование
    public static Matrix transpositionMatrix(Matrix a) {
      Matrix resMass = new Matrix(a.N);
      for (int i = 0; i < a.N; i++) {
        for (int j = 0; j < a.N; j++) {
          resMass[i, j] = a[j, i];
        }
      }
      return resMass;
    }

    ~Matrix() { }
  }
}
