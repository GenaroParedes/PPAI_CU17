using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Entidades
{
    public class Estado
    {
        // Atributos
        public string nombre { get; set; }

        // Constructor
        public Estado(string nombre)
        {
            // Inicializar atributos
            this.nombre = nombre;
        }



        public static Estado Iniciado { get; } = new Estado("Iniciada");
        public static Estado EnCurso { get; } = new Estado("EnCurso");
        public static Estado Finalizada { get; } = new Estado("Finalizada");

        public static List<Estado> estados { get; } = new List<Estado>
        {
            Iniciado, EnCurso, Finalizada
        };


        public string getNombre()
        {
            return this.nombre;
        }

        // Métodos
        public Estado esEnCurso()
        {
            Estado estadoEnCurso = null;
            foreach (var estado in estados)
            {
                if (estado.nombre == "EnCurso")
                {
                    estadoEnCurso = estado;
                }
            }
            return estadoEnCurso;
        }

        public Estado esFinalizada()
        {
            Estado estadoFinalizada = null;
            foreach (var estado in estados)
            {
                if (estado.nombre == "Finalizada")
                {
                    estadoFinalizada = estado;
                }
            }
            return estadoFinalizada;
        }

        public bool esIniciada()
        {
            if (this.nombre == "Ïniciada")
            {
                return true;
            }
            return false;
        }
       
    }

}
