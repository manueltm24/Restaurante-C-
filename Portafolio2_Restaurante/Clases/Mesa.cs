using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio2_Restaurante.Clases
{
    public class Mesa : Notificador
    {
        #region "Atributos"

        private int numero;

        public int Numero
        {
            get { return numero; }
            set { EstablecerPropiedad(ref numero, value); }
        }

        private int cantidadSillas;

        public int CantidadSillas
        {
            get { return cantidadSillas; }
            set { EstablecerPropiedad(ref cantidadSillas, value); }
        }

        private int precio;

        public int Precio
        {
            get { return precio; }
            set { EstablecerPropiedad(ref precio, value); }
        }


        #endregion

        #region "Construtores"

        public Mesa()
        {

        }

        public Mesa(int numero, int cantidadSillas, int precio, Modificable mod)
        {
            Numero = numero;
            CantidadSillas = cantidadSillas;
            Precio = precio;
            Mod = mod;
        }

        #endregion

        #region "Datos estaticos"

        private static List<Mesa> listaMesas = null;

        public static List<Mesa> ListaMesas
        {
            get
            {
                if (listaMesas == null)
                {
                    listaMesas = new List<Mesa> 
                    { 
                        new Mesa(1,0,500,Modificable.Parcial), 
                        new Mesa(2,6,100,Modificable.Parcial), 
                        new Mesa(3,4,80,Modificable.Parcial)
                    };
                }
                return listaMesas;
            }
            set { listaMesas = value; }
        }


        #endregion

        #region "Metodos/Funciones"

        public override string ToString(){
            if(Numero == 1)
            {
                return "Todo el local " + (ListaMesas.Count-1) + " mesas " + Precio + "$";
            }
            return "Mesa #" + Numero + " - " + CantidadSillas + " sillas " + Precio + "$";
        }

        #endregion
    }
}
