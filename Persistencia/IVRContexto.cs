using PPAI_CU17_GrupoYaNoNosFaltan2.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Persistencia
{
    public class IVRContexto : DbContext
    {
        public IVRContexto() : base("DSI_3K3_Grupo11") { 
        
        }

        public DbSet<CambioEstado> CambioEstado { get; set; }
        public DbSet<Cancelada> Cancelada { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<EnCurso> EnCurso { get; set; }
        public DbSet<Finalizada> Finalizada { get; set; }
        public DbSet<InformacionCliente> InformacionCliente { get; set; }
        public DbSet<Iniciada> Iniciada { get; set; }
        public DbSet<Llamada> Llamada { get; set; }
        public DbSet<OpcionLlamada> opcionLlamada { get; set; }
        public DbSet<SubOpcionLlamada> SubOpcionLlamada { get; set; }
        public DbSet<TipoInformacion> TipoInformacion { get; set; }
        public DbSet<Validacion> Validacion { get; set; }


    }
}
