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
            int i = 0;
            while (i < 3)
            {
                AddCompany(db);
                i++;
            }
            // Câu 1.6
            List<Employee> employees = new List<Employee>();
            db = Db4oEmbedded.OpenFile(DbFileName);
            Employee template = new Employee(0, null, null, null, null, 0);
            IObjectSet resultList = db.QueryByExample(template);
            foreach (Employee obj in resultList)
            {
                employees.Add(obj);
            }

            // xuất kết quả truy vấn
            Console.WriteLine("Kết quả truy vấn là: ");
            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp.ToString());
            }

            db.Close();

            //Câu 1.7
            int tmp = 0;
            IList<Company> r = db.Query(delegate (Company a)
            {
               foreach(Employee e in a.Employees)
                {
                    tmp++;
                    if (e.Salary <= 500) return false;
                }
                if (tmp <= 2) return false;
                return true;
            });
            //Xuất kết quả 
            foreach(Company com in r)
            {
                Console.WriteLine(com.ToString());
            }
        }

        // Câu 1.4
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
