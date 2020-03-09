using System;
using FileW;

namespace lab12 {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Ваш словарь: ");
      foreach (var keyValue in FileWork.ParseFile()) {
        Console.WriteLine(keyValue.Key + " : " + keyValue.Value);

      }

      CounterOp.Counter.DictCounter();
      Console.Write("Введите слово, информацию о котором хотите узнать: ");
      var yourWord = Console.ReadLine();
      CounterOp.Counter.DictSearch(yourWord, FileWork.ParseFile());
    }
  }
}
