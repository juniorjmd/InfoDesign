using infoDesign.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace infoDesign.AccesoDatos.Data.Repository.IRepository
{
    public interface ILineaRepository  : IRepository<Lineas>
    {
       // IEnumerable<SelectListItem> GetListaLineas();
        void update( Lineas lineas);
    }
}
