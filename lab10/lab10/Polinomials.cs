//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Collections;

//namespace PolynomOp {
//  class Polynomials<T> : IEnumerable, ICloneable {
//    public T[] koef; //массив коэф-ов
//    int step; //значение степени полинома

//    public IEnumerator GetEnumerator() {
//      return koef.GetEnumerator();
//    }

//    public object Clone() {
//      return this.MemberwiseClone();
//    }

//    public Polynomials(T[] k, int s) {
//      koef = k;
//      step = s;
//    }

//    //сложение полиномов
//    public static Polynomials<T> operator +(Polynomials<T> A, Polynomials<T> B) {
//      int D1 = A.step;
//      T[] M1 = new T[D1 + 1];
//      Polynomials<T> C = new Polynomials<T>(M1, D1);
//      for (int i = 0; i < A.step + 1; i++) {
//        C.koef[i] = A.koef[i] + B.koef[i];
//      }
//      return C;
//    }

//    //вычитание полиномов
//    public static Polynomials<T> operator -(Polynomials<T> A, Polynomials<T> B) {
//      int D1 = A.step;
//      double[] M1 = new double[D1 + 1];
//      Polynomials<T> C = new Polynomials<T>(M1, D1);
//      for (int i = 0; i < A.step + 1; i++) {
//        C.koef[i] = A.koef[i] - B.koef[i];
//      }
//      return C;
//    }

//    //умножение полиномов
//    public static Polynomials<T> operator *(Polynomials<T> A, Polynomials<T> B) {
//      int D1 = A.step;
//      double[] M1 = new double[D1 + 1];
//      Polynomials<T> C = new Polynomials<T>(M1, D1);
//      for (int i = 0; i < A.step + 1; i++) {
//        C.koef[i] = A.koef[i] * B.koef[i];
//      }
//      return C;
//    }

//    //вывод полинома
//    public void show() {
//      for (int i = 0; i < step; i++) {
//        Console.Write("+" + koef[i] + "x^" + (step - i));
//      }
//    }
//  }
//}

