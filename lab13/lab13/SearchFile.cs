using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SearchFileOp {
  public static class SearchFile {
   public static List<string> _fileList = new List<string>(); //private

    //lazy value factory
    public static void ApplyAllFiles(string folder, Action<string> AddList, string fileName) {
      foreach (var file in Directory.GetFiles(folder)) {
        //пустой файл
        if (file.Split(@"\").Last() == fileName) {
          AddList(file);
        }
      }
      foreach (var subdir in Directory.GetDirectories(folder)) {
        try {
          ApplyAllFiles(subdir, AddList, fileName);
        }
        //io exeption -> agregate
        catch {

        }
      }
    }

    //В эту функцию попадает полное имя файла и его место расположения.
    public static void AddList(string path) {
      _fileList.Add(path);
      Console.WriteLine($"{_fileList.Count}) {path}");
    }
  }
}
