using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Model
{
    public class stockProductos
    {
        public int idStock_IN { get; set; }
        public int idProducto { get; set; }
        public DateTime fechaModificacion { get; set; } 
        public string usuario_VC { get; set; }
        public int stock_IN { get; set; }
    }
}
