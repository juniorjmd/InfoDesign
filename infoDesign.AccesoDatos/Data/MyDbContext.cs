using infoDesign.modelos;
using Microsoft.EntityFrameworkCore; 

namespace infoDesign.AccesoDatos.Data
{
    public class MyDbContext: DbContext
    { 
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<HistoricoConsumos> HistoricoConsumos { get; set; }
        public DbSet<Tipo_clientes> Tipo_clientes { get; set; }
        public DbSet<Lineas> Lineas { get; set; } 
        public DbSet<vw_HistoricoConsumos> vwHistoricoConsumos { get; set; }

    }
}
