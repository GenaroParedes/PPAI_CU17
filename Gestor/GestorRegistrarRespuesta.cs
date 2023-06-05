using PPAI_CU17_GrupoYaNoNosFaltan2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_CU17_GrupoYaNoNosFaltan2.Interfaces;
using PPAI_CU17_GrupoYaNoNosFaltan2.NewFolder1;
using System.Windows.Forms;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Gestor
{
    public class GestorRegistrarRespuesta
    {
        public List<string> datosLlamada { get; set; }
        public string fechaHoraActual { get; set; }
        public string respuestaSeleccionada { get; set; }
        public string opValidacion { get; set; }

        public GestorRegistrarRespuesta(InterfazRegistrarLlamada interfazRegistrarLlamada)
        {
            this.fechaHoraActual = obtenerFechaHoraActual();
            this.interfazRegistrarLlamada = interfazRegistrarLlamada;
            
        }
        public GestorRegistrarRespuesta(List<string> datosLlamada, string fechaHoraActual, string respuestaSeleccionada, string opValidacion)
        {
            this.datosLlamada = datosLlamada;
            this.fechaHoraActual = fechaHoraActual;
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

        public void TomarConfirmacion()
        {
           // this.confirmacionSeleccionada = true;
        }

        public void nuevaRespuestaOperador(Llamada llamada1, GestorRegistrarRespuesta gestorRegistrarRespuesta)
        {
            Estado estado = Estado.esEnCurso();
            string tiempo1 = obtenerFechaHoraActual();
            llamada1.tomadaPorOperador(estado, tiempo1);
            buscarDatosLlamada(llamada1);
            InterfazRegistrarLlamada interfazRegistrarLlamada = new InterfazRegistrarLlamada(llamada1, gestorRegistrarRespuesta);
            interfazRegistrarLlamada.mostrarDatos(datosLlamada);
            // Cuando se cierre la interfaz:
            estado = Estado.esFinalizada();
            string tiempo2 = obtenerFechaHoraActual();
            llamada1.CalcularDuracion(tiempo1, tiempo2);
            llamada1.finalizar(estado, tiempo2, respuestaSeleccionada); // se crea el estado finalizada
            //finCU();
        }

        public void buscarDatosLlamada(Llamada llamada)
        {
            this.datosLlamada = new List<string>();

            string nombreCliente = llamada.getCliente(); // Mostrar
            datosLlamada.Add(nombreCliente);
;

            ((int, string), string) tupla = llamada.categoria.getDescripcionCategoriaYOpcion(llamada.opcionLlamada, llamada.subOpcionLlamada);

            string nombreCate = tupla.Item1.Item2; // Mostrar
            datosLlamada.Add(nombreCate);
            string nombreOpcion = tupla.Item1.Item2; // Mostrar
            datosLlamada.Add(nombreOpcion);    
            int nroOrden = tupla.Item1.Item1; // Mostrar
            datosLlamada.Add(nroOrden.ToString());


            List<string> mensajes = llamada.categoria.getValidaciones(llamada.opcionLlamada, llamada.subOpcionLlamada, llamada.subOpcionLlamada.validaciones); // Mostrar
            
            foreach (string mensaje in mensajes) datosLlamada.Add(mensaje);

            string fechaHora = obtenerFechaHoraActual();
            datosLlamada.Add(fechaHora);

            foreach (string mensaje in mensajes)
            {
                this.opValidacion = buscarInfoCorrecta(llamada, mensaje);
                datosLlamada.Add(opValidacion);
            }
        }

        public bool tomarOpValidacion(string respuesta, string validacion, Llamada llamada)
        {
            bool bandera = llamada.validarInformacionCliente(respuesta, validacion, llamada);
            return bandera;
        }

        public string buscarInfoCorrecta(Llamada llamada, string validacion)
        {
            string correcta = llamada.cliente.buscarInfoCorrecta(llamada, validacion);
            return correcta;
        }

        public void tomarRespuesta(string res)
        {
            string respuesta = res;

            this.respuestaSeleccionada = res;
        }
        public string tomarAccion(string acc)
        {

            string accion = acc;
            return accion;
        }

        public void tomarConfirmacion(string accion)
        {
            GestorCU28 gestorCU28 = new GestorCU28(accion);
            MessageBox.Show("CU28 finalizado exitosamente!");
        }

        public void finCU()
        {
           
        }
    }
}

