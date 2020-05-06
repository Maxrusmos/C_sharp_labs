using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using lab14;
using System.Windows;

namespace MVVM {
  class ApplicationViewModel : INotifyPropertyChanged {
    public ObservableCollection<string> OriginalFormulasList { get; set; }
    private OriginalFormulas _modelFormulas = new OriginalFormulas();

    private RelayCommand _openFileCommand;
    public RelayCommand OpenFileCommand {
      get {
        return _openFileCommand ??
          (_openFileCommand = new RelayCommand(obj =>
          {
            try {
              foreach (var formula in _modelFormulas.OpenFile()) {
                OriginalFormulasList.Add(formula);
              }
            } 
            catch (ArgumentException ex) {
              MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
          }));
      }
    }

    public ObservableCollection<string> PcnfPdnfList { get; set; }
    private Arithmetic _modelPcnfPdnf = new Arithmetic();

    private RelayCommand _calcAllPcnfPdnfCommand;
    public RelayCommand CalcAllPcnfPdnfCommand {
      get {
        return _calcAllPcnfPdnfCommand ??
          (_calcAllPcnfPdnfCommand = new RelayCommand(async obj =>
          {
            foreach (var formula in OriginalFormulasList) {
              List<Token> rpn = Arithmetic.ReversePolishNotation(formula);
              Dictionary<string, bool> variables = Arithmetic.GetVariables(rpn);
              var arrTable = Arithmetic.TruthTable(rpn, variables);        
              PcnfPdnfList.Add(Arithmetic.AddToResultString(
                await Arithmetic.SknfAsync(arrTable, variables, rpn), 
                await Arithmetic.SdnfAsync(arrTable, variables, rpn)));
            }
          }));
      }
    }

    private RelayCommand _traceCommand;
    public RelayCommand TraceCommand {
      get {
        return _traceCommand ??
          (_traceCommand = new RelayCommand(async obj =>
          {
            var counter = 0;
            var resultText = new StringBuilder();
            var resStr = "";
            foreach (var formula in OriginalFormulasList) {
              resStr = WorkWithFile.PreparingToWriteToFile(formula, resultText, ++counter);
            }
            await WorkWithFile.WriteToFile(resStr);
          }));
      }
    }

    private RelayCommand _exitCommand;
    public RelayCommand ExitCommand {
      get {
        return _exitCommand ??
          (_exitCommand = new RelayCommand(obj => {
            Environment.Exit(0);
          }));
      }
    }

    private RelayCommand _showAboutWindowCommand;
    public RelayCommand ShowAboutWindowCommand {
      get {
        return _showAboutWindowCommand ??
          (_showAboutWindowCommand = new RelayCommand(obj => {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
          }));
      }
    }

    //private RelayCommand _solveOneCommand;
    //public RelayCommand SolveOneCommand {
    //  get {
    //    return _solveOneCommand ??
    //      (_solveOneCommand = new RelayCommand(async obj =>
    //      {
    //        var index = OriginalFormulasList.IndexOf(obj as string);
    //        List<Token> rpn = Arithmetic.ReversePolishNotation(OriginalFormulasList[index]);
    //          Dictionary<string, bool> variables = Arithmetic.GetVariables(rpn);
    //          var arrTable = Arithmetic.TruthTable(rpn, variables);        
    //          PcnfPdnfList.Add(Arithmetic.AddToResultString(
    //            await Arithmetic.SknfAsync(arrTable, variables, rpn), 
    //            await Arithmetic.SdnfAsync(arrTable, variables, rpn)));
    //      }));
    //  }
    //}

    private string _originalFormulasList;
    public string OriginalFormulasListItem {
      get => _originalFormulasList;
      set {
        _originalFormulasList = value;
        OnPropertyChanged(nameof(OriginalFormulasListItem));
      }
    }

    private string _pcnfPdnfFormulasList;
    public string PcnfPdnfFormulasListItem {
      get => _pcnfPdnfFormulasList;
      set {
        _pcnfPdnfFormulasList = value;
        OnPropertyChanged(nameof(PcnfPdnfFormulasListItem));
      }
    }

    private object _selectedFormula;
    public object SelectedFormula {
      get => _selectedFormula;
      set {
        _selectedFormula = value;
        OnPropertyChanged(nameof(SelectedFormula));
      }
    }

    public ApplicationViewModel() {
      OriginalFormulasList = new ObservableCollection<string>();
      OriginalFormulasListItem = string.Join(Environment.NewLine, OriginalFormulasList);
      
      PcnfPdnfList = new ObservableCollection<string>();
      PcnfPdnfFormulasListItem = string.Join(Environment.NewLine, PcnfPdnfList);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
