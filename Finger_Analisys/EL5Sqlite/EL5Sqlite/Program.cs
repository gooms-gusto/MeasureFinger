using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace EL5Sqlite
{
    class Program
    {

        static void Main(string[] args)
        {
            //var _conn = new SqliteConnection("Data Source=db/sampleDb;mode=ro");
            //http://stackoverflow.com/questions/8602726/cant-open-sqlite-database-in-read-only-mode
            //https://entlib.codeplex.com/discussions/351760
            //http://stackoverflow.com/questions/3500829/sql-express-connection-string-relative-to-application-location            
            try
            {
                int num = 0;
                num = num / num;//overflow
            }
            catch (Exception exceptionToHandle)
            {
                Logger.Write(new LogEntry() { Message ="Hola" });
              
            }


        }

    }


}
