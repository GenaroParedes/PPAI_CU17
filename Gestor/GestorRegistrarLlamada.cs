using PPAI_CU17_GrupoYaNoNosFaltan2.Entidades;
using PPAI_CU17_GrupoYaNoNosFaltan2.Interfaces;
using PPAI_CU17_GrupoYaNoNosFaltan2.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI_CU17_GrupoYaNoNosFaltan2.Servicios;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Gestor
{
    public class GestorRegistrarLlamada
    {
        private readonly InterfazIVR interfaz;

        // Constructor que recibe la instancia del formulario
        public GestorRegistrarLlamada(InterfazIVR interfaz)
        {

            this.interfaz = interfaz;
        }

        // relaciones
        public InterfazIVR interfazIVR;
        public GestorRegistrarRespuesta gestorRegistrarRespuesta;
        public InterfazRegistrarLlamada interfazRegistrarLlamada;
        


        // Llamada primeraLlamada = new Llamada(null, null, TimeSpan.Zero, false, null, null, null, null);

        
        public Llamada opcionNuevaRespuestaOperador()
        {    
            TipoInformacion tipoInfoCantHijos = new TipoInformacion("Cantidad de Hijos:", "Es la cantidad de hijos del cliente");

            TipoInformacion tipoInfoFechaNac = new TipoInformacion("Fecha de Nacimiento:", "Es la fecha de nacimiento del cliente");

            TipoInformacion tipoInfoCodPostal = new TipoInformacion("Codigo postal:", "Es el codigo postal del cliente");

            Validacion validacion1 = new Validacion("Audio", "Cantidad de hijos: ", 1, tipoInfoCantHijos);

            Validacion validacion2 = new Validacion("Audio", "Fecha Nacimiento: ", 1, tipoInfoFechaNac);

            Validacion validacion3 = new Validacion("Audio", "Codigo postal", 1, tipoInfoCodPostal);

            List<Validacion> validaciones = new List<Validacion>();
            validaciones.Add(validacion1);
            validaciones.Add(validacion2);

            List<InformacionCliente> informacionClientes = new List<InformacionCliente>();

            InformacionCliente infoClienteCantHijos = new InformacionCliente("4", validacion1, tipoInfoCantHijos);
            informacionClientes.Add(infoClienteCantHijos);
           
            InformacionCliente infoClienteFechaNac = new InformacionCliente("22/09/2000", validacion2, tipoInfoFechaNac);
            informacionClientes.Add(infoClienteFechaNac);

            InformacionCliente infoClienteCodPostal = new InformacionCliente("5000", validacion3, tipoInfoCodPostal);

            SubOpcionLlamada subOpcion = new SubOpcionLlamada("Hablar con operador", 1, validaciones);
            List<SubOpcionLlamada> listaSubOpciones = new List<SubOpcionLlamada>();
            listaSubOpciones.Add(subOpcion);

            OpcionLlamada opcionLlamada1 = new OpcionLlamada("Audio", "Hablar con operador 1. Finalizar 2",
                    "Informar robo y anular tarjeta", 1, listaSubOpciones, null);
            List<OpcionLlamada> listaOpciones = new List<OpcionLlamada>();
            listaOpciones.Add(opcionLlamada1);

            Categoria categoria = new Categoria("Audio", "Informar robo y solicitar tarjeta 1. Informar robo y anular tarjeta 2.",
                    "Informar robo", 1, listaOpciones);

            Cliente cliente = new Cliente("12345678", "Juan Pérez", "9q9999", informacionClientes);

            Estado estado = new Estado("Iniciada");

            DateTime tiempo1 = new DateTime(1, 1, 1, 1, 1, 1);

            CambioEstado cambioEstado = new CambioEstado(tiempo1, estado);

            Llamada llamada = new Llamada("Sin descripción", "Sin acción req", TimeSpan.Zero, false, "Sin observación",
                     cliente, subOpcion, opcionLlamada1,
            null, categoria);

            

            // Llamar a los métodos del formulario para mostrar los datos
            interfaz.MostrarDNI(cliente.dni);
            interfaz.MostrarCategoria(categoria.nroOrden);
            interfaz.MostrarOpcion(opcionLlamada1.nroOrden);
            interfaz.MostrarSubopcion(subOpcion.nroOrden);
            Console.WriteLine(informacionClientes.Count());
            
            foreach (InformacionCliente infoCliente in informacionClientes)
            {
                Console.WriteLine(infoCliente.datoAValidar);
            }
            return llamada;
        }
       
    }
}
