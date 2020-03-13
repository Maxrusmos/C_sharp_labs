using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayParseOp {
  public class ArrayParse {
    public static int SearchMaxElem(int[] powerArr) {
      var maxValue = 0;
      for (int i = 0; i < powerArr.Length; i++) {
        if (powerArr[i] > maxValue) {
          maxValue = powerArr[i];
        }
      }
      return maxValue;
    }

    public static double[] FillArr(int size, double[] koefArr) {
      var arrKoefResultSize = new double[size];
      for (int i = 0; i < koefArr.Length; i++) {
        arrKoefResultSize[i] = koefArr[i];
      }
      return arrKoefResultSize;
    }

    public static double[] SwapFirst(int maxFirst, int maxSecond, double[] arrKoefFirst, double[] tmpArr) {
      for (int i = 0; i < arrKoefFirst.Length; i++) {
        if (maxFirst > maxSecond) {
          arrKoefFirst[i] = tmpArr[i];
        } else {
          if (i < Math.Abs(maxFirst - maxSecond)) {
            arrKoefFirst[i] = 0;
          } else {
            arrKoefFirst[i] = tmpArr[i - Math.Abs(maxFirst - maxSecond)];
          }
        }
      }
      return arrKoefFirst;
    }

    public static double[] SwapSecond(int maxFirst, int maxSecond, double[] arrKoefSecond, double[] tmpArr1) {
      for (int i = 0; i < arrKoefSecond.Length; i++) {
        if (maxSecond > maxFirst) {
          arrKoefSecond[i] = tmpArr1[i];
        } else {
          if (i < Math.Abs(maxFirst - maxSecond)) {
            arrKoefSecond[i] = 0;
          } else {
            arrKoefSecond[i] = tmpArr1[i - Math.Abs(maxFirst - maxSecond)];
          }
        }
      }
      return arrKoefSecond;
    }
  }
}
