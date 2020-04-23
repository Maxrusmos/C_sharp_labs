using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ReversePolishNatationOp {
  public static class ReversePolishNatation {
    static private readonly string[] _lexemes = new string[] {")", "(", ">", "^", "|", "#", "~", "<", ">", "+", "*", "!"};

    //приоритетность
    private static int GetPriority(string lexeme) {
      var result = Array.IndexOf(_lexemes, lexeme); //возвращается индекс первого вхождения лексемы
      if (result < 0) {
        return 100;
      }
      return result;
    }

    //получаем список лексем
    public static List<string> GetLexemesList(string str) {
      return str.Select(c => c.ToString()).ToList();
    }

    //получаем обратную польскую запись
    public static List<string> ToReversePolishNatation(List<string> lexemesList) {
      var reversePolishNatationList = new List<string>();
      var stack = new Stack<string>();

      //перебор входной строки
      for (int i = 0; i < lexemesList.Count; i++) {
        var lexeme = lexemesList[i];
        var priority = GetPriority(lexeme);

        if (priority == 100) {
          reversePolishNatationList.Add(lexeme);
          continue;
        }

        //если стэк пуст, то кладем операцию
        if (stack.Count == 0) {
          stack.Push(lexeme);
        } else if (lexeme == "(") {
          stack.Push(lexeme);
        } else {
          while (stack.Count > 0 && GetPriority(stack.Peek()) >= priority) {
            var l = stack.Pop();
            if (lexeme == ")" && l == "(") {
              break;
            }
            reversePolishNatationList.Add(l);
          }
          if (lexeme != ")") {
            stack.Push(lexeme);
          }
        }
      }
      while (stack.Count > 0) {
        reversePolishNatationList.Add(stack.Pop());
      }
      return reversePolishNatationList;
    }
  }
}
