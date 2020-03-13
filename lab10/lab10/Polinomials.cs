using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ArrayParseOp;

namespace PolynomOp {
  class Polinom : IEnumerable, ICloneable {
    public IEnumerator GetEnumerator() {
      return _koef.GetEnumerator();
    }

    public object Clone() {
      int[] clonePower = _power;
      double[] cloneKoef = new double[_koef.Length];
      for (int i = 0; i < cloneKoef.Length; i++) {
        cloneKoef[i] = _koef[i];
      }   
      return cloneKoef;
    }

    double[] _koef; //массив коэффициентов
    int[] _power; //массив степеней

    public Polinom(double[] k, int[] p) {
      _koef = k;
      _power = p;
    }

    //сумма полиномов 
    public static Polinom PolinomSum(Polinom A, Polinom B) {
      var maxFirst = ArrayParse.SearchMaxElem(A._power);
      var maxSecond = ArrayParse.SearchMaxElem(B._power);
      var maxPower = Math.Max(maxFirst, maxSecond);
      var resultPowerArr = new int[maxPower + 1]; 
      var resultArrKoef = new double[resultPowerArr.Length];

      for (int i = 0; i < resultArrKoef.Length; i++) {
        resultPowerArr[i] = maxPower--;
      }
      var arrKoefFirst = ArrayParse.FillArr(resultPowerArr.Length, A._koef);
      var tmpArr = ArrayParse.FillArr(resultPowerArr.Length, arrKoefFirst);
      var arrKoefSecond = ArrayParse.FillArr(resultPowerArr.Length, B._koef); ;
      var tmpArr1 = ArrayParse.FillArr(resultPowerArr.Length, arrKoefSecond);
      for (int i = 0; i < resultArrKoef.Length; i++) {
        resultArrKoef[i] = ArrayParse.SwapFirst(maxFirst, maxSecond, arrKoefFirst, tmpArr)[i] +
          ArrayParse.SwapSecond(maxFirst, maxSecond, arrKoefSecond, tmpArr1)[i];
      }
      var resultPolinom = new Polinom(resultArrKoef, resultPowerArr);
      return resultPolinom;
    }

    public static Polinom operator +(Polinom A, Polinom B) {
      return PolinomSum(A, B);
    }

    //разность полиномов
    public static Polinom PolinomDifference(Polinom A, Polinom B) {
      var maxFirst = ArrayParse.SearchMaxElem(A._power);
      var maxSecond = ArrayParse.SearchMaxElem(B._power);
      var maxPower = Math.Max(maxFirst, maxSecond);
      var resultPowerArr = new int[maxPower + 1];
      var resultArrKoef = new double[resultPowerArr.Length];
      for (int i = 0; i < resultArrKoef.Length; i++) {
        resultPowerArr[i] = maxPower--;
      }
      var arrKoefFirst = ArrayParse.FillArr(resultPowerArr.Length, A._koef);
      var tmpArr = ArrayParse.FillArr(resultPowerArr.Length, arrKoefFirst);
      var arrKoefSecond = ArrayParse.FillArr(resultPowerArr.Length, B._koef); ;
      var tmpArr1 = ArrayParse.FillArr(resultPowerArr.Length, arrKoefSecond);
      for (int i = 0; i < resultArrKoef.Length; i++) {
        resultArrKoef[i] = ArrayParse.SwapFirst(maxFirst, maxSecond, arrKoefFirst, tmpArr)[i] - 
          ArrayParse.SwapSecond(maxFirst, maxSecond, arrKoefSecond, tmpArr1)[i];
      }
      var resultPolinom = new Polinom(resultArrKoef, resultPowerArr);
      return resultPolinom;
    }

    public static Polinom operator -(Polinom A, Polinom B) {
      return PolinomDifference(A, B);
    }

    //произведение полиномов
    public static Polinom PolinomMultiplication(Polinom A, Polinom B) {
      var resultPolinomArrPower = new double[ArrayParse.SearchMaxElem(A._power) + ArrayParse.SearchMaxElem(B._power)];
      

      for (int i = 0; i < resultPolinomArrPower.Length; i++) {
        resultPolinomArrPower[i] = A._power[i] + B._power[i];
      }
      foreach (double kek in resultPolinomArrPower) {
        Console.WriteLine(kek);
      }
      return A;
    }

    //значение плоинома в точке
    public static double EvalDot(double dot, Polinom A) {
      double result = 0.0;
      for (int i = 0; i < A._koef.Length; i++) {
        result += Math.Pow(dot, A._power[i]) * A._koef[i];
      }
      return result;
    }

    //вывод полинома
    public override string ToString() {
      StringBuilder str = new StringBuilder();
      var tmpStr = "";
      for (int i = 0; i < _power.Length; i++) {
        if (_koef[i] == 0) {
          tmpStr = "";
        } else {
          if (_koef[i] < 0) {
            if (_koef[i] == -1 && i == 0) {
              tmpStr = "-";
            } else { 
              if (_koef[i] == -1) {
                tmpStr = " - ";
              } else {
                tmpStr = " - " + Math.Abs(_koef[i]);
              }
            } 
          } else {
            if (_koef[i] == 1) {
              if (i == 0) {
                tmpStr = "";
              } else {
                tmpStr = " + ";
              }
            } else {
              if (i == 0) {
                tmpStr = _koef[i].ToString();
              } else {
                tmpStr = " + " + _koef[i];
              }
            }
            
          }        
        }
        if (i == 0 && _koef[i] != 0) {
          str.Append(tmpStr + "x^(" + _power[i] + ")");
        } else if (_koef[i] != 0) {
          if (_power[i] == 1) {
            str.Append(tmpStr + "x");
          } else if (_power[i] == 0) {
            str.Append(" + " + _koef[i]);
          } else {
            str.Append(tmpStr + "x^(" + _power[i] + ")");
          }
        } else {
          str.Append(tmpStr);
        }
      }
      return str.ToString();
    }
  }
}

