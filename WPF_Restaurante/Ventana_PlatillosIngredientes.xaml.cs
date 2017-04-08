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
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using WPF_Restaurante.VW_Model;
using Portafolio2_Restaurante.Clases;
using System.Collections.ObjectModel;

namespace WPF_Restaurante
{
    /// <summary>
    /// Lógica de interacción para Ventana_Platillos.xaml
    /// </summary>
    public partial class Ventana_PlatillosIngredientes : Window
    {
        DoubleAnimation fadeInAnimation;
        public VM_Model ViewModel { get; set; }
        public Ventana_PlatillosIngredientes()
        {
            InitializeComponent();
            ViewModel = new VM_Model();
            ViewModel.ListadoPlatillos = new ObservableCollection<Platillo>(Platillo.ListaPlatillos);
            ViewModel.ListadoIngredientes = new ObservableCollection<TipoIngrediente>(TipoIngrediente.ListaTipoIngredientes);
            ViewModel.PlatilloActual = ViewModel.ListadoPlatillos[0];
            ViewModel.IngredienteActual = ViewModel.ListadoIngredientes[0];
            DataContext = ViewModel;
            platilloForm.Opacity = 0;
            fadeInAnimation = new DoubleAnimation();
            fadeInAnimation.From = 0;
            fadeInAnimation.To = 1;
            fadeInAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));

        }

        public void DesHabilitador()
        {
            if(ViewModel.IngredienteActual.Mod == Notificador.Modificable.No)
            {
                stp_ingredientes.IsEnabled = false;
            }
            else
            {
                stp_ingredientes.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.PlatilloActual.Ingredientes.Add(new Ingrediente(ViewModel.IngredienteAgregar, ViewModel.CantidadIngredienteAgregar));
            ViewModel.PlatilloActual.CostoManofactura += ViewModel.IngredienteAgregar.Precio * ViewModel.CantidadIngredienteAgregar;
            ViewModel.CantidadIngredienteAgregar = 0;
            ViewModel.IngredienteAgregar = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            platilloForm.BeginAnimation(StackPanel.OpacityProperty, fadeInAnimation);
            ViewModel.ListadoPlatillos.Add(new Platillo(ViewModel.ListadoPlatillos.Count+1,new ObservableCollection<Ingrediente>()));
            ViewModel.PlatilloActual = ViewModel.ListadoPlatillos.Last();
            platilloName.Focus();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Platillo.ListaPlatillos = ViewModel.ListadoPlatillos.ToList();
            VM_Model.Historial = "\n\n" + DateTime.Now + "\nSe añadido un nuevo platillo '" + ViewModel.PlatilloActual.Nombre + "'!" + VM_Model.Historial;
            MessageBox.Show("Se ha añadido un nuevo platillo");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Ventana_Adm ventana = new Ventana_Adm();
            Close();
            ventana.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ViewModel.ListadoIngredientes.Add(new TipoIngrediente(ViewModel.ListadoIngredientes.Count+1, Notificador.Modificable.Si));
            ViewModel.IngredienteActual = ViewModel.ListadoIngredientes[ViewModel.ListadoIngredientes.Count - 1];
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ViewModel.IngredienteActual.Mod = Notificador.Modificable.No;
            DesHabilitador();
            TipoIngrediente.ListaTipoIngredientes.Add(new TipoIngrediente(ViewModel.IngredienteActual.Id, ViewModel.IngredienteActual.Nombre, 0, ViewModel.IngredienteActual.Precio, ViewModel.IngredienteActual.Mod));
            VM_Model.Historial = "\n\n" + DateTime.Now + "\nSe añadido un nuevo ingrediente '" + ViewModel.IngredienteActual.Nombre + "'!" + VM_Model.Historial;
            MessageBox.Show("Se ha añadido un nuevo ingrediente");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Ventana_DistribuidoresAlmacen ventana = new Ventana_DistribuidoresAlmacen();
            Close();
            ventana.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Ventana_Reservacion ventana = new Ventana_Reservacion();
            Close();
            ventana.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ListadoPlatillos.Count == 1)
                ViewModel.ListadoPlatillos.Add(new Platillo());
            ViewModel.ListadoPlatillos.Remove(ViewModel.PlatilloActual);
            Platillo.ListaPlatillos = ViewModel.ListadoPlatillos.ToList();
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DesHabilitador();
        }
    }
}
