using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsole.NewFolder1
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        private int PrivateProperty { get; set; }
        internal int InternalProperty { get; set; }
        protected int ProtectedProperty { get; set; }
    }

    public class Contractor : Employee
    {
        public string Role { get; set; }
        public float DailyRate { get; set; }
    }

    public class EmployeePlanner
    {
        public void Print()
        {
            var contractor = new Contractor();

            //Console.WriteLine(contractor.pro);

        }
        

    }
}
