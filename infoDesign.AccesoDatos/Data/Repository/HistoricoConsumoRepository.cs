using infoDesign.AccesoDatos.Data.Repository.IRepository;
using infoDesign.modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoDesign.AccesoDatos.Data.Repository
{
    public class HistoricoConsumoRepository :Repository<HistoricoConsumos> ,  IHistoricoConsumoRepository
    {
        private readonly MyDbContext _db;
        public HistoricoConsumoRepository(MyDbContext db) : base(db) { _db = db; }
        public void update(HistoricoConsumos historico)
        {
            var objDatabase = _db.HistoricoConsumos.FirstOrDefault(s => s.id == historico.id);
            objDatabase.idLinea = historico.idLinea;
            objDatabase.Perdida = historico.Perdida;
            objDatabase.idTipCliente = historico.idTipCliente;
            objDatabase.Consumo = historico.Consumo;
            objDatabase.Costo = historico.Costo; 
            _db.SaveChanges();
        }
    }
}
