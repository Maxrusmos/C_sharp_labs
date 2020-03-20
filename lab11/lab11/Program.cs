using System;
using ComplexOp;
using EventCustomOp;
using VectorOp;

namespace lab11 {
  class Program {
    static void Main(string[] args) {
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("Комплексные числа: ");
      var A = new ComplexNum(1.0, 2.0);
      var B = new ComplexNum(2.0, 4.45);
      var C = new ComplexNum(-2.0, 5.0);
      var D = new ComplexNum(9.1, 3.1);
      var E = new ComplexNum(5.0, 8.1);
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
      Console.WriteLine("D / C = " + (D / C).ToString());
      Console.WriteLine("|C| = " + ComplexNum.ComplexAbs(C).ToString());
      Console.WriteLine("A^6 = " + ComplexNum.ComplexPow(A, 6).ToString());
      Console.WriteLine("arg(B) = " + ComplexNum.ComplexArgument(B).ToString());
      Console.Write("D^(1/7): ");
      for (int i = 0; i < ComplexNum.ComplexSqrtN(D, 7).Length; i++) {
        if (i == 0) {
          Console.WriteLine("" + ComplexNum.ComplexSqrtN(D, 7)[i]);
        } else {
          Console.WriteLine("         " + ComplexNum.ComplexSqrtN(D, 7)[i]);
        }
      }

      Console.WriteLine(Environment.NewLine + Environment.NewLine);
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Векторы из целых чисел: ");
      var intArr_1 = new int[3] { 3, -1, 9 };
      var intArr_2 = new int[3] { 5, 8, -8 };
      var intVector_1 = new Vector<int>(intArr_1);
      var intVector_2 = new Vector<int>(intArr_2);
      Console.WriteLine("intVector_1 = " + intVector_1.ToString());
      Console.WriteLine("intVector_2 = " + intVector_2.ToString());




      //подписываем метод на событие
      //ComplexNum division = new ComplexNum();
      //ComplexNum.DivisionZero += ComplexNum.ShowMessage;
      //Console.WriteLine((A / B).ToString());
      //Console.WriteLine(A.ToString());

      var complexArr_1 = new ComplexNum[5] { A, B, C, D, E };
      var complexArr_2 = new ComplexNum[5] { B, C, E, A, A };

      var vector1 = new Vector<ComplexNum>(complexArr_1);
      var vector2 = new Vector<ComplexNum>(complexArr_2);
     // Console.WriteLine((vector1 * vector2).ToString());
    }
  }
}
