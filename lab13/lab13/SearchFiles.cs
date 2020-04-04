using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace SearchFilesOp {
  class SearchFiles {
    public static void FileSearch() {
      string catalog = @"C:\Users\vmaxi\Desktop\";
      string fileName = "Файл.txt";
      var fileNameCompressed = catalog + fileName.Split('.')[0] + ".txt";
      foreach (string findedFile in Directory.EnumerateFiles(catalog, fileName, SearchOption.AllDirectories)) {
        FileInfo FI;
        try {
          FI = new FileInfo(findedFile);
          Console.WriteLine(FI.Name + " " + FI.FullName + " " + FI.Length + "_байт" + " Создан: " + FI.CreationTime);
          Compress(FI.FullName, fileNameCompressed);
        }
        catch {
          continue;
        }
      }
    }

    public static void Compress(string sourceFile, string compressedFile) {
      using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate)) {
        using (FileStream targetStream = File.Create(compressedFile)) {
          using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress)) {
            sourceStream.CopyTo(compressionStream);
            Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
          }
        }
      }
    }
  }
}