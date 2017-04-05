using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Portafolio2_Restaurante.Clases
{
    public class Factura : Notificador
    {
        #region "Atributos"

        private int id;

        public int Id
        {
            get { return id; }
            set { EstablecerPropiedad(ref id, value); }
        }
        
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { EstablecerPropiedad(ref fecha, value); }
        }

        private ObservableCollection<Platillo> platillos;

        public ObservableCollection<Platillo> Platillos
        {
            get { return platillos; }
            set { EstablecerPropiedad(ref platillos, value); }
        }

        private int total;

        public int Total
        {
            get { return total; }
            set { EstablecerPropiedad(ref total, value); }
        }

        
        #endregion

        #region "Constructores"

        public Factura()
        {

        }

        public Factura(int id, DateTime fecha, ObservableCollection<Platillo> platillos, int total)
        {
            Id = id;
            Fecha = fecha;
            Platillos = platillos;
            Total = total;
        }

        public Factura(int id, DateTime fecha, ObservableCollection<Platillo> platillos)
        {
            Id = id;
            Fecha = fecha;
            Platillos = platillos;
        }

        #endregion

        #region "Datos estaticos"

        private static List<Factura> listaFacturas = null;

        public static List<Factura> ListaFacturas
        {
            get 
            {
                if (listaFacturas == null)
                {
                    listaFacturas = new List<Factura>();
                }

                return listaFacturas; 
            }
            set { listaFacturas = value; }
        }

        #endregion
    }
}
