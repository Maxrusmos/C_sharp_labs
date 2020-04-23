using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TokenOp;
using System.Diagnostics;

namespace ArithmeticOp {
  static class Arithmetic {
    public static List<Token> Calculate(string expression) {
      MatchCollection collection = Regex.Matches(expression, @"[()A-Za-z!*+>~#^|*]");

      Regex variables = new Regex(@"[A-Za-z]"); //переменные
      Regex operations = new Regex(@"[!*+>~#|^]"); //операнды
      Regex brackets = new Regex(@"\(|\)"); //скобки
      string[] priority = { "!", "*", "+", ">", "~", "|", "#", "^"};

      Stack<string> stack = new Stack<string>();
      List<Token> list = new List<Token>();
      foreach (Match match in collection) {
        Match temp = variables.Match(match.Value);
        if (temp.Success) {
          list.Add(new Token(temp.Value, Token.TokenType.Variable));
          continue;
        }

        temp = brackets.Match(match.Value);
        if (temp.Success) {
          if (temp.Value == "(") {
            stack.Push(temp.Value);
            continue;
          }
          string operation = stack.Pop();
          while (operation != "(") {
            list.Add(new Token(operation, Token.TokenType.Operation));
            operation = stack.Pop();
          }
          continue;
        }

        temp = operations.Match(match.Value);
        if (temp.Success) {
          if (stack.Count != 0)
            while (Array.IndexOf(priority, temp.Value) > Array.IndexOf(priority, stack.Peek())) {
              if (stack.Peek() == "(") {
                break;
              }
              list.Add(new Token(stack.Pop(), Token.TokenType.Operation));
            }
          stack.Push(temp.Value);
        }
      }
      while (stack.Count != 0) {
        list.Add(new Token(stack.Pop(), Token.TokenType.Operation));
      }
      return list;
    }

    public static bool Calculate(List<Token> rpn, Dictionary<string, bool> variables) {
      Stack<bool> result = new Stack<bool>();
      foreach (Token token in rpn) {
        if (token.Type == Token.TokenType.Variable) {
          result.Push(variables[token.Value]);
        }
        if (token.Type == Token.TokenType.Operation) {
          switch (token.Value) {
            case "!":
              result.Push(!result.Pop());
              break;
            case "*":
              result.Push(result.Pop() & result.Pop());
              break;
            case "+":
              result.Push(result.Pop() | result.Pop());
              break;
            case ">":
              result.Push(result.Pop() | !result.Pop());
              break;
            case "~":
              result.Push(!(result.Pop() ^ result.Pop()));
              break;
            case "|":
              result.Push(!(result.Pop() && result.Pop()));
              break;
            case "#":
              result.Push(!(result.Pop() || result.Pop()));
              break;
            case "^":
              result.Push(result.Pop() ^ result.Pop());
              break;
          }
        }
      }
      return result.Pop();
    }

    public static Dictionary<string, bool> GetVariables(List<Token> rpn) {
      string[] variables = rpn.Where(x => x.Type == Token.TokenType.Variable).Distinct().Select(x => x.Value).Cast<string>().ToArray();
      Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
      foreach (string variable in variables) {
        dictionary[variable] = false;
      }
      return dictionary;
    }

    public static void GetVariables(int value, Dictionary<string, bool> variables) {
      string binary = Convert.ToString(value, 2);
      for (int i = 1; i < binary.Length; i++)
        variables[variables.ElementAt(i - 1).Key] = binary[i] == '0' ? false : true;
    }

    public static string[,] PrintTable(List<Token> rpn, Dictionary<string, bool> variables) {
      int count = (int)Math.Pow(2, variables.Count);
      var valueArray = new string[(int)Math.Pow(2, count), count];
      for (int i = 0; i < count; i++) {
        GetVariables(i + count, variables);
        var j = 0;
        foreach (var value in variables) {
          Debug.Write(value.Value ? " 1 " : " 0 ");
          valueArray[i, j] = value.Value ? " 1 " : " 0 ";
          j++;
        }
        Debug.WriteLine(Calculate(rpn, variables) ? " 1 " : " 0 ");
      }
      return valueArray;
    }
  }
}