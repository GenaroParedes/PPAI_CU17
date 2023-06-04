using PPAI_CU17_GrupoYaNoNosFaltan2.Entidades;
using PPAI_CU17_GrupoYaNoNosFaltan2.Gestor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Entidades
{
    public class Llamada
    {
        // Atributos
        public string descripcionOperador { get; set; }
        public string detalleAccionRequerida { get; set; }
        public TimeSpan duracion { get; set; }
        public bool encuestaEnviada { get; set; }
        public string observacionAuditor { get; set; }

        // Relaciones
        public Cliente cliente { get; set; }
        public SubOpcionLlamada subOpcionLlamada { get; set; }
        public OpcionLlamada opcionLlamada { get; set; }
        public List<CambioEstado> cambioDeEstado { get; set; }
        public Categoria categoria { get; set; }

        // Constructor
        public Llamada(string descripcionOperador, string detalleAccionRequerida, TimeSpan duracion, bool encuestaEnviada, string observacionAuditor, Cliente cliente, SubOpcionLlamada subOpcionLlamada, OpcionLlamada opcionLlamada, List<CambioEstado> cambioDeEstado,
            Categoria categoria)
        {
            // Inicializar atributos
            this.descripcionOperador = descripcionOperador;
            this.detalleAccionRequerida = detalleAccionRequerida;
            this.duracion = duracion;
            this.encuestaEnviada = encuestaEnviada;
            this.observacionAuditor = observacionAuditor;

            // Inicializar relaciones
            this.cliente = cliente;
            this.subOpcionLlamada = subOpcionLlamada;
            this.opcionLlamada = opcionLlamada;
            this.cambioDeEstado = cambioDeEstado; // Cambiado por el new
            this.categoria = categoria;
        }
        //Metodos de Seteo

        public void setDescripcionOperador(string descripcionOperador)
        {
            this.descripcionOperador = descripcionOperador;
        }

        public String getDescripcionOperador()
        {
            return this.descripcionOperador;
        }

        public void setDetalleAccionRequerida(string detalleAccionRequerida)
        {
            this.detalleAccionRequerida = detalleAccionRequerida;
        }

        public String getDetalleAccionRequerida()
        {
            return this.detalleAccionRequerida;
        }
        public void setDuracion(TimeSpan duracion)
        {
            this.duracion = duracion;
        }

        public TimeSpan getDuracion()
        {
            return this.duracion;
        }
        public void setEncuestaEnviada(bool encuestaEnviada)
        {
            this.encuestaEnviada = encuestaEnviada;
        }

        public bool getEncuestaEnviada()
        {
            return this.encuestaEnviada;
        }
        public void setObservacionAuditor(string observacionAuditor)
        {
            this.observacionAuditor = observacionAuditor;
        }

        public String getObservacionAuditor()
        {
            return this.observacionAuditor;
        }


        // Métodos
        public void tomadaPorOperador(Estado estado, string fechaHoraActual)
        {
            DateTime fechaFormateada = DateTime.Parse(fechaHoraActual);
            CambioEstado nuevoCE = new CambioEstado(fechaFormateada, estado);
            cambioDeEstado.Add(nuevoCE);
        }

        public string getCliente()
        {
            string nom = cliente.getNombreClienteLlamada();
            return nom;
        }

        
        public bool validarInformacionCliente(string info, string validacion, Llamada llamada)
        {
            
            bool bandera = llamada.cliente.esInformacionCorrecta(info, validacion, llamada);
            return bandera;
        }
        
        public void CalcularDuracion(string fechaHoraEnCurso, string fechaHoraFinalizada)
        {
            DateTime Inicio = DateTime.Parse(fechaHoraEnCurso);
            DateTime Fin = DateTime.Parse(fechaHoraFinalizada);
            this.duracion = Fin - Inicio;
        }

        public void finalizar(Estado estado, string fechaHoraActual, string respuesta)
        {
            this.descripcionOperador = respuesta;
            DateTime fechaFormateada = DateTime.Parse(fechaHoraActual);
            CambioEstado nuevoCE = new CambioEstado(fechaFormateada, estado);
            cambioDeEstado.Add(nuevoCE);
        }
    }

}

   





