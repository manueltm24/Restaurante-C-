using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio2_Restaurante.Clases
{
    public class Ingrediente : Notificador
    {
        #region "Atributos"

        private TipoIngrediente tipo;

        public TipoIngrediente Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        #endregion

        #region "Constructores"

        public Ingrediente()
        {

        }

        public Ingrediente(TipoIngrediente tipo, int cantidad)
        {
            Tipo = tipo;
            Cantidad = cantidad;

        }

        #endregion


    }
}
