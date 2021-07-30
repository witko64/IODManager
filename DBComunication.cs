using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace IODManager
{
    class DBComunication //Klasa odpowiada za ustalenie sposobu komunikacji z bazą danych, docelowo nalezy brać prametry z pliku konfiguracyjnego
    {
        private string host = "jarwru\\sqlexpress";
        private int tcpPort = 1433;
        private string dbName = "IODManager";
        private string login = "Wito";
        private string paswsword = "64Witko++";

        public static string connetionString { get; set; }
    
        public DBComunication()
        {
            connetionString = GetConnectionString();
        }
        
        private string GetConnectionString()
        {
            string connectionString = "Server = " + host +
                  "; Database = " + dbName +
                  "; User Id = " + login +
                  "; Password = " + paswsword + ";";
            return connectionString;
        }
    }


}
