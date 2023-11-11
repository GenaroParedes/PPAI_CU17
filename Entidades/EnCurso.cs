using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Entidades
{
    internal class EnCurso : Estado
    {

        public EnCurso(string nombre) : base(nombre)
        {
            this.nombre = nombre;
        }

        public override void finalizar(DateTime fechaHoraActual, Llamada llamada)
        {
            Estado nuevoEstado = crearProximoEstado();
            CambioEstado nuevoCambioEstado = crearCambioEstado(fechaHoraActual, nuevoEstado);

            llamada.setCambioEstado(nuevoCambioEstado);
            llamada.setEstadoLlamada(nuevoEstado);
        
        }

        public override Estado crearProximoEstado()
        {
            Finalizada nuevoEstado = new Finalizada("Finalizada"); //REVISAR
            return nuevoEstado;

        }

        public override CambioEstado crearCambioEstado(DateTime fechaHoraInicio, Estado estado)
        {
            CambioEstado nuevoCambioEstado = new CambioEstado(fechaHoraInicio, estado);
            return nuevoCambioEstado;
               

        }

    }
}
