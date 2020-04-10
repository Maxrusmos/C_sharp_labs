using System;
using System.IO;

namespace SearchFilesOp {
  class SearchFiles {
    public static string[] SearchDirectory(string patch) {
      string[] ReultSearch = Directory.GetDirectories(patch);
      return ReultSearch;
    }

    public static string[] SearchFileInDir(string patch, string pattern) {
      string[] ReultSearch = Directory.GetFiles(patch, pattern, SearchOption.AllDirectories);
      return ReultSearch;
    }
  }
}