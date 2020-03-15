using System;
using ComplexOp;
using EventCustomOp;

namespace lab11 {
  class Program {
    static void Main(string[] args) {
      var A = new ComplexNum(-4, 0);
      var B = new ComplexNum(0, 0);
      ComplexNum division = new ComplexNum();
      ComplexNum.DivisionZero += ComplexNum.ShowMessage;
      Console.WriteLine((A / B).ToString());
    }
  }
}
