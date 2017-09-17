using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nantou_bus
{
    public class SchoolRecord
    {
        public SchoolRecord()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string School { get; set; }

    }
}