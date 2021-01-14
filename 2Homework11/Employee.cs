using System;
using System.Collections.Generic;
using System.Text;

namespace _2Homework11
{
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public Position Position { get; set; }
        public DateTime DateOfAcceptanceForWork { get; set; }

        public string GetInfoAboutEmployee()
        {
            return $"Name: {Name}\nSurname: {Surname}\nSalary: {Salary}\nPosition: {Position}\nDateOfAcceptanceForWork: {DateOfAcceptanceForWork}";
        }
    }
}
