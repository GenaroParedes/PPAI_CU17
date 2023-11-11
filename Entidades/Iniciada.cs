using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Entidades
{
    public class Iniciada : Estado
    {
        public Iniciada(string nombre) : base(nombre)
        {
            this.nombre = nombre;
        }


        public string Nombre { get; set; }


        public void tomadaPorOperador(DateTime fechaHoraActual, Llamada llamada) 
        {

            Estado nuevoEstado = crearProximoEstado();
            CambioEstado nuevoCambioEstado = crearCambioEstado(nuevoEstado, fechaHoraActual);

            llamada.setCambioEstado(nuevoCambioEstado);
            llamada.setEstadoLlamada(nuevoEstado);


        }

        public Estado crearProximoEstado() 
        {

            EnCurso nuevoEstado = new EnCurso("En Curso"); //REVISAR
            return nuevoEstado;

        }

        public CambioEstado crearCambioEstado(Estado estadoEnCurso, DateTime fechaHoraInicio)
        {

            CambioEstado nuevoCambioEstado = new CambioEstado(fechaHoraInicio, estadoEnCurso);
            return nuevoCambioEstado;

        }
    }
}
