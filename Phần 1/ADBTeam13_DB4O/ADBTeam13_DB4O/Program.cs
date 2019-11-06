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

            //Câu 1.6
            List<Employee> employees = new List<Employee>();
            db = Db4oEmbedded.OpenFile(DbFileName);
            Employee template = new Employee(0, null, null, null, null, 0);
            IObjectSet resultList = db.QueryByExample(template);
            foreach (Employee obj in resultList)
            {
                employees.Add(obj);
            }
            db.Close();
            // xuất kết quả truy vấn
            Console.WriteLine("Kết quả truy vấn là: ");
            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp.ToString());
            }
        }
    }
}
