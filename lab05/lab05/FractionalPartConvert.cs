using System;
using WholePartConvert;

namespace FractionalPartConvert {
  public static class FractionalPartConvert {
    public static string FToNS(double fractionalNumber, int numBase) {
      //для проверки пользоваться методом коррект из другого класса
      var tmpNum = 1.0;
      var result = "";

      int discharge = 0;
      while (discharge != 14) {
        tmpNum = fractionalNumber * numBase;
        result = result + WholePartConvert.WholePartConvert.correct(int.Parse(Convert.ToString(tmpNum).Split(',')[0])); //result + целая часть
        fractionalNumber = double.Parse("0," + Convert.ToString(tmpNum).Split(',')[1]);
        discharge++;
      }
      return result;
    }
  }
}
