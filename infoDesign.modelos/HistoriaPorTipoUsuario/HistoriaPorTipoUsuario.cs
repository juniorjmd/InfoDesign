using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoDesign.modelos.HistoriaPorTipoUsuario
{
    public class HistoriaPorTipoUsuario
    {
        public int IdTipCliente { get; set; }
        public string Nombre { get; set; }
        public List<HistoriaFecha> Historia { get; set; }
    }
}
