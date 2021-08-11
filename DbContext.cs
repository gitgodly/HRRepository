using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRRepository
{
    public static class DbContext
    {
        private static string  ConnectionString { get; set; }
        public static string GetConnectionString()
        {
            return ConnectionString;
        }
        public static void SetConnectionString(string connectionString)
        {
            if (ConnectionString == null) // restricting bypass on d fly
            {
                ConnectionString = connectionString; 
            }
        }

    }
}