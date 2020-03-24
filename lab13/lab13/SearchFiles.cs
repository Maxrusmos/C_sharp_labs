using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SearchFilesOp {
  class SearchFiles {
    public static void FileSearch() {
      string catalog = @"C:\Users\vmaxi\Desktop\3_6sem\РПКС\labs";

      string fileName = "Файл.txt";

      //проводим поиск в выбранном каталоге и во всех его подкаталогах
      foreach (string findedFile in Directory.EnumerateFiles(catalog, fileName,
          SearchOption.AllDirectories)) {
        FileInfo FI;
        try {
          //по полному пути к файлу создаём объект класса FileInfo
          FI = new FileInfo(findedFile);
          //найденный результат выводим в консоль (имя, путь, размер, дата создания файла)
          Console.WriteLine(FI.Name + " " + FI.FullName + " " + FI.Length + "_байт" +
                              " Создан: " + FI.CreationTime);

        }
        catch //слишком длинное имя файла
        {
          continue;
        }
      }
    }
  }
}