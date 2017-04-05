using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio2_Restaurante.Clases
{
    public class Extra : Notificador
    {
        #region "Enums"

        public enum TipoExtra
        {
            Payaso,
            Animador,
            Bizcocho
        }

        #endregion

        #region "Atributos"

        private TipoExtra nombre;

        public TipoExtra Nombre
        {
            get { return nombre; }
            set { EstablecerPropiedad(ref nombre, value); }
        }

        private int precio;

        public int Precio
        {
            get { return precio; }
            set { EstablecerPropiedad(ref precio, value); }
        }
        
        #endregion

        #region "Constructores"

        public Extra()
        {

        }

        public Extra(TipoExtra nombre, int precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        #endregion

        #region "Datos estaticos"


        private static List<Extra> listaExtras = null;

        public static List<Extra> ListaExtras
        {
            get
            {
                if (listaExtras == null)
                {
                    listaExtras = new List<Extra> 
                    { 
                        new Extra(TipoExtra.Animador,200),
                        new Extra(TipoExtra.Bizcocho,100),
                        new Extra(TipoExtra.Payaso,150)
                    };
                }
                return listaExtras;
            }
            set { listaExtras = value; }
        }

        #endregion

        #region "Metodos/Funciones"

        public override string ToString()
        {
            return Nombre + " - " + Precio + "$";
        }

        #endregion
    }
}
