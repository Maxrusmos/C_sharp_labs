using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SearchFileOp {
  public static class SearchFile {
    private static List<string> _fileList = new List<string>();
    public static List<string> getList {
      get => _fileList;
    }

    public static void ApplyAllFiles(string folder, Action<string> AddList, string fileName) {
      foreach (var file in Directory.GetFiles(folder)) {
        if (file.Length == 0) {
          throw new ArgumentException("Что-то пошло не так", nameof(file.Length));
        }
        if (file.Split(@"\").Last() == fileName) {
          AddList(file);
        }
      }
      foreach (var subdir in Directory.GetDirectories(folder)) {
        try {
          ApplyAllFiles(subdir, AddList, fileName);
        }
        catch { }
      }
    }

    public static void AddList(string path) {
      _fileList.Add(path);
      Console.WriteLine($"{_fileList.Count}) {path}");
    }
  }
}
