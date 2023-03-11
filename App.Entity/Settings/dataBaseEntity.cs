using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Settings
{
    public class dataBaseEntity
    {
        public List<conecctionsDB> conecctions { get; set; }
    }
    public class conecctionsDB
    {
        public string name { get; set; }
        public string server { get; set; }
        public string dataBase { get; set; }
        public string user { get; set; }
        public string password { get; set; }
    }
}
