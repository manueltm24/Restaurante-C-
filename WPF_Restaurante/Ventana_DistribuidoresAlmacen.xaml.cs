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
using WPF_Restaurante.VW_Model;
using Portafolio2_Restaurante.Clases;
using System.Collections.ObjectModel;

namespace WPF_Restaurante
{
    /// <summary>
    /// Lógica de interacción para Ventana_Distribuidores_Almacen.xaml
    /// </summary>
    public partial class Ventana_DistribuidoresAlmacen : Window
    {
        public VM_Model ViewModel { get; set; }
        public Ventana_DistribuidoresAlmacen()
        {
            InitializeComponent();
            ViewModel = new VM_Model();
            ViewModel.Almacen = new Almacen(DateTime.Now);
            ViewModel.ListadoPlatillos = new ObservableCollection<Platillo>(Platillo.ListaPlatillos);
            ViewModel.ListadoDistribuidores = new ObservableCollection<Distribuidor>(Distribuidor.ListaDistribuidores);
            ViewModel.DistribuidorActual = ViewModel.ListadoDistribuidores[0];
            ViewModel.ListadoIngredientes = new ObservableCollection<TipoIngrediente>(TipoIngrediente.ListaTipoIngredientes);
            ViewModel.IngredienteActual = ViewModel.ListadoIngredientes[0];
            DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ventana_Adm ventana = new Ventana_Adm();
            Close();
            ventana.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Ventana_PlatillosIngredientes ventana = new Ventana_PlatillosIngredientes();
            Close();
            ventana.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewModel.ListadoDistribuidores.Add(new Distribuidor(new ObservableCollection<Ingrediente>()));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Ventana_ExistenciaAlmacen ventana = new Ventana_ExistenciaAlmacen();
            ventana.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ViewModel.DistribuidorActual.Ingredientes.Add(new Ingrediente(ViewModel.IngredienteAgregar, ViewModel.CantidadIngredienteAgregar));
            ViewModel.DistribuidorActual.Total += ViewModel.IngredienteAgregar.Precio * ViewModel.CantidadIngredienteAgregar;

            ViewModel.CantidadIngredienteAgregar = 0;
            ViewModel.IngredienteAgregar = null;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Ventana_Reservacion ventana = new Ventana_Reservacion();
            Close();
            ventana.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            foreach(TipoIngrediente ingrediente in ViewModel.ListadoIngredientes)
            {
                foreach(Ingrediente ingredienteD in ViewModel.DistribuidorActual.Ingredientes)
                {
                    if(ingrediente.Nombre == ingredienteD.Tipo.Nombre)
                    {
                        ingrediente.CantidadAlmacen += ingredienteD.Cantidad;
                    }
                }
            }

            TipoIngrediente.ListaTipoIngredientes = ViewModel.ListadoIngredientes.ToList();

            if(ViewModel.DistribuidorActual.DiaDeEntrega.ToString() != ViewModel.Almacen.Fecha.DayOfWeek.ToString())
            {
                MessageBox.Show("Pedido recibido con retraso");
                VM_Model.Historial = "\n\n" + DateTime.Now + "\nSe recibido un nuevo pedido de " + ViewModel.DistribuidorActual.Nombre + "! (RETRASADO)" + VM_Model.Historial;
                Almacen.SumaDeTotales += ViewModel.DistribuidorActual.Total - ViewModel.DistribuidorActual.Total * ViewModel.DistribuidorActual.PorcientoMenosPorRetraso / 100;
            }
            else
            {
                VM_Model.Historial = "\n\n" + DateTime.Now + "\nSe recibido un nuevo pedido de " + ViewModel.DistribuidorActual.Nombre + "!" + VM_Model.Historial;
                Almacen.SumaDeTotales += ViewModel.DistribuidorActual.Total;
            }

            MessageBox.Show("Pedido recibido correctamente");

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Distribuidor.ListaDistribuidores = ViewModel.ListadoDistribuidores.ToList();
        }

    }
}
