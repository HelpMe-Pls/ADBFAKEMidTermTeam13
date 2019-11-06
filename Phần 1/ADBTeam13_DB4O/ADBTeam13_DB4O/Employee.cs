using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADBTeam13_DB4O
{
    [Serializable]
    public class Employee
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Skill { get; set; }
        public Company HomeBase { get; set; }
        public Employee Manager { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} ({2})", FullName, Skill, Salary);
        }
    }
}
