using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Roma {
  class Calc {
    public static IEnumerable<char> GetRPN(IEnumerable<char> expr) {
      var stack = new Stack<char>();

      foreach (var token in expr) {
        if (token == ')') {
          stack.Pop();
        } else
        if (!char.IsLetter(token)) {
          stack.Push(token);
          continue;
        } else {
          yield return token;
        }

        while (stack.Count > 0 && stack.Peek() != '(')
          yield return stack.Pop();
      }
    }

    //counts expression in rpn
    public static bool Calculate(IEnumerable<char> rpn, Dictionary<char, int> variableValue) {
      var stack = new Stack<bool>();

      foreach (var token in rpn)
        switch (token) {
          case '!': stack.Push(!stack.Pop()); break;
          case '+': stack.Push(stack.Pop() | stack.Pop()); break;
          case '*': stack.Push(stack.Pop() & stack.Pop()); break;
          case '>': stack.Push(stack.Pop() | !stack.Pop()); break;
          case '~': stack.Push(stack.Pop() == stack.Pop()); break;
          case '^': stack.Push(stack.Pop() != stack.Pop()); break;
          case '#': stack.Push(!stack.Pop() & !stack.Pop()); break;
          case '|': stack.Push(!(stack.Pop() & stack.Pop())); break;
          case '0': stack.Push(false); break;
          case '1': stack.Push(true); break;
          default: stack.Push(variableValue[token] == 1);
            break;
        }

      return stack.Pop() ? true : false;
    }

    public static IEnumerable GetAllCombinations(IList<char> variables, int index, Dictionary<char, int> varValues) {
      if (index >= variables.Count) yield return null;
      else
        foreach (var val in Enumerable.Range(0, 2)) {
          varValues[variables[index]] = val;
          foreach (var temp in GetAllCombinations(variables, index + 1, varValues))
            yield return temp;
        }
    }

    public static IList<char> GetVariables(string expression) {
      try {
        return Regex.Replace(expression, @"[!,+,*,>,~,^,#,|,0,1,(,)]", "").ToArray().Distinct().ToArray();
      }
      catch (RegexMatchTimeoutException) {
        return null;
      }
    }
  }
}
