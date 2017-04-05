using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Portafolio2_Restaurante.Clases
{
    public class Distribuidor : Entidad
    {
        #region "Atributos"

        private string rNC;

        public string RNC
        {
            get { return rNC; }
            set { EstablecerPropiedad(ref rNC, value); }
        }

        private DiaSemana diaDeEntrega;

        public DiaSemana DiaDeEntrega
        {
            get { return diaDeEntrega; }
            set { EstablecerPropiedad(ref diaDeEntrega, value); }
        }

        private int porcientoMenosPorRetraso;

        public int PorcientoMenosPorRetraso
        {
            get { return porcientoMenosPorRetraso; }
            set { EstablecerPropiedad(ref porcientoMenosPorRetraso, value); }
        }

        private ObservableCollection<Ingrediente> ingredientes;

        public ObservableCollection<Ingrediente> Ingredientes
        {
            get { return ingredientes; }
            set { EstablecerPropiedad(ref ingredientes, value); }
        }

        private int total;

        public int Total
        {
            get { return total; }
            set { EstablecerPropiedad(ref total, value); }
        }

               
        #endregion

        #region "Constructores"

        public Distribuidor()
        {
                
        }

        public Distribuidor(int id, string nombre, string rNC, DiaSemana diaDeEntrega, int porcientoMenosPorRetraso, ObservableCollection<Ingrediente> ingredientes, int total, Modificable mod)
        {
            Id = id;
            RNC = rNC;
            Nombre = nombre;
            DiaDeEntrega = diaDeEntrega;
            PorcientoMenosPorRetraso = porcientoMenosPorRetraso;
            Ingredientes = ingredientes;
            Total = total;
            Mod = mod;
        }

        public Distribuidor(ObservableCollection<Ingrediente> ingredientes)
        {
            Ingredientes = ingredientes;
        }
        #endregion

        #region "Datos estaticos"

        private static List<Distribuidor> listaDistribuidores = null;

        public static List<Distribuidor> ListaDistribuidores
        {
            get
            {
                if (listaDistribuidores == null)
                {
                    listaDistribuidores = new List<Distribuidor>
                    {
                        new Distribuidor(1,"PUCMM","345215",DiaSemana.Monday, 10,new ObservableCollection<Ingrediente>{new Ingrediente(TipoIngrediente.ListaTipoIngredientes[0], 2)}, 10, Modificable.Parcial)
                    };
                }

                return listaDistribuidores;
            }
            set { listaDistribuidores = value; }
        }


        #endregion

        #region "Metodos/Funciones"

        public override string ToString()
        {
            return Id + "-" + Nombre;
        }
        #endregion
    }
}
