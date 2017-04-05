using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Portafolio2_Restaurante.Clases;

namespace WPF_Restaurante.VW_Model
{
    public class VM_Model : Notificador
    {
        #region "Diccionarios"

        private Dictionary<Entidad.DiaSemana, String> dias = new Dictionary<Entidad.DiaSemana, string> { { Entidad.DiaSemana.Monday, "Lunes" }, { Entidad.DiaSemana.Tuesday, "Martes" }, { Entidad.DiaSemana.Wednesday, "Miercoles" }, { Entidad.DiaSemana.Thursday, "Jueves" }, { Entidad.DiaSemana.Friday, "Viernes" }, { Entidad.DiaSemana.Saturday, "Sabado" }, { Entidad.DiaSemana.Sunday, "Domingo" } };
        public Dictionary<Entidad.DiaSemana, String> Dias
        {
            get { return dias; }
            set { dias = value; }
        }

        private Dictionary<Empleado.GeneroSexual, String> tipoGeneroSexual = new Dictionary<Empleado.GeneroSexual, string> { { Empleado.GeneroSexual.Femenino, "Femenino" }, { Empleado.GeneroSexual.Masculino, "Masculino" } };
        public Dictionary<Empleado.GeneroSexual, String> TipoGeneroSexual
        {
            get { return tipoGeneroSexual; }
            set { tipoGeneroSexual = value; }
        }

        private Dictionary<Notificador.Modificable, String> tipoModificable = new Dictionary<Notificador.Modificable, string> { { Notificador.Modificable.No, "No" }, { Notificador.Modificable.Si, "Si" }, { Notificador.Modificable.Parcial, "Parcialmente" }};
        public Dictionary<Notificador.Modificable, String> TipoModificable
        {
            get { return tipoModificable; }
            set { tipoModificable = value; }
        }

        private Dictionary<Empleado.Cargos, String> tipoCargos = new Dictionary<Empleado.Cargos, string> { { Empleado.Cargos.Cajero, "Cajero" }, { Empleado.Cargos.Camarero, "Camarero" }, { Empleado.Cargos.CEO, "CEO" }, { Empleado.Cargos.Cocinero, "Cocinero" }, { Empleado.Cargos.Conserje, "Conserje" }, { Empleado.Cargos.Gerente, "Gerente" }, { Empleado.Cargos.Payaso, "Payaso" } };
        public Dictionary<Empleado.Cargos, String> TipoCargos
        {
            get { return tipoCargos; }
            set { tipoCargos = value; }
        }

        #endregion

        #region "Ventana inicio"

        private ObservableCollection<Factura> listadoFacturas;
        public ObservableCollection<Factura> ListadoFacturas { get { return listadoFacturas; } set { EstablecerPropiedad(ref listadoFacturas, value); } }
        private Factura facturaActual;
        public Factura FacturaActual { get { return facturaActual; } set { EstablecerPropiedad(ref facturaActual, value); } }
        public ObservableCollection<Platillo> ListadoPlatillos { get; set; }
        public Platillo PlatilloABorrar { get; set; }

        private int cantidadAgregar;

        public int CantidadAgregar
        {
            get { return cantidadAgregar; }
            set { EstablecerPropiedad(ref cantidadAgregar, value); }
        }


        private static string historial;

        public static string Historial
        {
            get { return historial; }
            set { historial = value; }
        }


        private ObservableCollection<Empleado> listadoEmpleados;

        public ObservableCollection<Empleado> ListadoEmpleados
        {
            get { return listadoEmpleados; }
            set { EstablecerPropiedad(ref listadoEmpleados, value); }
        }

        private Empleado empleadoActual;

        public Empleado EmpleadoActual
        {
            get { return empleadoActual; }
            set { EstablecerPropiedad(ref empleadoActual, value); }
        }

        private Restaurante restaurante;

        public Restaurante Restaurante
        {
            get { return restaurante; }
            set { EstablecerPropiedad(ref restaurante, value); }
        }


        #endregion

        #region "Ventana platillos"

        private Platillo platilloActual;

        public Platillo PlatilloActual
        {
            get { return platilloActual; }
            set { EstablecerPropiedad(ref platilloActual, value); }
        }

        private ObservableCollection<TipoIngrediente> listadoIngredientes;

        public ObservableCollection<TipoIngrediente> ListadoIngredientes
        {
            get { return listadoIngredientes; }
            set { EstablecerPropiedad(ref listadoIngredientes, value); }
        }

        private TipoIngrediente ingredienteActual;

        public TipoIngrediente IngredienteActual
        {
            get { return ingredienteActual; }
            set { EstablecerPropiedad(ref ingredienteActual, value); }
        }

        private TipoIngrediente ingredienteAgregar;

        public TipoIngrediente IngredienteAgregar
        {
            get { return ingredienteAgregar; }
            set { EstablecerPropiedad(ref ingredienteAgregar, value); }
        }

        private int cantidadIngredienteAgregar;

        public int CantidadIngredienteAgregar
        {
            get { return cantidadIngredienteAgregar; }
            set { EstablecerPropiedad(ref cantidadIngredienteAgregar, value); }
        }
        

        #endregion

        #region "Ventana Distribuidores/Almacen"

        private ObservableCollection<Distribuidor> listadoDistribuidores;

        public ObservableCollection<Distribuidor> ListadoDistribuidores 
        {
            get { return listadoDistribuidores; }
            set { EstablecerPropiedad(ref listadoDistribuidores, value); }
        }


        private Distribuidor distribuidorActual;

        public Distribuidor DistribuidorActual
        {
            get { return distribuidorActual; }
            set {EstablecerPropiedad(ref distribuidorActual, value);}

        }

        private Almacen almacen;

        public Almacen Almacen
        {
            get { return almacen; }
            set { EstablecerPropiedad(ref almacen, value); }
        }

        
        #endregion

        #region "Ventana Reservacion/Mesa"

        private ObservableCollection<Reservacion> listadoReservaciones;

        public ObservableCollection<Reservacion> ListadoReservaciones
        {
            get { return listadoReservaciones; }
            set { EstablecerPropiedad(ref listadoReservaciones, value); }
        }

        private Reservacion reservacionActual;

        public Reservacion ReservacionActual
        {
            get { return reservacionActual; }
            set { EstablecerPropiedad(ref reservacionActual, value); }
        }
        
        private ObservableCollection<Mesa> listadoMesas;

        public ObservableCollection<Mesa> ListadoMesas
        {
            get { return listadoMesas; }
            set { EstablecerPropiedad(ref listadoMesas, value); }
        }

        private Mesa mesaActual;

        public Mesa MesaActual
        {
            get { return mesaActual; }
            set { EstablecerPropiedad(ref mesaActual, value); }
        }

        private ObservableCollection<Extra> listadoExtras;

        public ObservableCollection<Extra> ListadoExtras
        {
            get { return listadoExtras; }
            set { listadoExtras = value; }
        }

        private Extra extraActual;

        public Extra ExtraActual
        {
            get { return extraActual; }
            set { extraActual = value; }
        }


        #endregion
    }
}
