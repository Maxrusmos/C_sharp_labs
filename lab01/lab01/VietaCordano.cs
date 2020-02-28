using System;
using System.Numerics;

namespace VietaCordano {
  public class VietaCordano {
    static public Complex[] VietaCordanoMethod(double a, double b, double c, double d) {
      Complex[] complexArr = new Complex[3]; 

      double a_1 = b / a;
      double b_1 = c / a;
      double c_1 = d / a;

      double Q = (a_1 * a_1 - 3.0 * b_1) / 9.0;
      double R = (2 * Math.Pow(a_1, 3.0) - 9.0 * a_1 * b_1 + 27.0 * c_1) / 54.0;

      if (R * R < Math.Pow(Q, 3)) {
        double t = Math.Acos(R / Math.Sqrt(Math.Pow(Q, 3.0))) / 3.0;
        complexArr[0] = -2 * Math.Sqrt(Q) * (Math.Cos(t)) - (a_1 / 3.0);
        complexArr[1] = -2 * Math.Sqrt(Q) * (Math.Cos(t + (2.0 * Math.PI / 3.0))) - (a_1 / 3.0);
        complexArr[2] = -2 * Math.Sqrt(Q) * (Math.Cos(t - (2.0 * Math.PI / 3.0))) - (a_1 / 3.0);
      }

      if (R * R >= Math.Pow(Q, 3)) {
        double A = -Math.Sign(R) * (Math.Pow(Math.Abs(R) + Math.Sqrt(R * R - Math.Pow(Q, 3.0)), 1.0 / 3.0));
        double B;

        if (A == 0) {
          B = 0;
        } else {
          B = Q / A;
        }

        complexArr[0] = (A + B) - (a_1 / 3.0); 

        if (A == B) {
          complexArr[1] = -A - (a_1 / 3);
          complexArr[2] = complexArr[1];
        } else {
          double Re_x2 = -((A + B) / 2.0) - (a_1 / 3.0);
          double Im_x2 = (Math.Sqrt(3.0) * (A - B)) / 2.0;
          complexArr[1] = new Complex(Re_x2, Im_x2);

          double Re_x3 = -((A + B) / 2.0) - (a_1 / 3.0);
          double Im_x3 = (Math.Sqrt(3.0) * (A - B)) / 2.0;
          complexArr[2] = new Complex(Re_x3, -Im_x3);
        }
      }
      return complexArr;
    }
  }
}
