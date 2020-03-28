using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using MatrixOp;

namespace PolynomOp {
  class  Polynom<T>: ICloneable, IEnumerable, IEnumerable<T>, IComparable, IComparable<Polynom<T>> where T : IComparable, new(){

    private Dictionary<int, T> _polynomDictionary = new Dictionary<int, T>();

    public Polynom() { }

    public Polynom(int power, params T[] koefArr) {
      for (int i = power; i >= 0; i--) {
        _polynomDictionary.Add(i, koefArr[power - i]);
      }
    }

    public Polynom(T[] koefArr) {
      for (int i = koefArr.Length - 1; i >= 0; i--) {
        _polynomDictionary.Add(i, koefArr[koefArr.Length - 1 - i]);
      }
    }

    public Polynom(Dictionary<int, T> dict) {
      foreach (var kvp in dict) {
        _polynomDictionary.Add(kvp.Key, kvp.Value);
      }
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return _polynomDictionary.Values.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator() {
      return _polynomDictionary.Values.GetEnumerator();
    }

    public object Clone() {
      Dictionary<int, T > cloneDictionary = new Dictionary<int, T>(_polynomDictionary.Count);
      foreach (var kvp in _polynomDictionary) {
        cloneDictionary.Add(kvp.Key, kvp.Value);
      }
      return cloneDictionary;
    }

    public int CompareTo(Polynom<T> A) {
      return _polynomDictionary.Keys.Max().CompareTo(A._polynomDictionary.Keys.Max());
    }

    int IComparable.CompareTo(object obj) {
      if (obj is null) {
        throw new ArgumentNullException("NULL", nameof(obj));
      }
      if (!(obj is Polynom<T>)) {
        throw new ArgumentException("Это не полином", nameof(obj));
      }
      return CompareTo((Polynom<T>)obj);
    }

    //Словарь из нулей
    private static Dictionary<int, T> MakeZeroDict(Polynom<T> A) {
      var resultDictionary = new Dictionary<int, T>(A._polynomDictionary.Count);
      foreach (var kvp in A._polynomDictionary) {
        resultDictionary.Add(kvp.Key, new T());
      }
      return resultDictionary;
    }

    //наибольший полином из двух
    private static Polynom<T> SearchMaxPolynom(Polynom<T> A, Polynom<T> B) {
      if (A.CompareTo(B) < 0) {
        return B;
      } else if (A.CompareTo(B) > 0) {
        return A;
      } else {
        return A;
      }
    }

    //наимеьший полином из двух
    private static Polynom<T> SearchMinPolynom(Polynom<T> A, Polynom<T> B) {
      if (A.CompareTo(B) < 0) {
        return A;
      } else if (A.CompareTo(B) > 0) {
        return B;
      } else {
        return A;
      }
    }

    //сумма полиномов
    public static Polynom<T> PolynomSum(Polynom<T> A, Polynom<T> B) {
      var maxPolynom = SearchMaxPolynom(A, B);
      var resultPolynom = new Polynom<T>(MakeZeroDict(maxPolynom));
      for (int i = 0; i < maxPolynom._polynomDictionary.Count; i++) {
        if (SearchMinPolynom(A, B)._polynomDictionary.ContainsKey(i)) {
          resultPolynom._polynomDictionary[i] = (dynamic)A._polynomDictionary[i] + B._polynomDictionary[i];
        } else {
          resultPolynom._polynomDictionary[i] = maxPolynom._polynomDictionary[i];
        }
      }
      return resultPolynom;
    }

    public static Polynom<T> operator +(Polynom<T> A, Polynom<T> B) {
      return PolynomSum(A, B);
    }

    //разность полиномов
    public static Polynom<T> PolynomDifference(Polynom<T> A, Polynom<T> B) {
      var maxPolynom = SearchMaxPolynom(A, B);
      var resultPolynom = new Polynom<T>(MakeZeroDict(maxPolynom));
      for (int i = 0; i < maxPolynom._polynomDictionary.Count; i++) {
        if (!A._polynomDictionary.ContainsKey(i)) {
          resultPolynom._polynomDictionary[i] = (dynamic)(-1) * B._polynomDictionary[i];
        } else if (!B._polynomDictionary.ContainsKey(i)) {
          resultPolynom._polynomDictionary[i] = A._polynomDictionary[i];
        } else {
          resultPolynom._polynomDictionary[i] = (dynamic)A._polynomDictionary[i] - (dynamic)B._polynomDictionary[i];
        }
      }
      return resultPolynom;
    }

    public static Polynom<T> operator -(Polynom<T> A, Polynom<T> B) {
      return PolynomDifference(A, B);
    }

    //произведение полиномов
    public static Polynom<T> PolynomComposition(Polynom<T> A, Polynom<T> B) {
      var maxPolynom = SearchMaxPolynom(A, B);
      var resultPolynom = new Polynom<T>();
      for (int i = 0; i < A._polynomDictionary.Count; i++) {
        for (int j = 0; j < B._polynomDictionary.Count; j++) {
          if (resultPolynom._polynomDictionary.ContainsKey(i + j)) {
            resultPolynom._polynomDictionary[i + j] += (dynamic)A._polynomDictionary[i] * B._polynomDictionary[j];
          } else {
            resultPolynom._polynomDictionary.Add(i + j, (dynamic)A._polynomDictionary[i] * B._polynomDictionary[j]);
          }
        }
      }
      return resultPolynom;
    }

    public static Polynom<T> operator *(Polynom<T> A, Polynom<T> B) {
      return PolynomComposition(A, B);
    }

    //умножение полинома на число
    public static Polynom<T> PolynomCompositionWithNum(Polynom<T> A, T num) {
      var resultPolynom = new Polynom<T>();
      for (int i = 0; i < A._polynomDictionary.Count; i++) {
        resultPolynom._polynomDictionary[i] = (dynamic)A._polynomDictionary[i] * num; 
      }
      return resultPolynom;
    }

    public static Polynom<T> operator *(Polynom<T> A, T num) {
      return PolynomCompositionWithNum(A, num);
    }

    //возведение полинома в степень
    public static Polynom<T> PolynomPow(Polynom<T> A, int pow) {
      Polynom<T> resultPolynom = A;
      for (int i = 1; i < pow; i++) {
        resultPolynom *= A;
      }
      return resultPolynom;
    }

    //значение полинома в точке
    public T PolynomInDot(T dot) {
      T result = new T();
      for (int i = 0; i < _polynomDictionary.Count; i++) {
        if (dot is Matrix) {
          result += Matrix.MatrixPow((dynamic)dot, i) * _polynomDictionary[i];
        } else {
          result += Math.Pow((dynamic)dot, i) * _polynomDictionary[i];
        }
      }
      return result;
    }

    //композиция полиномов
    public static Polynom<T> CompositionPolynimWithPolynom(Polynom<T> A, Polynom<T> B) {
      var resultPolynom = new Polynom<T>(MakeZeroDict(A));
      var polynomArr = new Polynom<T>[A._polynomDictionary.Count];
      for (int i = 1; i < polynomArr.Length; i++) {
        polynomArr[i] = new Polynom<T>((dynamic)PolynomCompositionWithNum(PolynomPow(B, i), A._polynomDictionary[i])._polynomDictionary);
      }
      for (int i = 1; i < polynomArr.Length; i++) {
        resultPolynom += (dynamic)polynomArr[i]; 
      }
      resultPolynom._polynomDictionary[0] = (dynamic)resultPolynom._polynomDictionary[0] + A._polynomDictionary[0];
      return resultPolynom;
    }

    //вывод
    public override string ToString() {
      StringBuilder str = new StringBuilder();
      for (int i = _polynomDictionary.Count - 1; i >= 0; i--) {
        if (_polynomDictionary[i] is Matrix) {
          if (i == 0) {
            str.Append($"{_polynomDictionary[i]} * x^{i}{Environment.NewLine}");
          } else {
            str.Append($"{_polynomDictionary[i]} * x^{i} + {Environment.NewLine}");
          }
        } else {
          if (_polynomDictionary[i] == (dynamic)0) {
            str.Append("");
          } else {
            if (i == _polynomDictionary.Count - 1) {
              if (_polynomDictionary[i] == (dynamic)(-1)) {
                str.Append($"-x^{i}");
              } else if (_polynomDictionary[i] == (dynamic)1) {
                str.Append($"x^{i}");
              } else {
                str.Append($"{_polynomDictionary[i]}x^{i}");
              }
            } else {
              if (_polynomDictionary[i] > (dynamic)0) {
                if (i == 1) {
                  if (_polynomDictionary[i] == (dynamic)1) {
                    str.Append($" + x");
                  } else {
                    str.Append($" + {_polynomDictionary[i]}x");
                  }
                } else {
                  if (i == 0) {
                    str.Append($" + {_polynomDictionary[i]}");
                  } else {
                    if (_polynomDictionary[i] == (dynamic)1) {
                      str.Append($" + x^{i}");
                    } else {
                      str.Append($" + {_polynomDictionary[i]}x^{i}");
                    }
                  }
                }
              } else {
                if (_polynomDictionary[i] == (dynamic)(-1) && i == 1 && i != 0) {
                  str.Append($" - x");
                } else {
                  if (i == 0) {
                    str.Append($" - {Math.Abs((dynamic)_polynomDictionary[i])}");
                  } else {
                    if (i == 1) {
                      str.Append($" - {Math.Abs((dynamic)_polynomDictionary[i])}x");
                    } else {
                      if (_polynomDictionary[i] == (dynamic)(-1)) {
                        str.Append($" - x^{i}");
                      } else {
                        str.Append($" - {Math.Abs((dynamic)_polynomDictionary[i])}x^{i}");
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      return str.ToString();
    }
  }
}