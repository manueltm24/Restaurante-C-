using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio2_Restaurante.Clases
{
    public class Almacen : Notificador
    {
        #region "Atributos"

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { EstablecerPropiedad(ref fecha, value); }
        }

        private static int sumaDeTotales;

        public static int SumaDeTotales
        {
            get { return sumaDeTotales; }
            set { sumaDeTotales = value; }
        }

        #endregion

        #region "Constructores"
        public Almacen()
        {

        }
        public Almacen(DateTime fecha)
        {
            Fecha = fecha;
        }
        #endregion


    }
}
