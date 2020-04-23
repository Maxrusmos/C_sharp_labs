using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WorkWithFileOp {
  public static class WorkWithFile {
    public static List<string> OpenFile() {
      var strList = new List<string>();
      OpenFileDialog openFileDialog = new OpenFileDialog();
      if (openFileDialog.ShowDialog() == true) {
        var extension = Path.GetExtension(openFileDialog.FileName);
        if (!(extension != ".txt")) {
          using (StreamReader sr = new StreamReader(openFileDialog.FileName)) {
            while (!sr.EndOfStream) {
              string strFromFile = sr.ReadLine().Replace(" ", "");
              strList.Add(strFromFile);
            }
          }
          if (!CorrectFile(strList)) {
            throw new ArgumentException("Некорректные данные в файле");
          }
        } else {
          throw new ArgumentException("Файл должен быть с расширением txt");
        }
      }
      return strList;
    }

    //проверка корректности данных в файле
    private static bool CorrectFile(List<string> fileList) {
      var boolCorrect = true;
      Regex r = new Regex(@"[^A-za-z0-1+!*~<>|)#(]+$");
      foreach (var formula in fileList) {
        Match m = r.Match(formula);
        if (m.Success) {
          boolCorrect = false;
        }
      }
      return boolCorrect;
    }
  }
}
