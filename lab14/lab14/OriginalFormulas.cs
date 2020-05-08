using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM {
  public class OriginalFormulas {
    private List<string> _formulasList = new List<string>();

    public List<string> GetFormulasList {
      get => _formulasList; 
    }

    public List<string> OpenFile() {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      if (openFileDialog.ShowDialog() == true) {
        var extension = Path.GetExtension(openFileDialog.FileName);
        if (!(extension != ".txt")) {
          using (StreamReader sr = new StreamReader(openFileDialog.FileName)) {
            while (!sr.EndOfStream) {
              string strFromFile = sr.ReadLine().Replace(" ", "");
              _formulasList.Add(strFromFile);
            }
          }
          if (_formulasList.Count == 0) {
            throw new ArgumentException("File is empty");
          }
          if (!CorrectFile(_formulasList)) {
            _formulasList.Clear();
            throw new ArgumentException("Invalid data in the file");
          }
        } else {
          _formulasList.Clear();
          throw new ArgumentException("The file must have the txt extension");
        }
      }
      return _formulasList;
    }

    private static bool CorrectFile(List<string> fileList) {
      var boolCorrect = true;
      Regex r = new Regex(@"[^A-za-z+!*~<>|)#(]+$");
      foreach (var formula in fileList) {
        Match m = r.Match(formula);
        if (m.Success) {
          boolCorrect = false;
        }
      }
      return boolCorrect;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "") {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
  }
}
