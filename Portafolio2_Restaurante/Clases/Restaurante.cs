using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio2_Restaurante.Clases
{
    public class Restaurante : Notificador
    {
        #region "Atributos"

        private int ganancias;

        public int Ganancias
        {
            get { return ganancias; }
            set { EstablecerPropiedad(ref ganancias, value); }
        }

        private int perdidas;

        public int Perdidas
        {
            get { return perdidas; }
            set { EstablecerPropiedad(ref perdidas, value); }
        }

        private int total;

        public int Total
        {
            get { return total; }
            set { EstablecerPropiedad(ref total, value); }
        }


        #endregion

        #region "Constructores"

        public Restaurante()
        {

        }
        public Restaurante(int ganancias, int perdidas)
        {
            Ganancias = ganancias;
            Perdidas = perdidas;
        }
        #endregion
    }
}
