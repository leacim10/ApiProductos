using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Request
{
    public class actualizarProductoRequest
    {
        public int idProducto_IN { get; set; }
        public string codProducto_VC { get; set; }
        public int stock_IN { get; set; }
        public string usuario_VC { get; set; }
    }
}
