
using CSharpProjectWPF.ViewModels;
using System.Windows;


namespace CSharpProjectWPF;


public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}