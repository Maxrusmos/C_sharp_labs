using System;
using System.Collections.Generic;
using System.Text;
using EventCustomOp;

namespace ComplexOp {
  public class ComplexNum {
    private double _real, _imaginary;

    public ComplexNum() {
      this._real = 0.0;
      this._imaginary = 0.0;
    }

    public ComplexNum(double real, double imaginary) {
      this._real = real;
      this._imaginary = imaginary;
    }

    //сумма
    public static ComplexNum ComplexSum(ComplexNum A, ComplexNum B) {
      var resultComplex = new ComplexNum(A._real + B._real, A._imaginary + B._imaginary);
      return resultComplex;
    }

    public static ComplexNum operator +(ComplexNum A, ComplexNum B) {
      return ComplexSum(A, B);
    }

    //разность
    public static ComplexNum ComplexDifference(ComplexNum A, ComplexNum B) {
      var resultComplex = new ComplexNum(A._real - B._real, A._imaginary - B._imaginary);
      return resultComplex;
    }

    public static ComplexNum operator -(ComplexNum A, ComplexNum B) {
      return ComplexDifference(A, B);
    }

    //произведение
    public static ComplexNum ComplexComposition(ComplexNum A, ComplexNum B) {
      var resultComplex = new ComplexNum();
      resultComplex._real = A._real * B._real - A._imaginary * B._imaginary;
      resultComplex._imaginary = A._real * B._imaginary + A._imaginary * B._real;
      return resultComplex;
    }

    public static ComplexNum operator *(ComplexNum A, ComplexNum B) {
      return ComplexComposition(A, B);
    }


    //частное
    public static ComplexNum ComplexDivision(ComplexNum A, ComplexNum B) {
      var resultComplex = new ComplexNum();
      resultComplex._real = (A._real * B._real + A._imaginary * B._imaginary) / (B._real * B._real + B._imaginary * B._imaginary);
      resultComplex._imaginary = (B._real * A._imaginary - A._real * B._imaginary) / (B._real * B._real + B._imaginary * B._imaginary);
      return resultComplex;
    }

    public static ComplexNum operator /(ComplexNum A, ComplexNum B) {
      return ComplexDivision(A, B);
    }

    //модуль
    public static double ComplexAbs(ComplexNum A) {
      return Math.Sqrt(Math.Pow(A._real, 2) + Math.Pow(A._imaginary, 2));
    }

    //степень
    public static ComplexNum ComplexPow(ComplexNum A, int power) {
      double fi_cos = Math.Acos(A._real / ComplexAbs(A));
      double fi_sin = Math.Asin(A._imaginary / ComplexAbs(A));
      var resultComplex = new ComplexNum(Math.Pow(ComplexAbs(A), power) * Math.Cos(power * fi_cos), 
                                         Math.Pow(ComplexAbs(A), power) * Math.Sin(power * fi_sin));
      return resultComplex;
    }

    //вывод
    public override string ToString() {
      return "(" + this._real + ",  " + this._imaginary + ")";
    }
  }
}
