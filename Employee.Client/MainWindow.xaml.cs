using System.Windows;
using Employee.Core.Models;
using Employee.Core.Views;

namespace Employee.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {
        public MainWindow(MainWindowVM viewModel)
        {
            InitializeComponent();
        }

        public void ShowHelp()
        {
            
        }

        public object GetContent()
        {
            throw new System.NotImplementedException();
        }
    }
}
