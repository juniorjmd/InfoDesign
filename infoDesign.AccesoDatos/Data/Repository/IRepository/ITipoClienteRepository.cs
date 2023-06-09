using infoDesign.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace infoDesign.AccesoDatos.Data.Repository.IRepository
{
    public interface ITipoClienteRepository : IRepository<Tipo_clientes>
    {
       // IEnumerable<SelectListItem> GetListaTipoCliente();
        void update(Tipo_clientes tipo_cliente);
    }
}
