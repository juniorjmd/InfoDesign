using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoDesign.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        //agregar cada repositorio creado
        ITipoClienteRepository TipoCliente  { get; }
        IHistoricoConsumoRepository HistoricoConsumo { get; }
        IvwHistoricoConsumoRepository vwHistoricoConsumo { get; }
        ILineaRepository linea { get;  }
        void Save();
    }
}
