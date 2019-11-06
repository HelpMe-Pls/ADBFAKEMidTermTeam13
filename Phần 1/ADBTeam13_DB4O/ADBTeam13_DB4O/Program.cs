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
                Console.Write("Nhập tên thành phố: ");
                string city = Console.ReadLine();
                Company company = new Company(id, name, number, street, city);
                db.Store(company);
            }

            //Câu 1.5
            static void Employee(IObjectContainer db)
            {
            Company c1 = new Company(01, "comp1", "hn1", "123 ADV", "HCMC");        db.Store(c1);
            Company c2 = new Company(02, "comp2", "hn2", "456 ADV", "HCMC");        db.Store(c2);
            Company c3 = new Company(03, "comp3", "hn3", "789 ADV", "HCMC");        db.Store(c3);
            Company c4 = new Company(04, "comp4", "hn4", "696 ADV", "HCMC");        db.Store(c4);
            Company c5 = new Company(05, "comp5", "hn5", "969 ADV", "HCMC");        db.Store(c5);
            Employee e1 = new Employee(01, "Random Guy", "C#", c1, null, 6996);     db.Store(e1);
            Employee e2 = new Employee(02, "Noctua", "JS", c2, null, 69);           db.Store(e2);
            Employee e3 = new Employee(03, "Hoangvn", "Java", c3, null, 96);        db.Store(e3);
            Employee e4 = new Employee(04, "Gono", "Python", c4, null, 99);         db.Store(e4);
            Employee e5 = new Employee(05, "Uncle Ho", "PHP", c5, null, 66);        db.Store(e5);

            }  
    }
}
