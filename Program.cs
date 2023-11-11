using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI_CU17_GrupoYaNoNosFaltan2;
using PPAI_CU17_GrupoYaNoNosFaltan2.Entidades; //
using PPAI_CU17_GrupoYaNoNosFaltan2.NewFolder1; //
using PPAI_CU17_GrupoYaNoNosFaltan2.Persistencia; //

namespace PPAI_CU17_GrupoYaNoNosFaltan2
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InterfazIVR());


            using (var context = new IVRContexto())
            {
                List<InformacionCliente> lista = new List<InformacionCliente>();
                var nuevoCliente = new Cliente ("43543543", "fede",  "242454534",  lista );
                context.Cliente.Add(nuevoCliente);
                context.SaveChanges();
            }

        }
    }
}
