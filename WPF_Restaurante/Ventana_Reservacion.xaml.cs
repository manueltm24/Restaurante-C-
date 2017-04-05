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
    /// Lógica de interacción para Ventana_Reservacion.xaml
    /// </summary>
    public partial class Ventana_Reservacion : Window
    {
        public VM_Model ViewModel { get; set; }
        public Ventana_Reservacion()
        {
            InitializeComponent();
            ViewModel = new VM_Model();
            ViewModel.ListadoReservaciones = new ObservableCollection<Reservacion>(Reservacion.ListaReservaciones);
            ViewModel.ListadoExtras = new ObservableCollection<Extra>(Extra.ListaExtras);
            ViewModel.ListadoMesas = new ObservableCollection<Mesa>(Mesa.ListaMesas);
            ViewModel.ReservacionActual = ViewModel.ListadoReservaciones[0];
            ViewModel.MesaActual = ViewModel.ListadoMesas[0];
            DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ventana_DistribuidoresAlmacen ventana = new Ventana_DistribuidoresAlmacen();
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
            Ventana_Adm ventana = new Ventana_Adm();
            Close();
            ventana.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ViewModel.ListadoReservaciones.Add(new Reservacion(DateTime.Now, new Cliente(), new Mesa(), new ObservableCollection<Extra>()));
            ViewModel.ReservacionActual = ViewModel.ListadoReservaciones[ViewModel.ListadoReservaciones.Count - 1];
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Reservacion.ListaReservaciones = ViewModel.ListadoReservaciones.ToList();
            VM_Model.Historial = "\n\n" + DateTime.Now + "\nSe añadido una nueva reservacion para el día " + ViewModel.ReservacionActual.Fecha + " mesa #" + ViewModel.ReservacionActual.Mesa.CantidadSillas + "!" + VM_Model.Historial;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ViewModel.ListadoMesas.Add(new Mesa(ViewModel.ListadoMesas.Count+1,1,0, Notificador.Modificable.Si));
            ViewModel.MesaActual = ViewModel.ListadoMesas[ViewModel.ListadoMesas.Count - 1];
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ViewModel.MesaActual.Mod = Notificador.Modificable.Parcial;
            Mesa.ListaMesas = ViewModel.ListadoMesas.ToList();
            VM_Model.Historial = "\n\n" + DateTime.Now + "\nSe añadido una nueva mesa con " + ViewModel.MesaActual.CantidadSillas + " silla(s)!" + VM_Model.Historial;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ListadoMesas.Count == 1)
                ViewModel.ListadoMesas.Add(new Mesa(ViewModel.ListadoMesas.Count, 1,0, Notificador.Modificable.Si));
            ViewModel.ListadoMesas.Remove(ViewModel.MesaActual);
            Mesa.ListaMesas = ViewModel.ListadoMesas.ToList();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            ViewModel.ReservacionActual.Extras.Add(new Extra(ViewModel.ExtraActual.Nombre, ViewModel.ExtraActual.Precio));
            ViewModel.ReservacionActual.Total += ViewModel.ExtraActual.Precio;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.ReservacionActual.Total = ViewModel.ReservacionActual.Mesa.Precio;
            foreach (Extra extra in ViewModel.ReservacionActual.Extras)
            {
                ViewModel.ReservacionActual.Total += extra.Precio;
            }
        }
    }
}
