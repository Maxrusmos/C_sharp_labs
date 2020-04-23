using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkWithFileOp;
using ReversePolishNatationOp;
using ArithmeticOp;
using TokenOp;

namespace lab14 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    //нажатие на кнопку чтения из файла
    private void ButtonOpenFile_Click(object sender, RoutedEventArgs e) {
      var logicalExpressionList = new List<string>();
      try {
        logicalExpressionList = WorkWithFile.OpenFile();
      }
      catch (ArgumentException ex) {
        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
      }

      var mainReverseList = new List<string>();
      foreach (var formula in logicalExpressionList) {
        TextFromFile.Text += formula + Environment.NewLine;
        List<Token> rpn = Arithmetic.Calculate(formula);
        Dictionary<string, bool> variables = Arithmetic.GetVariables(rpn);
        var arr = Arithmetic.PrintTable(rpn, variables);
        foreach (var it in arr) {
          ResultText.Text += it;
        }
        ResultText.Text += Environment.NewLine;
        Debug.WriteLine("-----------------------------");
      }

      //foreach (var reverseFormula in mainReverseList) {
      //  ResultText.Text += reverseFormula + Environment.NewLine;
      //}
    }
  }
}
