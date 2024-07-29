using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Constants
{
    public static class ConnectionStrings
    {
     
        public static string MSSQLConnection = "Server=(LocalDb)\\MSSQLLOCALDB;Database=EntityFramework;Trusted_Connection=true;TrustServerCertificate=true;";
        public static string SqlConnection = "Host=localhost;Database=EntityFramework;Username=postgres;Password=Zaur5002";
    }
}
