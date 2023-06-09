using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoDesign.modelos.HistoriaPorTipoUsuario
{
    public class HistoriaTramo
    {
        public int IdLinea { get; set; }
        public string LineaNombre { get; set; }
        public decimal Consumo { get; set; }
        public decimal Perdida { get; set; }
        public decimal Costo { get; set; }
    }
}
