using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoDesign.modelos
{
    public class Lineas
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string nombre { get; set; }
        [Column(TypeName = "TEXT")]
        public string descripcion { get; set; }
    }
}
