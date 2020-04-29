using System;
using System.Collections.Generic;
using System.Windows;
using WorkWithFileOp;
using ArithmeticOp;
using TokenOp;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace lab14 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    //нажатие на кнопку чтения из файла
    private void ButtonOpenFile_Click(object sender, RoutedEventArgs e) {
      ResultText.Text = "";
      TextFromFile.Text = "";
      var logicalExpressionList = new List<string>();
      try {
        logicalExpressionList = WorkWithFile.OpenFile();
      }
      catch (ArgumentException ex) {
        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
      }

      var mainReverseList = new List<string>();
      var counter = 1;
      foreach (var formula in logicalExpressionList) {
        TextFromFile.Text += counter + ") " + formula + Environment.NewLine;
        List<Token> rpn = Arithmetic.ReversePolishNotation(formula);
        Dictionary<string, bool> variables = Arithmetic.GetVariables(rpn);
        var arrTable = Arithmetic.TruthTable(rpn, variables);

        var sdnf = Arithmetic.Sdnf(arrTable, variables, rpn);
        var sknf = Arithmetic.Sknf(arrTable, variables, rpn);

        ResultText.Text += counter + ") ";
        foreach (var item in rpn) {
          ResultText.Text += item.Value;
        }
        ResultText.Text += Environment.NewLine;

        //вывод ти
        for (int i = 0; i < (int)Math.Pow(2, variables.Count); i++) {
          for (int j = 0; j < variables.Count + 1; j++) {
            ResultText.Text += arrTable[i, j];
          }
          ResultText.Text += Environment.NewLine;
        }
        counter++;

        ResultText.Text += "PCNF: " + sknf + Environment.NewLine;
        ResultText.Text += "PDNF: " + sdnf + Environment.NewLine;
        ResultText.Text += "----------------" + Environment.NewLine; 
      }
    }

    //сохранение
    private void ButtonWriteToFile_Click(object sender, RoutedEventArgs e) {
      WorkWithFile.WriteToFile(ResultText);
    }

    //закрытие
    private void ButtonExit_Click(object sender, RoutedEventArgs e) {
      Close();
    }

    //about
    private void ButtonAbout_Click(object sender, RoutedEventArgs e) {
      AboutWindow aboutWindow = new AboutWindow();
      aboutWindow.ShowDialog();
    }
  }
}
