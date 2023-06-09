using infoDesign.AccesoDatos.Data.Repository.IRepository;
using infoDesign.modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace infoDesign.AccesoDatos.Data.Repository
{
    public class TipoClienteRepository : Repository<Tipo_clientes>, ITipoClienteRepository
    {
        private readonly MyDbContext _db;
        public TipoClienteRepository(MyDbContext db):base(db) { _db = db; }
        public void update(Tipo_clientes tipo)
        {
            var objDatabase = _db.Tipo_clientes.FirstOrDefault(s => s.id == tipo.id);
            objDatabase.nombre = tipo.nombre;
            objDatabase.descripcion = tipo.descripcion;
            _db.SaveChanges();
        }
    }
}
