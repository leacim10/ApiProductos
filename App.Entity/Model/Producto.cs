using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Model
{
    public class Producto
    {
        public int idProducto_IN { get;set; }   
        public string codProducto_VC { get; set; }
        public string descripcion_VC { get; set; }
        public DateTime fechaCreacion_DT { get; set; }
        public DateTime fechaModificacion_DT { get; set; }
        public int stock_IN { get; set; }
    }
}
