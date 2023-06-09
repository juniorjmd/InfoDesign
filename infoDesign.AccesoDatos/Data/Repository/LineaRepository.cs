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
    internal class LineaRepository : Repository<Lineas>, ILineaRepository
    {
        private readonly MyDbContext _db;
        public LineaRepository(MyDbContext db) : base(db)
        {
            _db = db; 
        }

        public void update(Lineas lineas)
        { 
            var objDatabase = _db.Lineas.FirstOrDefault(s => s.id == lineas.id ) ;
            objDatabase.nombre = lineas.nombre ;
            objDatabase.descripcion = lineas.descripcion ;
            _db.SaveChanges();
        }
    }
}
