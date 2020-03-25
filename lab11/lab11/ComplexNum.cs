using System;
using EventCustomOp;

namespace ComplexOp {
  public delegate void Handler(EventCustom obj);
  public class ComplexNum: IComparable, IComparable<ComplexNum>{  
    public static event Handler DivisionZero;

    public int CompareTo(ComplexNum A) {
      var ca1 = ComplexAbs(this);
      var ca2 = ComplexAbs(A);
      if (ca1 > ca2) {
        return 1;
      } else if (ca1 < ca2){
        return -1;
      } else {
        return 0;
      }
    }

    public int CompareTo(object obj) {
      if (!(obj is ComplexNum)) {
        throw new ArgumentException("Не могу сравнить значения", nameof(obj));
      }
      return CompareTo((ComplexNum)obj);
    }

    private const double Eps = 1E-10;
    private double _real, _imaginary;

    public ComplexNum() {
      _real = 0.0;
      _imaginary = 0.0;
    }

    public ComplexNum(double real, double imaginary) {
      _real = real;
      _imaginary = imaginary;
    }

    public double Real => _real;
    public double Imaginary => _imaginary;


    public ComplexNum(int bottomBorder, int topBorder) {
      if (bottomBorder > topBorder) {
        (bottomBorder, topBorder) = (topBorder, bottomBorder);
      }
      Random rnd = new Random();
      _real = bottomBorder + (rnd.NextDouble() * (topBorder - bottomBorder));
      _imaginary = bottomBorder + (rnd.NextDouble() * (topBorder - bottomBorder));
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

    //произведение с действительным числом
    public static ComplexNum ComplexCompositionNum(ComplexNum A, dynamic num) {
      var resultComplex = new ComplexNum();
      resultComplex._real = A._real * num;
      resultComplex._imaginary = A._imaginary;
      return resultComplex;
    }

    public static ComplexNum operator *(ComplexNum A, dynamic num) {
      return ComplexCompositionNum(A, num);
    }

    //частное
    public static ComplexNum ComplexDivision(ComplexNum A, ComplexNum B) {
      var resultComplex = new ComplexNum();     
      if (Math.Abs(B._real * B._real + B._imaginary * B._imaginary) < Eps || Math.Abs(B._real * B._real + B._imaginary * B._imaginary) < Eps) {
        var obj = new EventCustom(A, B);
        DivisionZero(obj);
      }
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
      if (power < 0) {
        throw new ArgumentException("Отрицательная степень", nameof(power));
      }
      double fi_cos = Math.Acos(A._real / ComplexAbs(A));
      double fi_sin = Math.Asin(A._imaginary / ComplexAbs(A));
      var resultComplex = new ComplexNum(Math.Pow(ComplexAbs(A), power) * Math.Cos(power * fi_cos), 
                                         Math.Pow(ComplexAbs(A), power) * Math.Sin(power * fi_sin));
      return resultComplex;
    }

    //аргумент
    public static double ComplexArgument(ComplexNum A) {
      var arg = 0.0;
      if (A._real > 0 && A._imaginary >= 0) {
        arg = Math.Atan(A._imaginary / A._real);
      }
      if (A._real < 0 && A._imaginary >= 0) {
        arg = Math.Atan(A._imaginary / A._real) + Math.PI;
      }
      if (A._real < 0 && A._imaginary < 0) {
        arg = Math.Atan(A._imaginary / A._real) - Math.PI;
      }
      if (A._real == 0 && A._imaginary > 0) {
        arg = Math.PI / 2;
      }
      if (A._real == 0 && A._imaginary < 0) {
        arg = Math.PI * 3 / 2;
      }
      return arg;
    }

    //корень
    public static ComplexNum[] ComplexSqrtN(ComplexNum A, int sqrtValue) {
      if (sqrtValue < 0) {
        throw new ArgumentException("Корень отрицательной степени", nameof(sqrtValue));
      }
      var resulComplexArr = new ComplexNum[sqrtValue];
      var complexTmpAbs = new ComplexNum(Math.Pow(ComplexAbs(A), (1.0 / sqrtValue)), 0.0);
      for (int k = 0; k < sqrtValue; k++) {
        var complexTrigonometryNum = new ComplexNum(Math.Cos((ComplexArgument(A) + 2 * Math.PI * k) / Convert.ToDouble(sqrtValue)), 
                                                    Math.Sin((ComplexArgument(A) + 2 * Math.PI * k) / Convert.ToDouble(sqrtValue)));
        resulComplexArr[k] = complexTmpAbs * complexTrigonometryNum;
        if (Math.Abs(resulComplexArr[k]._real) < Eps) {
          resulComplexArr[k]._real = 0.0;
        }
        if (Math.Abs(resulComplexArr[k]._imaginary) < Eps) {
          resulComplexArr[k]._imaginary = 0.0;
        }
      }
      return resulComplexArr;
    }

    //вывод
    public override string ToString() {
      return "Complex(" + _real + "   " + _imaginary + ")";  
    }
  }
}
