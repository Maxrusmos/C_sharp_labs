using System;

namespace Dichotomy {
  public static class Dichotomy {
    public delegate double delegateEquation(double x);
    private const double Eps = 1e-15;

    public static string DichotomySolve(double borderFirst, double borderSecond, delegateEquation GetEq, double accuracy) {
      var min = borderFirst;
      var max = borderSecond;
      var intervalLength = borderSecond - borderFirst;
      var err = intervalLength;
      var x = 0.0;

      while (err > accuracy && GetEq(x) != Eps) {
        x = (min + max) / 2;
        if (GetEq(min) * GetEq(x) < Eps) {
          max = x;
        } else if (GetEq(x) * GetEq(max) < Eps) {
          min = x;
        } 
        err = (max - min) / intervalLength;
      }
      return Convert.ToString(x);
    }

    public static double EquationGet(double x){
      return Math.Cos(x) + x;
    }
  }
}
