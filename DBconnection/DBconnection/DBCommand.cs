using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBconnection
{
    public  class DBCommand
    {
        private readonly DBConnection _connection;
        private readonly string _instruction;

        public DBCommand(DBConnection connection, string instruction)
        {
            _connection = connection ?? throw new InvalidOperationException("Connection cannot be null.");
            _instruction = string.IsNullOrWhiteSpace(instruction) ? throw new InvalidOperationException("Instruction cannot be null or empty.") : instruction;
        }

        public void Execute()
        {
            _connection.Open();
            Console.WriteLine($"Executing command: {_instruction}");
            _connection.Close();
        }
    }
}
