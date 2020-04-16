using System;
using SearchFileOp;
using FileCompressOp;
using OpenInNotepadOp;

namespace lab13 {
  class Program {
    static void Main(string[] args) {
      Console.Write("Введите имя файла, который хотите найти: ");
      var myFileName = Console.ReadLine();
      SearchFile.ApplyAllFiles(@"C:\", SearchFile.AddList, myFileName);

      Console.Write("Выберите файл из списка, который хотите открыть (укажите номер в списке): ");
      if (!int.TryParse(Console.ReadLine(), out int numberInList)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Вы ввели не число");
        System.Environment.Exit(1);
      }

      if (numberInList - 1 > SearchFile._fileList.Count || numberInList < 1) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Такого номера в списке не существует");
        System.Environment.Exit(2);
      }

      //try
      OpenInNotepad.openFile(SearchFile._fileList, numberInList);

      try {
        FileCompress.Compress(SearchFile._fileList[numberInList - 1], SearchFile._fileList[numberInList - 1].Split('.')[1] + "Compress.txt");
      }
      catch (ArgumentException ex) {
        Console.WriteLine(ex.Message);
      }
      Console.WriteLine("успех");
      Console.ReadKey();
    }  
  }
}
