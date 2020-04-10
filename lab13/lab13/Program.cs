using System;
using System.Collections.Generic;
using System.IO;
using SearchFilesOp;
using System.IO.Compression;
using FileCompressOp;
using System.Diagnostics;

namespace lab13 {
  class Program {
    static void Main(string[] args) {
      string PatchProfile = Environment.GetEnvironmentVariable("USERPROFILE");
      Console.Write("Введите название файла, который хотите найти: ");
      var myFileName = Console.ReadLine(); 
      string[] dirsArr = SearchFiles.SearchDirectory(PatchProfile);
      string ListPatch = ""; 
      var fileCounter = 0;
      List<string> strList = new List<string>(); 
      foreach (string folderPatch in dirsArr) {
        try {
          string[] filesArr = SearchFiles.SearchFileInDir(folderPatch, myFileName);
          foreach (string currentFile in filesArr) {
            fileCounter++;
            ListPatch += fileCounter + ") " + currentFile + "\n";
            strList.Add(currentFile);
          }
        }
        catch {
          continue;
        }
      }

      if (ListPatch.Length == 0) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Файлы с таким именем не найдены");
        Environment.Exit(1);
      }

      Console.WriteLine("Найденные файлы");
      Console.WriteLine(ListPatch);

      Console.Write("Выберите файл из списка файл, который хотите открыть (укажите номер в списке): ");
      if (!int.TryParse(Console.ReadLine(), out int numberInList)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Вы ввели не число");
        System.Environment.Exit(1);
      }

      if (numberInList - 1 > strList.Count || numberInList < 1) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Такого номера в списке не существует");
        System.Environment.Exit(2);
      }

      FileCompress.Compress(strList[numberInList - 1], strList[numberInList - 1].Split('.')[1] + "Compress.txt");

      Process.Start("C:/Windows/System32/notepad.exe", strList[numberInList - 1]);
    }
  }
}
