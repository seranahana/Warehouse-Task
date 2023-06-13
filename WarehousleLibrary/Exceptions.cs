using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Library
{
    public class DBOperationException : Exception
    {
        public DBOperationException(string table) : base($"Operation on {table} thrown no exceptions, but affected unexpected amount of strings.")
        {
        }

        public DBOperationException(string table, Exception inner) : base($"Operation on {table} thrown no exceptions, but affected unexpected amount of strings.", inner)
        {
        }
    }
}
