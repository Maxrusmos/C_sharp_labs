﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MVVM {
  public class WorkWithFile {
    private static List<string> _fileList = new List<string>();

    public static List<string> OpenFile() {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      if (openFileDialog.ShowDialog() == true) {
        var extension = Path.GetExtension(openFileDialog.FileName);
        if (!(extension != ".txt")) { 
          using (StreamReader sr = new StreamReader(openFileDialog.FileName)) {
            while (!sr.EndOfStream) {
              string strFromFile = sr.ReadLine().Replace(" ", "");
              _fileList.Add(strFromFile);
            }
          }
          if (!CorrectFile(_fileList)) {
            throw new ArgumentException("Invalid data in the file");
          }
        } else {
          throw new ArgumentException("The file must have the txt extension");
        }
      }
      return _fileList;
    }

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

    public static async void WriteToFile(TextBlock resultText) {
      SaveFileDialog dlg = new SaveFileDialog();
      dlg.FileName = "result";
      dlg.DefaultExt = ".txt"; 
      dlg.Filter = "Text documents (.txt)|*.txt";
      var result = dlg.ShowDialog();
      if (result == true) {
        using (FileStream fstream = new FileStream(dlg.FileName, FileMode.OpenOrCreate)) {
          byte[] array = System.Text.Encoding.Default.GetBytes(resultText.Text);
          await fstream.WriteAsync(array, 0, array.Length);
        }
      }
    }
  }
}
