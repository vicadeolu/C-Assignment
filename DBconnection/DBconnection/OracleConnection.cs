using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBconnection
{
    public class OracleConnection : DBConnection
    {
        public OracleConnection(string connectionString) : base(connectionString) { }

        public override void Open()
        {
            Console.WriteLine("Opening Oracle connection...");
        }

        public override void Close()
        {
            Console.WriteLine("Closing Oracle connection...");
        }
    }
}
