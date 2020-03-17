using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ComplexOp;
using System.Linq;

namespace VectorOp {
  class Vector<T> {
    private T _x;
    private T _y;
    private T _z;

    public Vector() { }

    public Vector(T x, T y, T z) {
      _x = x;
      _y = y;
      _z = z;
    }

    //сумма
    public static Vector<T> VectorSum(Vector<T> A, Vector<T> B) {
      var resultVector = new Vector<T>();
      resultVector._x = (dynamic)A._x + (dynamic)B._x;
      resultVector._y = (dynamic)A._y + (dynamic)B._y;
      resultVector._z = (dynamic)A._z + (dynamic)B._z;
      return resultVector;
    }

    public static Vector<T> operator +(Vector<T> A, Vector<T> B) {
      return VectorSum(A, B);
    }

    //разность
    public static Vector<T> VectorDifference(Vector<T> A, Vector<T> B) {
      var resultVector = new Vector<T>();
      resultVector._x = (dynamic)A._x - (dynamic)B._x;
      resultVector._y = (dynamic)A._y - (dynamic)B._y;
      resultVector._z = (dynamic)A._z - (dynamic)B._z;
      return resultVector;
    }

    public static Vector<T> operator -(Vector<T> A, Vector<T> B) {
      return VectorDifference(A, B);
    }

    //векторное произведение
    public static Vector<T> VectorMultiplication(Vector<T> A, Vector<T> B) {
      var resultVector = new Vector<T>();
      resultVector._x = (dynamic)A._y * B._z - (dynamic)A._z * B._y;
      resultVector._y = (dynamic)A._z * B._x - (dynamic)A._x * B._z;
      resultVector._z = (dynamic)A._x * B._y - (dynamic)A._y * B._x;
      return resultVector;
    }

    public static Vector<T> operator *(Vector<T> A, Vector<T> B) {
      return VectorMultiplication(A, B);
    }

    //произведение вектора и числа
    public static Vector<T> VectorMultiplicationNum(Vector<T> A, dynamic num) {
      var resultVector = new Vector<T>();
      resultVector._x = (dynamic)A._x * num;
      resultVector._y = (dynamic)A._y * num;
      resultVector._z = (dynamic)A._z * num;
      return resultVector;
    }

    //модуль
    public static dynamic VectorAbs(Vector<T> A) {
      dynamic result;
      if (((dynamic)A._x * A._x + (dynamic)A._y * A._y + (dynamic)A._z * A._z) is ComplexNum) {
        result = ComplexNum.ComplexSqrtN((dynamic)A._x * A._x + (dynamic)A._y * A._y + (dynamic)A._z * A._z, 2)[0]; //если под корнем комплексное, то возвращаем одно значение
      } else {
        result = Math.Sqrt((dynamic)A._x * A._x + (dynamic)A._y * A._y + (dynamic)A._z * A._z);
      }
      return result;
    }

    //скалярное произведение
    public static dynamic VectorScalarProduct(Vector<T> A, Vector<T> B) {
      return (dynamic)A._x * B._x + (dynamic)A._y * B._y + (dynamic)A._z * B._z;
    }

    //ортогонализация 
    public static dynamic VectorOrthogonalization(Vector<T>[] A) {
      var tmpVector = new Vector<T>();
      var sumVector = new Vector<T>();
      var bj = new Vector<T>[A.Length];
      bj[0] = A[0];
      for (int i = 1; i < A.Length; i++) {
        for (int j = 0; j < i; j++) {
          dynamic k = VectorScalarProduct(A[i], bj[j]) / VectorScalarProduct(bj[j], bj[j]);
          sumVector -= VectorMultiplicationNum(bj[j], k);
        }
        bj[i] = A[i] + sumVector;
        sumVector = tmpVector;
      }
      return bj;
    }

    public static implicit operator T[](Vector<T> A) {
      var list = new List<T>();
      list.Add(A._x);
      list.Add(A._y);
      list.Add(A._z);
      var array = list.Select(n => n).ToArray();
      return array;
    }

    public static implicit operator Vector<T>(T[] Arr) {
      var vector = new Vector<T>();
      vector._x = Arr[0];
      vector._y = Arr[1];
      vector._z = Arr[2];
      return vector;
    }

    //вывод
    public override string ToString() {
      return "vector(" + _x + ",  " + _y + ",  " + _z + ")";
    }
  }
}
