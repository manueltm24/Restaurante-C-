using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio2_Restaurante.Clases
{
    public class Platillo : Entidad
    {
        #region "Atributos"

        private ObservableCollection<Ingrediente> ingredientes;

        public ObservableCollection<Ingrediente> Ingredientes
        {
            get { return ingredientes; }
            set { EstablecerPropiedad(ref ingredientes, value); }
        }

        private int costoManofactura;

        public int CostoManofactura
        {
            get { return costoManofactura; }
            set { EstablecerPropiedad(ref costoManofactura, value); }
        }
        
        private int precio;

        public int Precio
        {
            get { return precio; }
            set { EstablecerPropiedad(ref precio, value); }
        }

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { EstablecerPropiedad(ref cantidad, value); }
        }

        #endregion

        #region "Constructores"

        public Platillo()
        {

        }

        public Platillo(int id, string nombre, int cantidad, ObservableCollection<Ingrediente> ingredientes, int precio, int costoManofactura, Modificable mod)
        {
            Id = id;
            Nombre = nombre;
            Cantidad = cantidad;
            Ingredientes = ingredientes;
            Precio = precio;
            CostoManofactura = costoManofactura;
            Mod = mod;
        }

        public Platillo(int id, ObservableCollection<Ingrediente> ingredientes)
        {
            Id = id;
            Ingredientes = ingredientes;
        }

        #endregion

        #region "Datos estaticos"

        private static List<Platillo> listaPlatillos = null;

        public static List<Platillo> ListaPlatillos
        {
            get
            {
                if (listaPlatillos == null)
                {
                    listaPlatillos = new List<Platillo>
                    {
                        new Platillo(1, "Pizza de peperoni",0, new ObservableCollection<Ingrediente>{new Ingrediente(TipoIngrediente.ListaTipoIngredientes[0], 1), new Ingrediente(TipoIngrediente.ListaTipoIngredientes[1], 2), new Ingrediente(TipoIngrediente.ListaTipoIngredientes[2], 3), new Ingrediente(TipoIngrediente.ListaTipoIngredientes[3], 2), new Ingrediente(TipoIngrediente.ListaTipoIngredientes[4],2)}, 300, 243, Modificable.No),
                        new Platillo(2, "Pizza de jamón",0,  new ObservableCollection<Ingrediente>{new Ingrediente(TipoIngrediente.ListaTipoIngredientes[0], 1), new Ingrediente(TipoIngrediente.ListaTipoIngredientes[1], 2), new Ingrediente(TipoIngrediente.ListaTipoIngredientes[2], 3), new Ingrediente(TipoIngrediente.ListaTipoIngredientes[5], 2), new Ingrediente(TipoIngrediente.ListaTipoIngredientes[4],2)}, 275, 209, Modificable.No),
                        new Platillo(3, "Omelette de jamón y queso",0, new ObservableCollection<Ingrediente>{new Ingrediente(TipoIngrediente.ListaTipoIngredientes[0], 1),new Ingrediente(TipoIngrediente.ListaTipoIngredientes[6], 2),new Ingrediente(TipoIngrediente.ListaTipoIngredientes[4], 1),new Ingrediente(TipoIngrediente.ListaTipoIngredientes[7], 1)}, 150, 123, Modificable.No)
                    };
                }

                return listaPlatillos;
            }
            set { listaPlatillos = value; }
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
