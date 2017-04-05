using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio2_Restaurante.Clases
{
    public class Reservacion : Notificador
    {
        #region "Atributos"

        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set { EstablecerPropiedad(ref cliente, value); }
        }
        
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { EstablecerPropiedad(ref fecha, value); }
        }

        private DateTime hora;

        public DateTime Hora
        {
            get { return hora; }
            set { EstablecerPropiedad(ref hora, value); }
        }

        private Mesa mesa;

        public Mesa Mesa
        {
            get { return  mesa; }
            set { EstablecerPropiedad(ref mesa, value); }
        }

        private ObservableCollection<Extra> extras;

        public ObservableCollection<Extra> Extras
        {
            get { return extras; }
            set { extras = value; }
        }


        private int total;

        public int Total
        {
            get { return total; }
            set { EstablecerPropiedad(ref total, value); }
        }
                
        #endregion

        #region "Constructores"

        public Reservacion()
        {
                
        }

        public Reservacion(Cliente cliente, DateTime fecha, DateTime hora, Mesa mesa, ObservableCollection<Extra> extras, int total, Modificable mod) 
        {
            Cliente = cliente;
            Fecha = fecha;
            Hora = hora;
            Mesa = mesa;
            Extras = extras;
            Total = total;
            Mod = mod;
        }

        public Reservacion(DateTime fecha, Cliente cliente, Mesa mesa, ObservableCollection<Extra> extras)
        {
            Cliente = cliente;
            Fecha = fecha;
            Mesa = mesa;
            Extras = extras;
        }
        #endregion

        #region "Datos estaticos"

        private static List<Reservacion> listaReservaciones = null;

        public static List<Reservacion> ListaReservaciones
        {
            get 
            {
                if (listaReservaciones == null)
                {
                    listaReservaciones = new List<Reservacion> 
                    { 
                        new Reservacion(new Cliente("555-5555555-5","Manuel","Tolentino","809-555-5555"),DateTime.Now.AddDays(+7),DateTime.Now.AddHours(-2),Mesa.ListaMesas[1], new ObservableCollection<Extra>{ Extra.ListaExtras[2] },250, Modificable.No)
                    };
                }
                return listaReservaciones; 
            }
            set { listaReservaciones = value; }
        }


        #endregion
    }
}
