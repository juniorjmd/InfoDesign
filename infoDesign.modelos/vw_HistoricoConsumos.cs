using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoDesign.modelos
{
    public class vw_HistoricoConsumos
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int idTipCliente { get; set; }
        [Required]
        public int idLinea { get; set; }
        [Required]

        [Column(TypeName = "Date")]
        public DateTime fecha { get; set; }
        [Column(TypeName = "decimal(20,10)")]
        public decimal Consumo { get; set; }
        [Column(TypeName = "decimal(20,10)")]
        public decimal Costo { get; set; }
        [Column(TypeName = "decimal(20,10)")]
        public decimal Perdida { get; set; }
        public string LineaNombre  { get; set; }
        public string NombreCliente  { get; set; }

    }
}
