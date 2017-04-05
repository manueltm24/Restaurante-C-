using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio2_Restaurante.Clases
{
    public class Empleado : Entidad
    {

        #region "Enums"

        public enum GeneroSexual
        {
            Femenino,
            Masculino
        }

        public enum Cargos
        {
            Camarero,
            Cocinero,
            Cajero,
            CEO,
            Payaso,
            Gerente,
            Conserje
        }

        #endregion
        #region "Atributos"
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { EstablecerPropiedad(ref apellido, value); }
        }

        private GeneroSexual sexo;

        public GeneroSexual Sexo
        {
            get { return sexo; }
            set { EstablecerPropiedad(ref sexo, value); }
        }
        
        private Cargos cargo;

        public Cargos Cargo
        {
            get { return cargo; }
            set { EstablecerPropiedad(ref cargo, value); }
        }

        private DateTime horaDeEntrada;

        public DateTime HoraDeEntrada
        {
            get { return  horaDeEntrada; }
            set { EstablecerPropiedad(ref horaDeEntrada, value); }
        }

        private DateTime horaDeSalida;

        public DateTime HoraDeSalida
        {
            get { return horaDeSalida; }
            set { EstablecerPropiedad(ref horaDeSalida, value); }
        }

        private DiaSemana diaDeTrabajo;

        public DiaSemana DiaDeTrabajo
        {
            get { return diaDeTrabajo; }
            set { EstablecerPropiedad(ref diaDeTrabajo, value); }
        }

        private int sueldo;

        public int Sueldo
        {
            get { return sueldo; }
            set { EstablecerPropiedad(ref sueldo, value); }
        }

        private int horasExtras;

        public int HorasExtras
        {
            get { return horasExtras; }
            set { EstablecerPropiedad(ref horasExtras, value); }
        }

        private int pagoPorHorasExtras;

        public int PagoPorHorasExtras
        {
            get { return pagoPorHorasExtras; }
            set { EstablecerPropiedad(ref pagoPorHorasExtras, value); }
        }

        private int sueldoTotal;

        public int SueldoTotal
        {
            get { return sueldoTotal; }
            set { EstablecerPropiedad(ref sueldoTotal, value); }
        }    
                
        #endregion

        #region "Constructores"

        public Empleado()
        {

        }

        public Empleado(int id, string nombre, string apellido, GeneroSexual sexo, Cargos cargo, DateTime horaDeEntrada, DateTime horaDeSalida, DiaSemana diaDeTrabajo, int sueldo, int horasExtras, int pagoPorHorasExtra, int sueldoTotal, Modificable mod)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Sexo = sexo;
            Cargo = cargo;
            HoraDeEntrada = horaDeEntrada;
            HoraDeSalida = horaDeSalida;
            DiaDeTrabajo = diaDeTrabajo;
            Sueldo = sueldo;
            HorasExtras = horasExtras;
            PagoPorHorasExtras = pagoPorHorasExtra;
            SueldoTotal = sueldoTotal;
            Mod = mod;
        }

        public Empleado(int id)
        {
            Id = id;
        }

        #endregion

        #region "Datos estaticos"

        private static List<Empleado> listaEmpleados = null;

        public static List<Empleado> ListaEmpleados
        {
            get
            {
                if (listaEmpleados == null)
                {
                    listaEmpleados = new List<Empleado> 
                    { 
                        new Empleado(1, "José", "Alonso", GeneroSexual.Masculino, Cargos.CEO, new DateTime(01,01,01,9,0,0), new DateTime(01,01,01,12,0,0), DiaSemana.Wednesday, 20000, 3, 700, 22100, Modificable.Parcial)
                    };
                }
                return listaEmpleados;
            }
            set { listaEmpleados = value; }
        }

        #endregion
    }
}
