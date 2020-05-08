using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace MVVM {
  public class Arithmetic {
    private List<string> _pcnfPdnfList = new List<string>();

    public List<string> GetPcnfPdnfList {
      get => _pcnfPdnfList;
    }

    public static List<Token> ReversePolishNotation(string expression) {
      var collection = Regex.Matches(expression, @"[()A-Za-z!*+>~#^|*]");
      var variables = new Regex(@"[A-Za-z]");
      var operations = new Regex(@"[!*+>~#|^]"); 
      var brackets = new Regex(@"\(|\)"); 
      var priority = new string[] { "!", "*", "+", ">", "~", "|", "#", "^"};
      var stack = new Stack<string>();
      var list = new List<Token>();

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
      var variables = rpn.Where(x => x.Type == Token.TokenType.Variable).Distinct().Select(x => x.Value).Cast<string>().ToArray();
      var dictionary = new Dictionary<string, bool>();
      foreach (string variable in variables) {
        dictionary[variable] = false;
      }
      return dictionary;
    }

    public static void GetVariables(int value, Dictionary<string, bool> variables) {
      string binary = Convert.ToString(value, 2);
      for (int i = 1; i < binary.Length; i++) {
        variables[variables.ElementAt(i - 1).Key] = binary[i] == '0' ? false : true;
      }
    }

    public static string[,] TruthTable(List<Token> rpn, Dictionary<string, bool> variables) {
      int count = (int)Math.Pow(2, variables.Count);
      var valueList = new List<string>();
      for (int i = 0; i < count; i++) {
        GetVariables(i + count, variables);
        foreach (var value in variables) {
          valueList.Add(value.Value ? " 1 " : " 0 ");
        }
        valueList.Add(Calculate(rpn, variables) ? " 1 " : " 0 ");
      }
      var valueArray = ToDoubleArray(valueList, variables);
      return valueArray;
    }

    public static string TruthTableToString(string[,] truthTable, Dictionary<string, bool> variables) {
      var strBuild = new StringBuilder();
      foreach (var varName in variables) {
        strBuild.Append(" " + varName.Key + " ");
      }
      strBuild.Append("φ");
      strBuild.Append(Environment.NewLine);
      for (int i = 0; i < (int)Math.Pow(2, variables.Count); i++) {
        for (int j = 0; j < variables.Count + 1; j++) {
          strBuild.Append(truthTable[i, j]);
        }
        strBuild.Append(Environment.NewLine);
      }
      return strBuild.ToString();
    }

    private static string[,] ToDoubleArray(List<string> valueList, Dictionary<string, bool> variables) {
      var arr = new string[(int)Math.Pow(2, variables.Count), variables.Count + 1];
      for (int i = 0, r = 0; r < (int)Math.Pow(2, variables.Count); ++r) {
        for (int c = 0; c < variables.Count + 1; ++i, ++c) {
          arr[r, c] = valueList.ToArray()[i];
        }
      }
      return arr;
    }

    private static string[,] ToDoubleArray(List<string> valueList, Dictionary<string, bool> variables, int rowCount) {
      var arr = new string[rowCount, variables.Count];
      for (int i = 0, r = 0; r < rowCount; ++r) {
        for (int c = 0; c < variables.Count; ++i, ++c) {
          arr[r, c] = valueList.ToArray()[i];
        }
      }
      return arr;
    }

    public static string Sdnf(string[,] truthTable, Dictionary<string, bool> variables, List<Token> rpn) {
      var rowCounter = 0;
      var tmpList = new List<string>();    
      for (int i = 0; i < (int)Math.Pow(2, variables.Count); i++) {
        if (truthTable[i, variables.Count] == " 1 ") {
          for (int j = 0; j < variables.Count; j++) {
            tmpList.Add(truthTable[i, j]);
          }
          rowCounter++;
        }
      }
      var tmpArr = ToDoubleArray(tmpList, variables, rowCounter);
      var strBuild = new StringBuilder();
      var vars = rpn.Where(x => x.Type == Token.TokenType.Variable).Distinct().Select(x => x.Value).Cast<string>().ToArray();
      strBuild.Append("PDNF: ");
      for (int i = 0; i < rowCounter; i++) {
        strBuild.Append("(");
        for (int j = 0; j < variables.Count; j++) {
          if (tmpArr[i, j] == " 0 ") {
            strBuild.Append($"!{vars[j]}");
          } else {
            strBuild.Append($"{vars[j]}");
          }
          if (j != variables.Count - 1) {
            strBuild.Append("*");
          }
        }
        strBuild.Append(")");
        if (i != rowCounter - 1) {
          strBuild.Append("+");
        }
      }    
      return strBuild.ToString();
    }

    public static async Task<string> SdnfAsync(string[,] truthTable, Dictionary<string, bool> variables, List<Token> rpn) {
      return await Task.Run(() => Sdnf(truthTable, variables, rpn)); 
    }

    public static string Sknf(string[,] truthTable, Dictionary<string, bool> variables, List<Token> rpn) {
      var rowCounter = 0;
      var tmpList = new List<string>();
      for (int i = 0; i < (int)Math.Pow(2, variables.Count); i++) {
        if (truthTable[i, variables.Count] == " 0 ") {
          for (int j = 0; j < variables.Count; j++) {
            tmpList.Add(truthTable[i, j]);
          }
          rowCounter++;
        }
      }
      var tmpArr = ToDoubleArray(tmpList, variables, rowCounter);
      var strBuild = new StringBuilder();
      var vars = rpn.Where(x => x.Type == Token.TokenType.Variable).Distinct().Select(x => x.Value).Cast<string>().ToArray();
      strBuild.Append("PCNF: ");
      for (int i = 0; i < rowCounter; i++) {
        strBuild.Append("(");
        for (int j = 0; j < variables.Count; j++) {
          if (tmpArr[i, j] == " 1 ") {
            strBuild.Append($"!{vars[j]}");
          } else {
            strBuild.Append($"{vars[j]}");
          }
          if (j != variables.Count - 1) {
            strBuild.Append("+");
          }
        }
        strBuild.Append(")");
        if (i != rowCounter - 1) {
          strBuild.Append("*");
        }
      }
      return strBuild.ToString();
    }

    public static string AddToResultString(string pcnf, string pdnf, int counter) {
      var strGapBuilder = new StringBuilder(counter.ToString().Length > 1 ? "  " : " ");
      for (int i = 0; i < (counter.ToString() + ") ").Length; i++) {
        strGapBuilder.Append(" ");
      }
      return counter.ToString() + ") " + pcnf + Environment.NewLine + strGapBuilder.ToString() + pdnf;
    }

    public static async Task<string> SknfAsync(string[,] truthTable, Dictionary<string, bool> variables, List<Token> rpn) {
      return await Task.Run(() => Sknf(truthTable, variables, rpn));
    }
  }
}