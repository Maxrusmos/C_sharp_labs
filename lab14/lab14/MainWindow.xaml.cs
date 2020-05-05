﻿using System;
using System.Collections.Generic;
using System.Windows;
using MVVM;

namespace lab14 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      DataContext = new ApplicationViewModel();
    }

    private async void ButtonOpenFile_Click(object sender, RoutedEventArgs e) {
      ResultText.Text = "";
      var logicalExpressionList = new List<string>();
      try {
        //logicalExpressionList = WorkWithFile.OpenFile();
      }
      catch (ArgumentException ex) {
        MessageBox.Show(ex.Message, "Mistake", MessageBoxButton.OK, MessageBoxImage.Exclamation);
      }

      var mainReverseList = new List<string>();
      var counter = 1;
      foreach (var formula in logicalExpressionList) {
        List<Token> rpn = Arithmetic.ReversePolishNotation(formula);
        Dictionary<string, bool> variables = Arithmetic.GetVariables(rpn);
        var arrTable = Arithmetic.TruthTable(rpn, variables);

        var sdnf = await Arithmetic.SdnfAsync(arrTable, variables, rpn);
        var sknf = await Arithmetic.SknfAsync(arrTable, variables, rpn);

        ResultText.Text += counter + ") ";
        foreach (var item in rpn) {
          ResultText.Text += item.Value;
        }
        ResultText.Text += Environment.NewLine;

        for (int i = 0; i < (int)Math.Pow(2, variables.Count); i++) {
          for (int j = 0; j < variables.Count + 1; j++) {
            ResultText.Text += arrTable[i, j];
          }
          ResultText.Text += Environment.NewLine;
        }
        counter++;

        ResultText.Text += "PCNF: " + sknf + Environment.NewLine;
        ResultText.Text += "PDNF: " + sdnf + Environment.NewLine;
        ResultText.Text += "-------------------------" + Environment.NewLine; 
      }
    }

    private void ButtonWriteToFile_Click(object sender, RoutedEventArgs e) {
      WorkWithFile.WriteToFile(ResultText);
    }

    private void ButtonExit_Click(object sender, RoutedEventArgs e) {
      Close();
    }

    private void ButtonAbout_Click(object sender, RoutedEventArgs e) {
      AboutWindow aboutWindow = new AboutWindow();
      aboutWindow.ShowDialog();
    }
  }
}
