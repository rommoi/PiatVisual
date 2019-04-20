using System;
using System.Collections.Generic;
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

namespace PiatVisual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private PiatVM viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new PiatVM();
            viewModel.Winner += GetWinner;
            this.DataContext = viewModel;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            viewModel.Move(e.Key);
        }
        private void GetWinner()
        {
            MessageBoxResult Res =  MessageBox.Show("UR WIN!!!Congrats!!!", "WINNER!", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if(Res == MessageBoxResult.Yes)
            {
                viewModel.Restart();

            }
            else
            {
                viewModel.Winner -= GetWinner;
                Application.Current.Shutdown();
            }
        }
    }
}
