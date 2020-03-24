using System;

namespace Dichotomy {
  public static class Dichotomy {
    public delegate double delegateEquation(double x);
    private const double Eps = 1e-15;

    public static double DichotomySolve(double borderFirst, double borderSecond, delegateEquation GetEq, double accuracy) {
      double a = borderFirst, b = borderSecond, c = 0, fa, fb, fc;
     
      fa = Convert.ToDouble(GetEq(a));
      fb = Convert.ToDouble(GetEq(b));

      if (fa * fb > 0) {
        Console.WriteLine("На данном промежутке нет корней");
        Environment.Exit(1);
      }

      if (Math.Abs(fa) < accuracy) {
        return a;       
      }

      if (Math.Abs(fb) < accuracy) {
        return b;
      }

      do {
        c = a + 0.5 * (b - a);
        fc = Convert.ToDouble(GetEq(c));
        if (Math.Abs(fc) < accuracy) break;
        if (fa * fc < 0) b = c; else a = c;
      }
      while (Math.Abs(a - b) > accuracy);
      return c;
    }

    public static double EquationGet(double x) {
      return Math.Pow(x, 3) - 3 * x + 1;
    }
  }
}
