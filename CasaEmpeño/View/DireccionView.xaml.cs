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
    /// Lógica de interacción para DireccionView.xaml
    /// </summary>
    public partial class DireccionView : Window
    {
        public DireccionView()
        {
            InitializeComponent();
        }
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            RealizarEmpeñoView ventanaRecibo = new RealizarEmpeñoView();
            ventanaRecibo.Show();
            this.Close();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSiguiente_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
