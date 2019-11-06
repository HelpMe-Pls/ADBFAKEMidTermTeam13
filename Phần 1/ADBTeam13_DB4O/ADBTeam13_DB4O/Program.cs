using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADBTeam13_DB4O
{
    class Program
    {
       
        static void Main(string[] args)
        {
            // Câu 1.3
            string DbFileName = "4301104056_EmployeeManager";
            IObjectContainer db = Db4oEmbedded.OpenFile(DbFileName);
            db.Close();
        }
    }
}
