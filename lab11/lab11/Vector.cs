using System;
using System.Collections.Generic;
using System.Text;
using ComplexOp;
using System.Linq;
using System.Collections;

namespace VectorOp {
  class Vector<T> : IComparable, IComparable<Vector<T>> where T: IComparable, new(){
    private T[] _coordsArr; //массив координат вектора

    public Vector() { }

    public Vector(T[] A) {
      _coordsArr = new T[A.Length];
      for (int i = 0; i < A.Length; i++) {
        _coordsArr[i] = (dynamic)A[i];
      }
    }

    public int CompareTo(Vector<T> B) {
      return VectorAbs(this).CompareTo(VectorAbs(B));
    }

    //массив нулей
    private static T[] MakeZeroArr(Vector<T> A) {
      return Enumerable.Repeat(new T(), A._coordsArr.Length).ToArray();
    }

    private static void ThrowIfLengthsNotEqual(Vector<T> A, Vector<T> B) {
      if (A._coordsArr.Length != B._coordsArr.Length) {
        throw new Exception("Длины векторов не совпадают");
      }
    }

    //сумма
    public static Vector<T> VectorSum(Vector<T> A, Vector<T> B) {
      ThrowIfLengthsNotEqual(A, B);
      var zeroVector = MakeZeroArr(A);
      var resultVector = new Vector<T>(zeroVector);
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
      ThrowIfLengthsNotEqual(A, B);
      var zeroArr = MakeZeroArr(A);
      var resultVector = new Vector<T>(zeroArr);
      for (int i = 0; i < A._coordsArr.Length; i++) {
        resultVector._coordsArr[i] = (dynamic)A._coordsArr[i] - (dynamic)B._coordsArr[i];
      }
      return resultVector;
    }

    public static Vector<T> operator -(Vector<T> A, Vector<T> B) {
      return VectorDifference(A, B);
    }

    //произведение вектора и числа
    public static Vector<T> VectorMultiplicationNum(Vector<T> A, T num) {
      var zeroArr = MakeZeroArr(A);
      var resultVector = new Vector<T>(zeroArr);
      for (int i = 0; i < A._coordsArr.Length; i++) {
        resultVector._coordsArr[i] = (dynamic)A._coordsArr[i] * num; 
      }
      return resultVector;
    }

    public static Vector<T> operator *(Vector<T> A, T num) {
      return VectorMultiplicationNum(A, num);
    }

    //модуль
    public static T VectorAbs(Vector<T> A) {
      var result = new T();   
      for (int i = 0; i < A._coordsArr.Length; i++) {
        result += (dynamic)A._coordsArr[i] * A._coordsArr[i]; 
      }
      if (result is ComplexNum) {
        return ComplexNum.ComplexSqrtN((dynamic)result, 2)[0];
      } else {
        return Math.Sqrt((dynamic)result);
      }     
    }

    //скалярное произведение
    public static T VectorScalarProduct(Vector<T> A, Vector<T> B) {
      var result = new T();
      for (int i = 0; i < A._coordsArr.Length; i++) {
        result += (dynamic)A._coordsArr[i] * (dynamic)B._coordsArr[i];
      }
      return result;
    }

    public static T operator *(Vector<T> A, Vector<T> B) {
      return VectorScalarProduct(A, B);
    }

    //ортогонализация 
    public static Vector<T>[] VectorOrthogonalization(Vector<T>[] A) {
      var bj = new Vector<T>[A.Length];
      bj[0] = A[0];
      for (int i = 1; i < A.Length; i++) {
        var zeroArr = MakeZeroArr(A[i]);
        var tmpVector = new Vector<T>(zeroArr);
        var sumVector = new Vector<T>(zeroArr);
        for (int j = 0; j < i; j++) {
          T k = (dynamic)(A[i] * bj[j]) / (bj[j] * bj[j]);
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
      return list.ToArray();
    }

    //из вектора в массив
    public static implicit operator Vector<T>(T[] Arr) {
      var vector = new Vector<T>(Arr);
      return vector;
    }

    //вывод
    public override string ToString() {
      StringBuilder str = new StringBuilder("vector(");
      for (int i = 0; i < _coordsArr.Length; i++) {
        str.Append("  ").Append(_coordsArr[i]).Append("  ");
      }
      return  str + ")";
    }

    int IComparable.CompareTo(object obj) {
      if (!(obj is Vector<T>)) {
        throw new ArgumentException("Это не вектор", nameof(obj));
      }
      return CompareTo((Vector<T>)obj);
    }
  }
}
