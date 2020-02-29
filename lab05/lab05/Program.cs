using System;
using WholePartConvert;
using FractionalPartConvert;
using WorkWithFile;

namespace lab05 {
  class Program {
    static void Main(string[] args) {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Если хотите взять данные из файла, то введите имя файла. Если хотите ввести число сами, то нажмите Enter.");
      var fileName = Console.ReadLine();
      var numberDecimal = "";
      var wholePart = 0;
      var fractionalPart = 0.0;
      var newBase = 10;

      if (fileName.Length != 0) {
        WorkWithFile.WorkWithFile.FileParse(fileName, out wholePart, out fractionalPart, out numberDecimal, out newBase);
      } else {
        Console.Write("Введите число, которое хотите перевести из десятичной в другую систему счисления: ");
        numberDecimal = Console.ReadLine();
        // для целой можно воспользоваться схемой горнера
        wholePart = int.Parse(numberDecimal.Split(',')[0]); //целая часть
        fractionalPart = double.Parse(numberDecimal) % wholePart; //дробная часть
        Console.Write("Введите систему счисления: ");
        newBase = int.Parse(Console.ReadLine());
      }
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine(Environment.NewLine + "Число " + numberDecimal + " в " + newBase + "-й системе счисления равно " +
        WholePartConvert.WholePartConvert.ToNS(wholePart, newBase) + "," + FractionalPartConvert.FractionalPartConvert.FToNS(fractionalPart, newBase));
    }
  }
}
