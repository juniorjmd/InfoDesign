using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoDesign.modelos.consumoPorTramo
{
    public class HistorialCliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal Consumo { get; set; }
        public decimal Costo { get; set; }
        public decimal Perdida { get; set; }
    }
}
