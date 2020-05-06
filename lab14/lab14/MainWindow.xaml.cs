using System.Windows;
using MVVM;

namespace lab14 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      DataContext = new ApplicationViewModel();
    }
  }
}
