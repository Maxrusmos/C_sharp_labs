using System;
using ComplexOp;
using EventCustomOp;
using VectorOp;

namespace lab11 {
  class Program {
    static void Main(string[] args) {
      var A = new ComplexNum(1.0, 2.0);
      var B = new ComplexNum(1.5, 3.0);

      //подписываем метод на событие
      //ComplexNum division = new ComplexNum();
      //ComplexNum.DivisionZero += ComplexNum.ShowMessage;
      //Console.WriteLine((A / B).ToString());

      Vector<ComplexNum> complexVector1 = new Vector<ComplexNum>(A, B);
      Vector<ComplexNum> complexVector2 = new Vector<ComplexNum>(B, A);
      Console.WriteLine(Vector<ComplexNum>.VectorSum(complexVector1, complexVector2).ToString());
    }
  }
}
