using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio2_Restaurante.Clases
{
    public  abstract class Entidad : Notificador
    {
        #region "Enum"

        public enum DiaSemana { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        
        #endregion

        #region "Atributos"

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { EstablecerPropiedad(ref nombre, value); }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { EstablecerPropiedad(ref id, value); }
        }


        #endregion
        
        
    }
}
