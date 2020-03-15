using System;
using System.Collections.Generic;
using System.Text;

namespace VectorOp {
  class Vector<T> {
    public T _x;
    public T _y;

    public Vector() { }

    public Vector(T x, T y) {
      this._x = x;
      this._y = y;
    }

    //сумма
    public static Vector<T> VectorSum(Vector<T> A, Vector<T> B) {
      var resultVector = new Vector<T>();
      resultVector._x = (T)Convert.ChangeType((dynamic)A._x + (dynamic)B._x, typeof(T));
      resultVector._y = (T)Convert.ChangeType((dynamic)A._y + (dynamic)B._y, typeof(T));
      return resultVector;
    }

    //вывод
    public override string ToString() {
      return "vector(" + this._x + ",  " + this._y + ")";
    }
  }
}
