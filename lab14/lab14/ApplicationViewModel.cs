using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MVVM {
  class ApplicationViewModel : INotifyPropertyChanged {
    public ObservableCollection<string> OriginalFormulasList { get; set; }
    private OriginalFormulas _model = new OriginalFormulas();

    private RelayCommand _openFileCommand;
    public RelayCommand OpenFileCommand {
      get {
        return _openFileCommand ??
          (_openFileCommand = new RelayCommand(obj =>
          {
            foreach (var formula in _model.OpenFile()) {
              OriginalFormulasList.Add(formula);
            }
          }));
      }
    }

    private string _originalFormulasListBad;
    public string OriginalFormulasListBad {
      get => _originalFormulasListBad;
      set {
        _originalFormulasListBad = value;
        OnPropertyChanged(nameof(OriginalFormulasListBad));
      }
    }

    public ApplicationViewModel() {
      OriginalFormulasList = new ObservableCollection<string>();
      OriginalFormulasListBad = string.Join(Environment.NewLine, OriginalFormulasList);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    //protected void OnPropertiesChanged(params string[] propertiesNames) {
    //  foreach (var propertyName in propertiesNames) {
    //    OnPropertyChanged(nameof(propertyName));
    //  }
    //}
  }
}
