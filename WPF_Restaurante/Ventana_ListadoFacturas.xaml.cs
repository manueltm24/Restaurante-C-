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
    /// Lógica de interacción para Ventana_ListadoFacturas.xaml
    /// </summary>
    public partial class Ventana_ListadoFacturas : Window
    {
        public VM_Model ViewModel { get; set; }
        public Ventana_ListadoFacturas()
        {
            InitializeComponent();
            ViewModel = new VM_Model();
            ViewModel.ListadoFacturas = new ObservableCollection<Factura>(Factura.ListaFacturas);
            ViewModel.ListadoPlatillos = new ObservableCollection<Platillo>(Platillo.ListaPlatillos);
            ViewModel.ListadoEmpleados = new ObservableCollection<Empleado>(Empleado.ListaEmpleados);

            ViewModel.ListadoFacturas.Add(new Factura(ViewModel.ListadoFacturas.Count + 1, DateTime.Now, new ObservableCollection<Platillo>()));
            
            if (ViewModel.ListadoFacturas.Count > 0)
                ViewModel.FacturaActual = ViewModel.ListadoFacturas[ViewModel.ListadoFacturas.Count - 1];
            else
                ViewModel.FacturaActual = ViewModel.ListadoFacturas[0];     

            ViewModel.EmpleadoActual = ViewModel.ListadoEmpleados[0];
            ViewModel.FacturaActual.Platillos = new ObservableCollection<Platillo>();

            DataContext = ViewModel;
        }
    }
}
