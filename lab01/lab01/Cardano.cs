using System;
using System.Numerics;

namespace Cardano {
  public class Cardano {

    private static Complex Muavr(Complex A) {
      double fi_cos = Math.Acos(A.Real / Complex.Abs(A));
      double fi_sin = Math.Asin(A.Imaginary / Complex.Abs(A));

      Complex FirtsRoot = new Complex(Math.Pow(Complex.Abs(A), 1.0 / 3.0) * Math.Cos(1.0 / 3.0 * fi_cos),
                                      Math.Pow(Complex.Abs(A), 1.0 / 3.0) * Math.Sin(1.0 / 3.0 * fi_sin));
      return FirtsRoot;
    }

    public static Complex[] CordanoMethod(double a, double b, double c, double d) {
      Complex[] complexArr = new Complex[3];

      double p = (-(b * b) / (3.0 * a * a)) + (c / a);
      double q = ((2.0 * Math.Pow(b, 3)) / (27.0 * Math.Pow(a, 3))) - ((b * c) / (3.0 * a * a)) + (d / a);

      double Q = Math.Pow(p / 3.0, 3) + Math.Pow(q / 2.0, 2);
      double A;
      double B;

      if (Q < 0) {
        double tmp_p = -p / 3.0;
        var sqrt_Q = new Complex(Q, 0);
        sqrt_Q = Complex.Sqrt(sqrt_Q);

        var tmp_A = new Complex(-q / 2.0, sqrt_Q.Imaginary);
        var tmp_B = new Complex(-q / 2.0, -sqrt_Q.Imaginary);

        var A_compl = Muavr(tmp_A);
        var B_compl = Muavr(tmp_B);

        double y1 = (((-Complex.Add(A_compl / 2.0, B_compl / 2.0)) +
          Complex.Multiply(Complex.ImaginaryOne, (Complex.Subtract(A_compl / 2.0, B_compl / 2.0) * Math.Sqrt(3.0))))).Real;
        complexArr[0] = (y1 - (b / (3.0 * a)));

        double y3 = (((-Complex.Add(A_compl / 2.0, B_compl / 2.0)) -
          Complex.Multiply(Complex.ImaginaryOne, (Complex.Subtract(A_compl / 2.0, B_compl / 2.0) * Math.Sqrt(3.0))))).Real;
        complexArr[2] = (y3 - (b / (3.0 * a)));

        double y2 = (Complex.Add(A_compl, B_compl)).Real;
        complexArr[1] = y2 - (b / (3.0 * a));
      }

      double tmp_positive = (-q / 2.0) + Math.Sqrt(Q);
      double tmp_negative = (-q / 2.0) - Math.Sqrt(Q);

      if (tmp_positive < 0) {
        A = -Math.Pow(-tmp_positive, (1.0 / 3.0));
      } else {
        A = Math.Pow(tmp_positive, (1.0 / 3.0));
      }
      
      if (tmp_negative < 0) {
        B = -Math.Pow(-tmp_negative, (1.0 / 3.0));
      } else {
        B = Math.Pow(tmp_negative, (1.0 / 3.0));
      }

      if (Q > 0) {
        double y1 = A + B;
        complexArr[0] = y1 - (b / (3.0 * a));

        double Re_x2 = -((A + B) / 2.0) - (b / (3.0 * a));
        double Im_x2 = (Math.Sqrt(3.0) * (A - B)) / 2.0;
        complexArr[1] = new Complex(Re_x2, Im_x2);

        double Re_x3 = -((A + B) / 2.0) - (b / (3.0 * a));
        double Im_x3 = (Math.Sqrt(3.0) * (A - B)) / 2.0;
        complexArr[2] = new Complex(Re_x3, -Im_x3);
      }

      if (Q == 0) {
        double y1 = 2 * A;
        double y2 = -A;

        complexArr[0] = y1 - b / (3 * a);
        complexArr[1] = y2 - b / (3 * a);
        complexArr[2] = complexArr[1];
      }
      return complexArr;
    }
  }
}
