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

namespace CasaEmpeño.View
{
    /// <summary>
    /// Lógica de interacción para MainViewCliente.xaml
    /// </summary>
    public partial class MainViewCliente : Window
    {
        public MainViewCliente()
        {
            InitializeComponent();
        }
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEmpeñar_Click(object sender, RoutedEventArgs e)
        {
            RealizarEmpeñoView ventanaEmpeño = new RealizarEmpeñoView();
            ventanaEmpeño.Show();
            this.Close();
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            ProductosView ventanaCompra = new ProductosView();
            ventanaCompra.Show();
            this.Close();
        }
    }
}
