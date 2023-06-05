using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Entidades
{
    public class Categoria
    {
        // Atributos
        public string audioMensajeOpciones { get; set; }
        public string mensajeOpciones { get; set; }
        public string nombre { get; set; }
        public int nroOrden { get; set; }

        // Relación de agregación
        public List<OpcionLlamada> opciones { get; set; }
        public OpcionLlamada opcionLlamada { get; set; }

        // Constructor
        public Categoria(string audioMensajeOpciones, string mensajeOpciones, string nombre, int nroOrden, List<OpcionLlamada> opciones)
        {
            // Inicializar atributos
            this.audioMensajeOpciones = audioMensajeOpciones;
            this.mensajeOpciones = mensajeOpciones;
            this.nombre = nombre;
            this.nroOrden = nroOrden;

            // Inicializar relación
            this.opciones = opciones;
        }

        //Metodos de Seteo

        public void setAudioMensajeOpciones(string audioMensajeOpciones)
        {
            this.audioMensajeOpciones = audioMensajeOpciones;
        }

        public String getAudioMensajeOpciones()
        {
            return this.audioMensajeOpciones;
        }
        public void setMensajeOpciones(string mensajeOpciones)
        {
            this.mensajeOpciones = mensajeOpciones;
        }

        public String getmMensajeOpciones()
        {
            return this.mensajeOpciones;
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

        // Métodos
        public List<string> getValidaciones(OpcionLlamada opcionLlamada, SubOpcionLlamada subOpcionLlamada, List<Validacion> validaciones)
        {
            // Implementación del método
            List<string> mensajes = opcionLlamada.getValidaciones(subOpcionLlamada, validaciones);
            return mensajes;
        }

        public ((int, string), string) getDescripcionCategoriaYOpcion(OpcionLlamada opcionLlamada, SubOpcionLlamada subOpcionLlamada)
        {   
            (int, string) datos = opcionLlamada.getDescripcion(subOpcionLlamada);
            string nombreCat = this.getNombre();
            var datos2 = (datos, nombreCat);
            
            return datos2;
        }
    }
}
