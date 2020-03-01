using System;
using WholePartConvert;
using FractionalPartConvert;
using WorkWithFile;
using CorrectEnter;

namespace lab05 {
  class Program {
    static void Main(string[] args) {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Если хотите взять данные из файла, то введите имя файла. Если хотите ввести число сами, то нажмите Enter.");
      var fileName = Console.ReadLine();
      var numberDecimal = "";
      var wholePart = 0;
      var fractionalPart = 0.0;
      var Base = 0;

      if (fileName.Length != 0) {
        WorkWithFile.WorkWithFile.FileParse(fileName, out wholePart, out fractionalPart, out numberDecimal, out Base);
      } else {
        Console.Write("Введите число, которое хотите перевести из десятичной в другую систему счисления: ");
        numberDecimal = Console.ReadLine();

        if (!numberDecimal.Contains(',')) {
          CorrectEnter.CorrectEnter.CorrectEnterNum(numberDecimal.Split(',')[0], "0");
        } else {
          CorrectEnter.CorrectEnter.CorrectEnterNum(numberDecimal.Split(',')[0], numberDecimal.Split(',')[1]); 
        }

        wholePart = int.Parse(numberDecimal.Split(',')[0]); //целая часть

        if (wholePart == 0) {
          fractionalPart = double.Parse(numberDecimal);
        } else {
          fractionalPart = double.Parse(numberDecimal) % wholePart; //дробная часть
        }
        
        Console.Write("Введите систему счисления: ");
        var newBase = Console.ReadLine();
        CorrectEnter.CorrectEnter.CorrectEnterBase(newBase); //проверка базы
        Base = int.Parse(newBase);
      }

      Console.ForegroundColor = ConsoleColor.Yellow;
      if (fractionalPart != 0.0 && Base != 10) { // если нет дробной части и сс != 10
        Console.WriteLine(Environment.NewLine + "Число " + numberDecimal + " в " + Base + "-й системе счисления равно " +
          WholePartConvert.WholePartConvert.ToNS(wholePart, Base) + "," + FractionalPartConvert.FractionalPartConvert.FToNS(fractionalPart, Base));
      } else if (Base != 10) {
        Console.WriteLine(Environment.NewLine + "Число " + numberDecimal + " в " + Base + "-й системе счисления равно " +
          WholePartConvert.WholePartConvert.ToNS(wholePart, Base));
      }   
      if (Base == 10) {
        Console.WriteLine(Environment.NewLine + "Число " + numberDecimal + " в " + Base + "-й системе счисления равно " +
          numberDecimal);
      }
    }
  }
}
