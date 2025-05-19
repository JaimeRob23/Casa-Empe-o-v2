﻿using System;
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
    /// Interaction logic for ProductoEncontradoView.xaml
    /// </summary>
    public partial class ProductoEncontradoView : Window
    {
        public ProductoEncontradoView()
        {
            InitializeComponent();
        }
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            BuscarProducto ventanaBuscarProducto = new BuscarProducto();
            ventanaBuscarProducto.Show();
            this.Close();
        }
    }
}
