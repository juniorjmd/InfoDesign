using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoDesign.modelos.consumoPorTramo
{
    public class consumoPorTramo
    {

        public int IdLinea { get; set; }
        public string NombreLinea { get; set; }
        public DateTime Fecha { get; set; } 
        public Dictionary<DateTime, List<HistorialCliente>> Fechas { get; set; }
    }
}
