using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio2_Restaurante.Clases
{
    public class Cliente : Entidad
    {
        #region "Ätributos"
        private string cedula;

        public string Cedula
        {
            get { return cedula; }
            set { EstablecerPropiedad(ref cedula, value); }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { EstablecerPropiedad(ref apellido, value); }
        }

        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { EstablecerPropiedad(ref telefono, value); }
        }
        
        #endregion
        #region "Constructores"
        public Cliente()
        {

        }
        public Cliente(string cedula,string nombre, string apellido, string telefono)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
        }
        #endregion

    }
}
