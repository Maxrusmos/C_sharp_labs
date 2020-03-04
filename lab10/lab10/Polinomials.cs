using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomOp {
  class Polynomials {
    double[] koef; //массив коэф-ов
    int step; //значение степени полинома

    public Polynomials(double[] k, int s) {
      koef = k;
      step = s;
    }

    //сложение полиномов
    public static Polynomials operator +(Polynomials A, Polynomials B) {
      int D1 = A.step;
      double[] M1 = new double[D1 + 1];
      Polynomials C = new Polynomials(M1, D1);
      for (int i = 0; i < A.step + 1; i++) {
        C.koef[i] = A.koef[i] + B.koef[i];
      }
      return C;
    }


    //вычитание полиномов
    public static Polynomials operator -(Polynomials A, Polynomials B) {
      int D1 = A.step;
      double[] M1 = new double[D1 + 1];
      Polynomials C = new Polynomials(M1, D1);
      for (int i = 0; i < A.step + 1; i++) {
        C.koef[i] = A.koef[i] - B.koef[i];
      }
      return C;
    }


    //умножение полиномов
    public static Polynomials operator *(Polynomials A, Polynomials B) {
      int D1 = A.step;
      double[] M1 = new double[D1 + 1];
      Polynomials C = new Polynomials(M1, D1);
      for (int i = 0; i < A.step + 1; i++) {
        C.koef[i] = A.koef[i] * B.koef[i];
      }
      return C;
    }

    //вывод полинома
    public void show() {
      for (int i = 0; i < step; i++) {
        Console.Write("+" + koef[i] + "x^" + (step - i));
      }
    }
  }
}

