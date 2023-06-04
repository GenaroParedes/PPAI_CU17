using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Entidades
{
    public class Cliente
    {
        // Atributos
        public string dni { get; set; }
        public string nombreCompleto { get; set; }
        public string numeroCelular { get; set; }

        // Relación
        public List<InformacionCliente> informacionCliente;

        


        // Constructor
        public Cliente(string dni, string nombreCompleto, string numeroCelular, List<InformacionCliente> informacionCliente)
        {
            // Inicializar atributos
            this.dni = dni;
            this.nombreCompleto = nombreCompleto;
            this.numeroCelular = numeroCelular;

            // Inicializar relación
            this.informacionCliente = new List<InformacionCliente>();
        }


        //Metodos de Seteo

        public void setDni(string dni)
        {
            this.dni = dni;
        }

        public String getDni()
        {
            return this.dni;
        }
        public void setNombreCompleto(string nombreCompleto)
        {
            this.nombreCompleto = nombreCompleto;
        }

        public String getNombreClienteLlamada()
        {
            return this.nombreCompleto;
        }

        public void setNumeroCelular(string numeroCelular)
        {
            this.numeroCelular = numeroCelular;
        }

        public String getNumeroCelular()
        {
            return this.numeroCelular;
        }

        // Métodos
        
        
        public bool esInformacionCorrecta(string info, string validacion, Llamada llamada)
        {
            bool bandera = false;
            Console.WriteLine(llamada.cliente.informacionCliente.Count);
            foreach (InformacionCliente infoCliente in llamada.cliente.informacionCliente)
            {
                Console.WriteLine(infoCliente.datoAValidar);
                /*if (informacionCliente.esValidacion(validacion, llamada))
                {   
                    if(informacionCliente.esInformacionCorrecta(info, llamada))
                    {
                        bandera = true;
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    
                }*/
            }
            return bandera;
        }
        
    } 


    

}



