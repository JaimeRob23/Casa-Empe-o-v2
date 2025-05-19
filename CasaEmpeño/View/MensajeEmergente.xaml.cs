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
using CasaEmpeno.View;

namespace CasaEmpeno.View
{
    /// <summary>
    /// Interaction logic for MensajeEmergente.xaml
    /// </summary>
    public partial class MensajeEmergente : Window
    {
        public MensajeEmergente(string mensaje)
        {
            InitializeComponent();
            MensajeTextBlock.Text = mensaje;

        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
