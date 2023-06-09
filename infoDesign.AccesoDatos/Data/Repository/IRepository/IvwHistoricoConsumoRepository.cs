using infoDesign.modelos;
using infoDesign.modelos.consumoPorTramo;
using infoDesign.modelos.HistoriaPorTipoUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace infoDesign.AccesoDatos.Data.Repository.IRepository
{
    public interface IvwHistoricoConsumoRepository : IRepository<vw_HistoricoConsumos>
    { 
        List<consumoPorTramo> ObtenerHistorialLineas(List<vw_HistoricoConsumos> datos);
        List<HistoriaPorTipoUsuario> ObtenerHistoriaPorTipoUsuario(List<vw_HistoricoConsumos> datos);
         
    }
}
