using PPAI_CU17_GrupoYaNoNosFaltan2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_CU17_GrupoYaNoNosFaltan2.Interfaces;
using PPAI_CU17_GrupoYaNoNosFaltan2.NewFolder1;


namespace PPAI_CU17_GrupoYaNoNosFaltan2.Gestor
{
    public class GestorRegistrarRespuesta
    {
        public string datosLlamada { get; set; }
        public string fechaHoraActual { get; set; }
        public string respuestaSeleccionada { get; set; }
        public string opValidacion { get; set; }

        public GestorRegistrarRespuesta(InterfazRegistrarLlamada interfazRegistrarLlamada)
        {
            this.fechaHoraActual = obtenerFechaHoraActual();
            this.interfazRegistrarLlamada = interfazRegistrarLlamada;
            
        }
        public GestorRegistrarRespuesta(string datosLlamada, string fechaHoraActual, string respuestaSeleccionada, string opValidacion)
        {
            this.datosLlamada = datosLlamada;
            this.fechaHoraActual = fechaHoraActual;
            this.respuestaSeleccionada = respuestaSeleccionada;
            this.opValidacion = opValidacion;
        }
        public GestorRegistrarRespuesta(string datosLlamada, string respuestaSeleccionada, string opValidacion)
        {
            this.datosLlamada = datosLlamada;
            
            this.respuestaSeleccionada = respuestaSeleccionada;
            this.opValidacion = opValidacion;
        }

        public GestorRegistrarRespuesta(InterfazIVR interfazIVR)
        {
            this.interfazIVR = interfazIVR;
        }


        //Relaciones
        public InterfazRegistrarLlamada interfazRegistrarLlamada;
        public GestorRegistrarLlamada gestorRegistrarLlamada;
        public Llamada llamada;
        public Categoria categoria;
        public Estado estado;
        public InterfazIVR interfazIVR;

        // Métodos
        public string obtenerFechaHoraActual()
        {
            DateTime fechaHoraActual = DateTime.Now;

            string fechaHoraString = fechaHoraActual.ToString();

            return fechaHoraString;
        }

        public void TomarOpcionValidacion(string opcionValidacionSeleccionada)
        {
            this.opValidacion = opcionValidacionSeleccionada;
        }

        public void tomarRespuesta(string respuesta)
        {
            this.respuestaSeleccionada = respuesta;
        }

        public void TomarConfirmacion()
        {
           // this.confirmacionSeleccionada = true;
        }

        public void nuevaRespuestaOperador(Llamada llamada1, GestorRegistrarRespuesta gestorRegistrarRespuesta)
        {

            //estado = buscarEstadoEnCurso();
            string tiempo = this.obtenerFechaHoraActual();
            List<string> datos = buscarDatosLlamada(llamada1);
            //tomadaPorOperador(tiempo, estado);
            InterfazRegistrarLlamada interfazRegistrarLlamada = new InterfazRegistrarLlamada(llamada1, gestorRegistrarRespuesta);
            interfazRegistrarLlamada.mostrarDatos(datos);
        }



        public List<Estado> estados;
        
        private Estado enCurso { get; set; }
        public object InterfazRegistrarRespuesta { get; private set; }

        public void buscarEstadoEnCurso()
        {
            foreach (Estado estado in this.estados)
            {
                if (estado.esEnCurso())
                {
                    this.enCurso = estado;
                    break;
                }
            }
        }

        public List<string> buscarDatosLlamada(Llamada llamada)
        {
            List<string> datos = new List<string>();

            string nombreCliente = llamada.getCliente(); // Mostrar
            datos.Add(nombreCliente);
            Console.WriteLine(nombreCliente);
;

            ((int, string), string) tupla = llamada.categoria.getDescripcionCategoriaYOpcion(llamada.opcionLlamada, llamada.subOpcionLlamada);

            string nombreCate = tupla.Item1.Item2; // Mostrar
            datos.Add(nombreCate);
            string nombreOpcion = tupla.Item1.Item2; // Mostrar
            datos.Add(nombreOpcion);    
            int nroOrden = tupla.Item1.Item1; // Mostrar
            datos.Add(nroOrden.ToString());
 

            List<string> mensajes = llamada.categoria.getValidaciones(llamada.opcionLlamada, llamada.subOpcionLlamada, llamada.subOpcionLlamada.validaciones); // Mostrar
            int tamaño = mensajes.Count;
            Console.WriteLine(tamaño);

            foreach (string mensaje in mensajes) datos.Add(mensaje);

            string fechaHora = obtenerFechaHoraActual();
            datos.Add(fechaHora);


            return datos;
        }

        public bool tomarOpValidacion(string respuesta, string validacion,Llamada llamada)
        {
            bool bandera = llamada.validarInformacionCliente(respuesta, validacion, llamada);
            return bandera;
        }
        
        
    }
}

