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
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Ventana_Adm : Window
    {
        public VM_Model ViewModel { get; set; }
        public Ventana_Adm()
        {
            InitializeComponent();
            ViewModel = new VM_Model();
            ViewModel.Restaurante = new Restaurante();
            ViewModel.ListadoFacturas = new ObservableCollection<Factura>(Factura.ListaFacturas);
            ViewModel.ListadoPlatillos = new ObservableCollection<Platillo>(Platillo.ListaPlatillos);
            ViewModel.ListadoIngredientes = new ObservableCollection<TipoIngrediente>(TipoIngrediente.ListaTipoIngredientes);
            ViewModel.ListadoReservaciones = new ObservableCollection<Reservacion>(Reservacion.ListaReservaciones);
            ViewModel.ListadoEmpleados = new ObservableCollection<Empleado>(Empleado.ListaEmpleados);

            ViewModel.ListadoFacturas.Add(new Factura(ViewModel.ListadoFacturas.Count+1, DateTime.Now, new ObservableCollection<Platillo>()));

            if(ViewModel.ListadoFacturas.Count>0)
                ViewModel.FacturaActual = ViewModel.ListadoFacturas[ViewModel.ListadoFacturas.Count-1];
            else
                ViewModel.FacturaActual = ViewModel.ListadoFacturas[0];            
    
            ViewModel.EmpleadoActual = ViewModel.ListadoEmpleados[0];
            ViewModel.FacturaActual.Platillos = new ObservableCollection<Platillo>();
            DataContext = ViewModel;
        }

        private int noHayIngredientes() 
        {
            int no = 0;
            foreach (Ingrediente ingrediente in ViewModel.PlatilloActual.Ingredientes)
            {
                foreach (TipoIngrediente ingredienteT in ViewModel.ListadoIngredientes)
                {
                    if (ingrediente.Cantidad * ViewModel.CantidadAgregar > ingredienteT.CantidadAlmacen && no == 0)
                    {
                        MessageBox.Show("¡No hay suficientes ingredientes para realizar esa cantidad de platillos!");
                        no++;
                    }

                    if (ingrediente.Cantidad > ingredienteT.CantidadAlmacen && no == 0)
                    {
                        MessageBox.Show("¡No hay suficientes ingredientes para realizar ese platillo!");
                        no++;
                    }
                }
            }

            if (no > 0)
            {

                ViewModel.CantidadAgregar = 0;
                ViewModel.PlatilloActual = null;
            }

            return no;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.PlatilloActual == null || noHayIngredientes() > 0)
                return;
            
            
            ViewModel.FacturaActual.Platillos.Add(new Platillo(ViewModel.PlatilloActual.Id,ViewModel.PlatilloActual.Nombre,ViewModel.CantidadAgregar,ViewModel.PlatilloActual.Ingredientes,ViewModel.PlatilloActual.Precio, 0, Notificador.Modificable.No));
            ViewModel.FacturaActual.Total += ViewModel.PlatilloActual.Precio*ViewModel.CantidadAgregar;

            
            foreach (Ingrediente ingrediente in ViewModel.PlatilloActual.Ingredientes)
            {
                foreach (TipoIngrediente ingredienteT in ViewModel.ListadoIngredientes)
                {
                    if (ingrediente.Tipo.Nombre == ingredienteT.Nombre)
                    {
                        ingredienteT.CantidadAlmacen -= ingrediente.Cantidad * ViewModel.CantidadAgregar;
                    }
                }
            }

            ViewModel.PlatilloActual = null;
            ViewModel.CantidadAgregar = 0;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Ventana_ListadoFacturas ventana = new Ventana_ListadoFacturas();
            ventana.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ViewModel.FacturaActual.Id == 0 || ViewModel.FacturaActual.Total == 0)
            {
                MessageBox.Show("Esta factura no esta completa");
                return;
            }
            Factura.ListaFacturas.Add(new Factura(ViewModel.FacturaActual.Id, ViewModel.FacturaActual.Fecha, ViewModel.FacturaActual.Platillos, ViewModel.FacturaActual.Total));
            ViewModel.ListadoFacturas.Add(new Factura(ViewModel.ListadoFacturas.Count+1, DateTime.Now, new ObservableCollection<Platillo>()));
            ViewModel.FacturaActual = ViewModel.ListadoFacturas[ViewModel.ListadoFacturas.Count - 1];
            MessageBox.Show("Factura guardada");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Ventana_PlatillosIngredientes ventana = new Ventana_PlatillosIngredientes();
            Close();
            ventana.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Ventana_DistribuidoresAlmacen ventana = new Ventana_DistribuidoresAlmacen();
            Close();
            ventana.Show();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Ventana_Reservacion ventana = new Ventana_Reservacion();
            Close();
            ventana.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ViewModel.ListadoEmpleados.Add(new Empleado(ViewModel.ListadoEmpleados.Count+1));
            ViewModel.EmpleadoActual = ViewModel.ListadoEmpleados[ViewModel.ListadoEmpleados.Count - 1];
        }

        private void bt_guardar_Click(object sender, RoutedEventArgs e)
        {
            Empleado.ListaEmpleados = ViewModel.ListadoEmpleados.ToList();
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.Restaurante.Ganancias = 0;
            ViewModel.Restaurante.Perdidas = 0;
            ViewModel.Restaurante.Total = 0;

            foreach (Factura factura in ViewModel.ListadoFacturas)
            {
                ViewModel.Restaurante.Ganancias += factura.Total;
            }


            foreach (Reservacion reservacion in ViewModel.ListadoReservaciones)
            {
                ViewModel.Restaurante.Ganancias += reservacion.Total;
            }

            ViewModel.Restaurante.Perdidas += Almacen.SumaDeTotales;

            foreach (Empleado empleado in ViewModel.ListadoEmpleados)
            {
                ViewModel.Restaurante.Perdidas += empleado.SueldoTotal;
            }

            if(ViewModel.Restaurante.Ganancias<ViewModel.Restaurante.Perdidas)
            {
                ViewModel.Restaurante.Total = (-1) * (ViewModel.Restaurante.Ganancias - ViewModel.Restaurante.Perdidas);
                Mensaje.Content = "Este mes hubo perdidas!";
            }
            else
            {
                ViewModel.Restaurante.Total = ViewModel.Restaurante.Ganancias - ViewModel.Restaurante.Perdidas;
                Mensaje.Content = "Este mes hubo ganancias!";
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModel.PlatilloActual == null || noHayIngredientes() > 0)
                return;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ViewModel.EmpleadoActual.SueldoTotal = ViewModel.EmpleadoActual.Sueldo + ViewModel.EmpleadoActual.PagoPorHorasExtras*ViewModel.EmpleadoActual.HorasExtras;
        }
    }
}
