using System;
using ComplexOp;
using EventCustomOp;
using VectorOp;

namespace lab11 {
  class Program {
    static void Main(string[] args) {
      var A = new ComplexNum(1.0, 2.0);
      var B = new ComplexNum(2.0, 5.0);

      //подписываем метод на событие
      //ComplexNum division = new ComplexNum();
      //ComplexNum.DivisionZero += ComplexNum.ShowMessage;
      //Console.WriteLine((A / B).ToString());
      //Console.WriteLine(A.ToString());

      Vector<int> complexVector1 = new Vector<int>(3, 2, 2);
      Vector<ComplexNum> complexVector2 = new Vector<ComplexNum>(B, A, A);
      Console.WriteLine(Vector<ComplexNum>.VectorAbs(complexVector2).ToString());
      Console.WriteLine(complexVector2.ToString());
    }
  }
}
