using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBconnection
{
    public class SqlConnection : DBConnection
    {
        public SqlConnection(string connectionString) : base(connectionString) { }

        public override void Open()
        {
            Console.WriteLine("Opening SQL Server connection...");
        }

        public override void Close()
        {
            Console.WriteLine("Closing SQL Server connection...");
        }
    }
}
