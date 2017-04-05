using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio2_Restaurante.Clases
{
    public class TipoIngrediente: Entidad
    {
        #region "Atributos"

        private int cantidadAlmacen;

        public int CantidadAlmacen
        {
            get { return cantidadAlmacen; }
            set { EstablecerPropiedad(ref cantidadAlmacen, value); }
        }

        private int precio;

        public int Precio
        {
            get { return precio; }
            set { EstablecerPropiedad(ref precio, value); }
        }
        
        #endregion

        #region "Constructores"

        public TipoIngrediente()
        {

        }

        public TipoIngrediente(int id, string nombre, int cantidadAlmacen, int precio, Modificable mod)
        {
            Id = id;
            Nombre = nombre;
            CantidadAlmacen = cantidadAlmacen;
            Precio = precio;
            Mod = mod;
        }

        public TipoIngrediente(int id, Modificable mod)
        {
            Id = id;
            Mod = mod;
        }

        #endregion

        #region "Datos estaticos"

        private static List<TipoIngrediente> listaTipoIngredientes = null;

        public static List<TipoIngrediente> ListaTipoIngredientes
        {
            get
            {
                if (listaTipoIngredientes == null)
                {
                    listaTipoIngredientes = new List<TipoIngrediente>
                    {
                        new TipoIngrediente(1,"Tomate",200,5, Modificable.No),
                        new TipoIngrediente(2,"Queso",50,25, Modificable.No),
                        new TipoIngrediente(3,"Harina para masa",100,40, Modificable.No),
                        new TipoIngrediente(4,"Peperoni",50,30, Modificable.No),
                        new TipoIngrediente(5,"Oregano",20,4, Modificable.No),
                        new TipoIngrediente(6,"Jamon",50,10, Modificable.No),
                        new TipoIngrediente(7,"Huevo",80,3, Modificable.No),
                        new TipoIngrediente(8,"Aceite",20,20, Modificable.No)
                    };
                }

                return listaTipoIngredientes;
            }
            set { listaTipoIngredientes = value; }
        }


        #endregion

        #region "Metodos"

        public override string ToString()
        {
            return Nombre;
        }

        #endregion
    }
}
