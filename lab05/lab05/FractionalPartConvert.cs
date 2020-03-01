using System;
using WholePartConvert;

namespace FractionalPartConvert {
  public static class FractionalPartConvert {
    private static string SearchPeriod(string fractionalPart) {

      return "";
    }

    public static string FToNS(double fractionalNumber, int numBase) {
      var tmpNum = 1.0;
      var result = "";

      int discharge = 0;
      while (discharge != 14 || fractionalNumber == 0.0) {
        tmpNum = fractionalNumber * numBase;
        result = result + WholePartConvert.WholePartConvert.correct(int.Parse(Convert.ToString(tmpNum).Split(',')[0])); //result + целая часть
        fractionalNumber = double.Parse("0," + Convert.ToString(tmpNum).Split(',')[1]);
        discharge++;
      }
      return result;
    }
  }
}
