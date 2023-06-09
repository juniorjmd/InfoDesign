using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoDesign.modelos.HistoriaPorTipoUsuario
{
    public class HistoriaFecha
    {
        public DateTime Fecha { get; set; }
        public List<HistoriaTramo> Datos { get; set; }
    }
}
