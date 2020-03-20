using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ComplexOp;
using System.Linq;

namespace VectorOp {
  class Vector<T> {
    private T[] _coordsArr;

    public Vector() { }

    public Vector(T[] A) {
      _coordsArr = new T[A.Length];
      for (int i = 0; i < A.Length; i++) {
        _coordsArr[i] = (dynamic)A[i];
      }
    }

    //сумма
    public static Vector<T> VectorSum(Vector<T> A, Vector<T> B) {
      var resultVector = new Vector<T>();
      for (int i = 0; i < A._coordsArr.Length; i++) {
        resultVector._coordsArr[i] = (dynamic)A._coordsArr[i] + (dynamic)B._coordsArr[i];
      }
      return resultVector;
    }

    public static Vector<T> operator +(Vector<T> A, Vector<T> B) {
      return VectorSum(A, B);
    }

    //разность
    public static Vector<T> VectorDifference(Vector<T> A, Vector<T> B) {
      var resultVector = new Vector<T>();
      for (int i = 0; i < A._coordsArr.Length; i++) {
        resultVector._coordsArr[i] = (dynamic)A._coordsArr[i] - (dynamic)B._coordsArr[i];
      }
      return resultVector;
    }

    public static Vector<T> operator -(Vector<T> A, Vector<T> B) {
      return VectorDifference(A, B);
    }

    //произведение вектора и числа
    public static Vector<T> VectorMultiplicationNum(Vector<T> A, dynamic num) {
      var resultVector = new Vector<T>();
      for (int i = 0; i < A._coordsArr.Length; i++) {
        resultVector._coordsArr[i] = (dynamic)A._coordsArr[i] * num;
      }
      return resultVector;
    }

    //модуль
    public static dynamic VectorAbs(Vector<T> A) {
      dynamic result;
      if (A._coordsArr is ComplexNum[]) {
        result = new ComplexNum(0.0, 0.0);
      } else {
        result = 0.0;
      }
      for (int i = 0; i < A._coordsArr.Length; i++) {
        result += (dynamic)A._coordsArr[i] * A._coordsArr[i]; 
      }
      if (result is ComplexNum) {
        return ComplexNum.ComplexSqrtN(result, 2)[0];
      } else {
        return Math.Sqrt(result);
      }     
    }

    //скалярное произведение
    public static dynamic VectorScalarProduct(Vector<T> A, Vector<T> B) {
      dynamic result;
      if (A._coordsArr is ComplexNum[]) {
        result = new ComplexNum(0.0, 0.0);
      } else {
        result = 0.0;
      }
      for (int i = 0; i < A._coordsArr.Length; i++) {
        result += (dynamic)A._coordsArr[i] * (dynamic)B._coordsArr[i];
      }
      return result;
    }

    public static dynamic operator *(Vector<T> A, Vector<T> B) {
      return VectorScalarProduct(A, B);
    }

    //ортогонализация 
    public static dynamic VectorOrthogonalization(Vector<T>[] A) {
      var tmpVector = new Vector<T>();
      var sumVector = new Vector<T>();
      var bj = new Vector<T>[A.Length];
      bj[0] = A[0];
      for (int i = 1; i < A.Length; i++) {
        for (int j = 0; j < i; j++) {
          dynamic k = (A[i] * bj[j]) / (bj[j] * bj[j]);
          sumVector -= VectorMultiplicationNum(bj[j], k);
        }
        bj[i] = A[i] + sumVector;
        sumVector = tmpVector;
      }
      return bj;
    }
    
    //в массив из вектора
    public static implicit operator T[](Vector<T> A) {
      var list = new List<T>();
      for (int i = 0; i < A._coordsArr.Length; i++) {
        list.Add(A._coordsArr[i]);
      }
      var array = list.Select(n => n).ToArray();
      return array;
    }

    //в вектора в массив
    public static implicit operator Vector<T>(T[] Arr) {
      var vector = new Vector<T>();
      for (int i = 0; i < Arr.Length; i++) {
        vector._coordsArr[i] = Arr[i];
      }
      return vector;
    }

    //вывод
    public override string ToString() {
      StringBuilder str = new StringBuilder();
      for (int i = 0; i < _coordsArr.Length; i++) {
        str.Append("  " + _coordsArr[i] + "  ");
      }
      return "vector(" + str + ")";
    }
  }
}
