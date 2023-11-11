using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Entidades
{
    public class CambioEstado
    {
        // Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCambioEstado { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        // Relación
        public Estado estado { get; set; }

        // Constructor
        public CambioEstado(DateTime fechaHoraInicio, Estado estado)
        {
            // Inicializar atributos
            this.fechaHoraInicio = fechaHoraInicio;
            // Inicializar relación
            this.estado = estado;
        }

        // Métodos

        public void setFechaHoraInicio(DateTime fechaHoraInicio)
        {
            
            this.fechaHoraInicio = fechaHoraInicio;
        }
        public DateTime getFechaHoraInicio()
        {
            
            return fechaHoraInicio;
        }

        public string getNombreEstado()
        {
            // Implementación del método
            if (estado != null)
            {
                return estado.nombre;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
