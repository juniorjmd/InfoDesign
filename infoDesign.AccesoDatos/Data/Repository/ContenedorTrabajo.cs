using infoDesign.AccesoDatos.Data.Repository.IRepository;
namespace infoDesign.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {

        private readonly MyDbContext _db;
        public ContenedorTrabajo(MyDbContext db)
        {
            _db = db;
            /*  Autor = new AutorRepository(_db);
              AutorHasLibro = new AutorHasLibroRepository(_db);
              Editorial = new EditorialRepository(_db);
              Libro = new LibroRepository(_db);*/
            TipoCliente = new TipoClienteRepository(_db);
            linea = new LineaRepository(_db);
            HistoricoConsumo = new HistoricoConsumoRepository(_db);
            vwHistoricoConsumo = new vwHistoricoConsumoRepository(_db);
        }

        public ITipoClienteRepository TipoCliente { get; private set; }
        public IHistoricoConsumoRepository HistoricoConsumo { get; private set; }
        public IvwHistoricoConsumoRepository vwHistoricoConsumo { get; private set; }

        public ILineaRepository linea { get; private set; }

        public void Dispose()
        { _db.Dispose(); }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
