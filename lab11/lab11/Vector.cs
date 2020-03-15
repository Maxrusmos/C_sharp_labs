using System;
using System.Collections.Generic;
using System.Text;
using ComplexOp;

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
      resultVector._x = (T)Convert.ChangeType((dynamic)A._x + (dynamic)B._x, typeof(T));
      resultVector._y = (T)Convert.ChangeType((dynamic)A._y + (dynamic)B._y, typeof(T));
      resultVector._z = (T)Convert.ChangeType((dynamic)A._z + (dynamic)B._z, typeof(T));
      return resultVector;
    }

    public static Vector<T> operator +(Vector<T> A, Vector<T> B) {
      return VectorSum(A, B);
    }

    //разность
    public static Vector<T> VectorDifference(Vector<T> A, Vector<T> B) {
      var resultVector = new Vector<T>();
      resultVector._x = (T)Convert.ChangeType((dynamic)A._x - (dynamic)B._x, typeof(T));
      resultVector._y = (T)Convert.ChangeType((dynamic)A._y - (dynamic)B._y, typeof(T));
      resultVector._z = (T)Convert.ChangeType((dynamic)A._z - (dynamic)B._z, typeof(T));
      return resultVector;
    }

    public static Vector<T> operator -(Vector<T> A, Vector<T> B) {
      return VectorDifference(A, B);
    }

    //произведение
    public static Vector<T> VectorComposition(Vector<T> A, Vector<T> B) {
      var resultVector = new Vector<T>();
      resultVector._x = (T)Convert.ChangeType((dynamic)A._y * (dynamic)B._z - (dynamic)A._z * (dynamic)B._y, typeof(T));
      resultVector._y = (T)Convert.ChangeType((dynamic)A._z * (dynamic)B._x - (dynamic)A._x * (dynamic)B._z, typeof(T));
      resultVector._z = (T)Convert.ChangeType((dynamic)A._x * (dynamic)B._y - (dynamic)A._y * (dynamic)B._x, typeof(T));
      return resultVector;
    }

    public static Vector<T> operator *(Vector<T> A, Vector<T> B) {
      return VectorComposition(A, B);
    }

    //модуль
    public static dynamic VectorAbs(Vector<T> A) {
      dynamic result; 
      if (((dynamic)A._x * (dynamic)A._x + (dynamic)A._y * (dynamic)A._y + (dynamic)A._z * (dynamic)A._z) is ComplexNum) {
        result = ComplexNum.ComplexSqrtN((dynamic)A._x * (dynamic)A._x + (dynamic)A._y * (dynamic)A._y + (dynamic)A._z * (dynamic)A._z, 2)[0];
      } else {
        result = Math.Sqrt((dynamic)A._x * (dynamic)A._x + (dynamic)A._y * (dynamic)A._y + (dynamic)A._z * (dynamic)A._z);
      }
      return result;
    }

    //скалярное произведение
    public static dynamic VectorScalarProduct(Vector<T> A, Vector<T> B) {
      return (dynamic)A._x * (dynamic)B._x + (dynamic)A._y * (dynamic)B._y + (dynamic)A._z * (dynamic)B._z;
    }

    ////ортогонализация 
    //public static dynamic VectorOrthogonalization() {

    //}

    //вывод
    public override string ToString() {
      return "vector(" + _x + ";  " + _y + ";  " + _z + ")";
    }
  }
}
