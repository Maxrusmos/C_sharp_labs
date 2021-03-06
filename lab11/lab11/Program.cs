﻿using System;
using ComplexOp;
using VectorOp;

namespace lab11 {
  class Program {
    static void Main(string[] args) {
      //подписываем метод на событие
      ComplexNum division = new ComplexNum();
      ComplexNum.DivisionZero += (obj) => {
        Console.WriteLine(obj);
        Environment.Exit(1);
      };

      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("Комплексные числа: ");
      var A = new ComplexNum(1.0, 2.0);
      var B = new ComplexNum(2.0, 4.45);
      var C = new ComplexNum(10.11, 0.0);
      var D = new ComplexNum(1.12345678912345678, 1.0);
      var E = new ComplexNum(10.23, 11.3476);
      Console.WriteLine("A = " + A.ToString());
      Console.WriteLine("B = " + B.ToString());
      Console.WriteLine("C = " + C.ToString());
      Console.WriteLine("D = " + D.ToString());
      Console.WriteLine("E = " + E.ToString());

      Console.WriteLine(Environment.NewLine);
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Операции с комплексными числами: ");
      Console.WriteLine("A + B = " + (A + B).ToString());
      Console.WriteLine("E - C = " + (E - C).ToString());
      Console.WriteLine("A * E = " + (A * E).ToString());
      try {
        Console.WriteLine("D / C = " + (D / C).ToString());
      }
      catch (ArgumentException ex) {
        Console.WriteLine(ex.Message);
      }
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("|C| = " + ComplexNum.ComplexAbs(C).ToString());
      Console.WriteLine("A^6 = " + ComplexNum.ComplexPow(A, 6).ToString());
      Console.WriteLine("arg(B) = " + ComplexNum.ComplexArgument(B).ToString());
      Console.Write("D^(1/12): ");
      for (int i = 0; i < ComplexNum.ComplexSqrtN(D, 12).Length; i++) {
        if (i == 0) {
          Console.WriteLine("" + ComplexNum.ComplexSqrtN(D, 12)[i]);
        } else {
          Console.WriteLine("          " + ComplexNum.ComplexSqrtN(D, 12)[i]);
        }
      }

      Console.WriteLine(Environment.NewLine + "-----------------------------------------------------------" + Environment.NewLine);

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Векторы из действительных чисел: ");
      var doubleArr_1 = new double[4] { 3.0, 2.0, 1.0, 1.0 };
      var doubleArr_2 = new double[4] { 3.0, 3.0, 1.0, 2.0 };
      var doubleArr_3 = new double[4] { 1.0, 2.0, 1.0, 2.0 };
      //var intArr_1 = new int[3] { 4, 1, 2 };
      //var intArr_2 = new int[3] { 3, 1, 2 };
      var doubleVector_1 = new Vector<double>(doubleArr_1);
      var doubleVector_2 = new Vector<double>(doubleArr_2);
      var doubleVector_3 = new Vector<double>(doubleArr_3);
      //var intVector_1 = new Vector<int>(intArr_1);
      //var intVector_2 = new Vector<int>(intArr_2);
      var doubleVectorArr = new Vector<double>[3] { doubleVector_1, doubleVector_2, doubleVector_3 };
      //Console.WriteLine(Vector<int>.Compare(intVector_1, intVector_2));
      Console.WriteLine("V1 = " + doubleVector_1.ToString());
      Console.WriteLine("V2 = " + doubleVector_2.ToString());
      Console.WriteLine("V2 = " + doubleVector_3.ToString());

      Console.WriteLine(Environment.NewLine);
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Операции с векторами: ");
      Console.WriteLine("V1 + V2 = " + (doubleVector_1 + doubleVector_2).ToString());
      Console.WriteLine("V1 - V2 = " + (doubleVector_1 - doubleVector_2).ToString());
      Console.WriteLine("V1 * 52 = " + (doubleVector_1 * 52).ToString());
      Console.WriteLine("V1 * V2 = " + (doubleVector_1 * doubleVector_2).ToString());
      Console.WriteLine("|V1| = " + Vector<double>.VectorAbs(doubleVector_1).ToString());
      Console.Write("Ортогонализация системы векторов (V1, V2, V3): ");
      for (int i = 0; i < Vector<double>.VectorOrthogonalization(doubleVectorArr).Length; i++) {
        if (i == 0) {
          Console.WriteLine(Vector<double>.VectorOrthogonalization(doubleVectorArr)[i]);
        } else {
          Console.WriteLine("                                           " + 
                  Vector<double>.VectorOrthogonalization(doubleVectorArr)[i]);
        }
      }

      Console.WriteLine(Environment.NewLine + "-----------------------------------------------------------" + Environment.NewLine);

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Векторы из комплексных чисел: ");
      var complexArr_1 = new ComplexNum[5] { A, B, C, D, E };
      var complexArr_2 = new ComplexNum[5] { B, C, E, A, A };
      var complexVector_1 = new Vector<ComplexNum>(complexArr_1);
      var complexVector_2 = new Vector<ComplexNum>(complexArr_2);
      var complexVectorArr = new Vector<ComplexNum>[2] { complexVector_1, complexVector_2 };
      Console.WriteLine("CV1 = " + complexVector_1.ToString());
      Console.WriteLine("CV2 = " + complexVector_2.ToString());

      Console.WriteLine(Environment.NewLine);
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Операции с векторами: ");
      Console.WriteLine("CV1 + CV2 = " + (complexVector_1 + complexVector_2).ToString());
      Console.WriteLine("CV1 - CV2 = " + (complexVector_1 - complexVector_2).ToString());
      Console.WriteLine("CV1 * 52 = " + (complexVector_1 * new ComplexNum(52.0, 0.0)).ToString());
      Console.WriteLine("CV1 * CV2 = " + (complexVector_1 * complexVector_2).ToString());
      Console.WriteLine("|CV1| = " + Vector<ComplexNum>.VectorAbs(complexVector_1).ToString());
      Console.Write("Ортогонализация системы векторов (CV1, CV2): ");
      for (int i = 0; i < Vector<ComplexNum>.VectorOrthogonalization(complexVectorArr).Length; i++) {
        if (i == 0) {
          Console.WriteLine(Vector<ComplexNum>.VectorOrthogonalization(complexVectorArr)[i]);
        } else {
          Console.WriteLine("                                             " +
                  Vector<ComplexNum>.VectorOrthogonalization(complexVectorArr)[i]);
        }
      }
    }
  }
}
