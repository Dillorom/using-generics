using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Employee
    {
        public string mName;
        public int mSalary;

        public Employee(string name, int salary)
        {
            mName = name;
            mSalary = salary;
        }
    }

    class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x.mSalary > y.mSalary)
                return 1;
            if (x.mSalary == y.mSalary)
                return 0;
            else
                return -1;
        }
    }


    class Program
    {
        static void Main(string[] args) {
            List<Employee> empList = new List<Employee>(10);

            empList.Add(new Employee("Dillorom", 5000));
            empList.Add(new Employee("Iymona", 6000));
            empList.Add(new Employee("Amina", 7000));

            Console.WriteLine("The list capacity is " + empList.Capacity);
            Console.WriteLine("Employee size is " + empList.Count);

            if (empList.Exists(HighPay))
            {
                Console.WriteLine("\nHighly Paid Employee Found!\n");
            }

            empList.ForEach(TotalSalaries);
            Console.WriteLine("Total payroll is: {0}\n", total);

            Employee e = empList.Find(x => x.mName.StartsWith("A"));
            if (e != null)
            {
                Console.WriteLine($"Found employee whose name starts with A:{e.mName}");

            }

            EmployeeComparer ec = new EmployeeComparer();
            empList.Sort(ec);
            foreach (Employee emp in empList)
            {
                Console.WriteLine("Salary for {0} is {1}", emp.mName, emp.mSalary);
            }
            Console.WriteLine("\nPress Enter key to continue...");
            Console.ReadLine();

           
        }
        static Boolean HighPay(Employee emp)
        {
            return emp.mSalary >= 6500;
        }



        static int total = 0;
        static void TotalSalaries(Employee e)
        {
            total += e.mSalary;
        }


    }
}
