using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Entidades
{
    public class OpcionLlamada
    {
        // Atributos
        public string audioMensajeSubOpciones { get; set; }
        public string mensajeSubOpciones { get; set; }
        public string nombre { get; set; }
        public int nroOrden { get; set; }

        // Relación de agregación
        public List<SubOpcionLlamada> subOpciones { get; set; }
        public List<Validacion> validacion { get; set; }
        public SubOpcionLlamada subOpcionLlamada { get; set; }

        // Constructor
        public OpcionLlamada(string audioMensajeSubOpciones, string mensajeSubOpciones, string nombre, int nroOrden,
            List<SubOpcionLlamada> subOpciones, List<Validacion> Validacion)
        {
            // Inicializar atributos
            this.audioMensajeSubOpciones = audioMensajeSubOpciones;
            this.mensajeSubOpciones = mensajeSubOpciones;
            this.nombre = nombre;
            this.nroOrden = nroOrden;

            // Inicializar relación
            this.subOpciones = new List<SubOpcionLlamada>();
            this.validacion = new List<Validacion>();
        }

        //Metodos de Seteo

        public void setAudioMensajeSubOpciones(string audioMensajeSubOpciones)
        {
            this.audioMensajeSubOpciones = audioMensajeSubOpciones;
        }

        public String getAudioMensajeSubOpciones()
        {
            return this.audioMensajeSubOpciones;
        }
        public void setMensajeSubOpciones(string mensajeSubOpciones)
        {
            this.mensajeSubOpciones = mensajeSubOpciones;
        }

        public String getMensajeSubOpciones()
        {
            return this.mensajeSubOpciones;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public String getNombre()
        {
            return this.nombre;
        }
        public void setNroOrden(int nroOrden)
        {
            this.nroOrden = nroOrden;
        }

        public int getNroOrden()
        {
            return this.nroOrden;
        }

        // Método
        public (int, string) getDescripcion(SubOpcionLlamada subOpcionLlamada)
        {
            // Implementación del método
            int subOpcionSeleccionada = subOpcionLlamada.getNroOrden();
            string nombreOpcion = this.getNombre();
            var datos = (subOpcionSeleccionada, nombreOpcion);
            return datos;
        }

        public List<string> getValidaciones(SubOpcionLlamada subOpcionLlamada, List<Validacion> validaciones)
        {
            // Implementación del método
            List<string> mensajes = subOpcionLlamada.getValidaciones(validaciones);
            return mensajes;
            
        }
    }
}
