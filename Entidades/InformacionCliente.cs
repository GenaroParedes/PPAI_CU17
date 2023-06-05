using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Entidades
{
    public class InformacionCliente
    {
        // Atributos
        public string datoAValidar { get; set; }

        // Relaciones
        public Validacion validacion { get; set; }
        public TipoInformacion tipoInformacion { get; set; }

        // Constructor
        public InformacionCliente(string datoAValidar, Validacion validacion, TipoInformacion TipoInformacion)
        {
            // Inicializar atributos
            this.datoAValidar = datoAValidar;

            // Inicializar relaciones
            this.validacion = validacion;
            this.tipoInformacion = tipoInformacion;
        }

        //Metodos de Seteo

        public void setDatoAValidar(string datoAValidar)
        {
            this.datoAValidar = datoAValidar;
        }

        public String getdatoAValidar()
        {
            return this.datoAValidar;
        }

        // Métodos      
        public bool esValidacion(string val)
        {
            bool bandera = false;
            string nombreVal = this.validacion.nombre;
            if (val == nombreVal)
            {
                bandera = true;
            }
            return bandera;
        }   

        public bool esInformacionCorrecta(string info)
        {
            bool bandera = false;
            if(info == this.datoAValidar)
            {
                bandera = true;
            }
            return bandera;
        }              
    }
}   

