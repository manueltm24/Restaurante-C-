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
    /// Lógica de interacción para Ventana_ExistenciaAlmacen.xaml
    /// </summary>
    public partial class Ventana_ExistenciaAlmacen : Window
    {
        public VM_Model ViewModel { get; set; }
        public Ventana_ExistenciaAlmacen()
        {
            InitializeComponent();
            ViewModel = new VM_Model();
            ViewModel.ListadoPlatillos = new ObservableCollection<Platillo>(Platillo.ListaPlatillos);
            ViewModel.ListadoDistribuidores = new ObservableCollection<Distribuidor>(Distribuidor.ListaDistribuidores);
            ViewModel.ListadoIngredientes = new ObservableCollection<TipoIngrediente>(TipoIngrediente.ListaTipoIngredientes);
            ViewModel.IngredienteActual = ViewModel.ListadoIngredientes[0];
            DataContext = ViewModel;
        }
    }
}
