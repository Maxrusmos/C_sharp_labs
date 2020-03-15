using System;
using ComplexOp;
using EventCustomOp;

namespace lab11 {
  class Program {
    static void Main(string[] args) {
      var A = new ComplexNum(2, 4);
      var B = new ComplexNum(3, 2);
      Console.WriteLine(ComplexNum.ComplexPow(A, 5).ToString());
    }
  }
}
