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

      var intArr = new int[4] { 1, 2, 2, -1 };

      Vector<int> complexVector1 = new Vector<int>(3, 2, 2);
      Vector<ComplexNum> complexVector2 = new Vector<ComplexNum>(B, A, A);

      Console.WriteLine(Vector<int>.kek(complexVector1));



      var myVectorArr = new Vector<double>[3];
      myVectorArr[0] = new Vector<double>(1, 0, 1);
      myVectorArr[1] = new Vector<double>(-1, 1, 0);
      myVectorArr[2] = new Vector<double>(0, 2, 1);

      Console.WriteLine(Vector<double>.VectorOrthogonalization(myVectorArr)[2].ToString());
    }
  }
}
