using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Entidades
{
    internal class Finalizada : Estado
    {
        public Finalizada(string nombre) : base(nombre)
        {
            this.nombre = nombre;
        }

        public override CambioEstado crearCambioEstado(DateTime fechaInicio, Estado estado)
        {
            throw new NotImplementedException();
        }

        public override Estado crearProximoEstado()
        {
            throw new NotImplementedException();
        }
    }
}
