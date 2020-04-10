using System;
using System.IO;
using SearchFilesOp;
using System.IO.Compression;
using FileCompressOp;

namespace lab13 {
  class Program {
    static void Main(string[] args) {
      //получаем переменную Windows с адресом текущего пользователя
      string PatchProfile = Environment.GetEnvironmentVariable("USERPROFILE");
      //наш файл
      Console.Write("Введите название файла, который хотите найти: ");
      var myFileName = Console.ReadLine(); 
      //ищем все вложенные папки 
      string[] dirsArr = SearchFiles.SearchDirectory(PatchProfile);
      //создаем строку в которой соберем все пути
      string ListPatch = ""; //заголовок для строк
      var fileCounter = 0;
      foreach (string folderPatch in dirsArr) {
        //добавляем новую строку в список
        try {
          //пытаемся найти данные в папке 
          string[] filesArr = SearchFiles.SearchFileInDir(folderPatch, myFileName);
          foreach (string currentFile in filesArr) {
            //добавляем файл в список 
            fileCounter++;
            ListPatch += fileCounter + ") " + currentFile + "\n";
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
      } else {
        Console.WriteLine("Найденные файлы");
        Console.WriteLine(ListPatch);
      }
    }
  }
}
