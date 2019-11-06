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
            // Câu 1.4
            try
            {
                int i = 0;
                while (i < 3)
                {
                    AddCompany(db);
                }
            }
            finally
            {
                db.Close();
            }
            
        }
        static void AddCompany(IObjectContainer db)
        {
            Console.Write("Nhập id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nhập tên: ");
            string name = Console.ReadLine();
            Console.Write("Nhập số điện thoại: ");
            string number = Console.ReadLine();
            Console.Write("Nhập tên đường: ");
            string street = Console.ReadLine();
            Console.Write("Nhập tên thành phó: ");
            string city = Console.ReadLine();
            Company company = new Company(id, name, number, street, city);
            db.Store(company);
        }
    }
}
