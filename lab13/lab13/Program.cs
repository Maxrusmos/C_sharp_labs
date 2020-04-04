using System;
using System.IO;
using SearchFilesOp;
using System.IO.Compression;

namespace lab13 {
  class Program {
    static void Main(string[] args) {
      //получаем переменную Windows с адресом текущего пользователя
      string PatchProfile = Environment.GetEnvironmentVariable("USERPROFILE");
      //ищем все вложенные папки 
      string[] S = SearchDirectory(PatchProfile);
      //создаем строку в которой соберем все пути
      string ListPatch = "найденные файлы \n"; //заголовок для строк
      foreach (string folderPatch in S) {
        //добавляем новую строку в список
        try {
          //пытаемся найти данные в папке 
          string[] F = SearchFile(folderPatch, "*.png");
          foreach (string FF in F) {
            //добавляем файл в список 
            ListPatch += FF + "\n";
          }
        }
        catch {
        }
      }
      //выводим список на экран 
      MessageBox.Show(ListPatch);
      Console.WriteLine(ListPatch);
    }

    static string[] SearchDirectory(string patch) {
      //находим все папки в по указанному пути
      string[] ReultSearch = Directory.GetDirectories(patch);
      //возвращаем список директорий
      return ReultSearch;
    }

    static string[] SearchFile(string patch, string pattern) {
      /*флаг SearchOption.AllDirectories означает искать во всех вложенных папках*/
      string[] ReultSearch = Directory.GetFiles(patch, pattern, SearchOption.AllDirectories);
      //возвращаем список найденных файлов соответствующих условию поиска 
      return ReultSearch;
    }
  }
}
