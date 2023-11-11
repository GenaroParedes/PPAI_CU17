using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Entidades
{
    public class Validacion
    {
        // Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdValidacion { get; set; }
        public string audioMensajeValidacion { get; set; }
        public string nombre { get; set; }
        public int nroOrden { get; set; }

        // Relación
        private TipoInformacion tipoInformacion;

        // Constructor
        public Validacion(string audioMensajeValidacion, string nombre, int nroOrden, TipoInformacion tipoInformacion)
        {
            // Inicializar atributos
            this.audioMensajeValidacion = audioMensajeValidacion;
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            

            // Inicializar relación
           this.tipoInformacion = tipoInformacion;
        }

        // Método
        public string getMensaje()
        {
            // Implementación del método
            return this.nombre;
        }
    }

  

}
