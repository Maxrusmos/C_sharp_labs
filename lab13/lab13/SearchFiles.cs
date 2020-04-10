using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using System.IO;
using FileCompressOp;

namespace SearchFilesOp {
  class SearchFiles {
    public static string[] SearchDirectory(string patch) {
      //находим все папки в по указанному пути
      string[] ReultSearch = Directory.GetDirectories(patch);
      //возвращаем список директорий
      return ReultSearch;
    }

    public static string[] SearchFileInDir(string patch, string pattern) {
      /*флаг SearchOption.AllDirectories означает искать во всех вложенных папках*/
      string[] ReultSearch = Directory.GetFiles(patch, pattern, SearchOption.AllDirectories);
      //возвращаем список найденных файлов соответствующих условию поиска 
      return ReultSearch;
    }
  }
}