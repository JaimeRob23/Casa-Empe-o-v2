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
    /// Lógica de interacción para RealizarEmpeñoView.xaml
    /// </summary>
    public partial class RealizarEmpeñoView : Window
    {
        public RealizarEmpeñoView()
        {
            InitializeComponent();
        }
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            EmpeñoEstimacionView ventanaEstimacion = new EmpeñoEstimacionView();
            ventanaEstimacion.Show();
            this.Close();
        }

        private void btnEntrega_Click(object sender, RoutedEventArgs e)
        {
            SeleccionSucursalView ventanaSucursal = new SeleccionSucursalView();
            ventanaSucursal.Show();
            this.Close();
        }

        private void btnRecibir_Click(object sender, RoutedEventArgs e)
        {
            DireccionView ventanaDirrecion = new DireccionView();
            ventanaDirrecion.Show();
            this.Close();
        }
    }
}
