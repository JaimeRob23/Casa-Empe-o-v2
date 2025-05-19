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
using System.Windows.Shapes;
using CasaEmpeño.ViewModel;

namespace CasaEmpeño.View
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            OpenUserManagerCommand = new ViewModelCommand(ExecuteOpenUserManagerCommand);
            OpenProductManagerCommand = new ViewModelCommand(ExecuteOpenProductManagerCommand);
        }

        private void BtnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public ICommand OpenUserManagerCommand { get; }
        public ICommand OpenProductManagerCommand { get; }


        private void ExecuteOpenUserManagerCommand(object obj)
        {
            var clienteView = new ClienteView();
            clienteView.Show();
        }

        private void ExecuteOpenProductManagerCommand(object obj)
        {
            var productoView = new ProductoView();
            productoView.Show();
        }
    }
}
