using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Section06 {
    class Program {
        static void Main(string[] args) {
            Employee employee = new Employee {
                Id = 100,
                Name = "山田太郎",
                Birthday = new DateTime(1992, 4, 5),
                DivisionName = "第一営業部",
            }; 

            Console.WriteLine("{0}({1})は、{2}に所属しています。", 
                employee.Name, employee.GetAge(), employee.DivisionName);

            Student student = new Student
            {
                Birthday = new DateTime(1992, 03, 29),
                Grade = 2,
                ClassNumber = 3,
                Name = "david",
            };
            student.Output();

            Person tmpPerson = student;
            Object tmpObject = student;

            Console.WriteLine(tmpPerson);
            Console.WriteLine(tmpObject);
            Console.ReadKey();
        }
    }


    public class Person {

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public int GetAge() {
            DateTime today = DateTime.Today;
            int age = today.Year - Birthday.Year;
            if (today < Birthday.AddYears(age))
                age--;
            return age;
        }
    }

    public class Employee : Person {
        public int Id { get; set; }

        public string DivisionName { get; set; }
    }

    public class Student : Person
    {
        public int Grade { get; set; }
        public int ClassNumber { get; set; }

        public void Output()
        {
            foreach (PropertyInfo item in this.GetType().GetProperties())
            {
                Console.WriteLine("{0}: {1}", item.Name, item.GetValue(this));
                Console.WriteLine();
            }
        }
    }



}
