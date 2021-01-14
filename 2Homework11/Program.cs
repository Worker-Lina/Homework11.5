using System;
using ConsoleMenu;

namespace _2Homework11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int arraySize = int.Parse(Console.ReadLine());

            Employee[] employees = new Employee[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                var employee = new Employee();
                Console.Write("Имя: ");
                employee.Name = Console.ReadLine();
                Console.Write("Фамилия: ");
                employee.Surname = Console.ReadLine();
                Console.Write("Зарплата: ");
                employee.Salary = double.Parse(Console.ReadLine());
                Console.Write("Должность:\n1.Бос\n2.Менеджер\n3.Клерк\n");
                employee.Position = (Position)Enum.Parse(typeof(Position), Console.ReadLine());
                Console.Write("Дата принятия на работу: ");
                employee.DateOfAcceptanceForWork = DateTime.Parse(Console.ReadLine());
                employees[i] = employee;
            }

            Array.Sort(employees, (x, y) => String.Compare(x.Surname, y.Surname));

            string[] items = { "Вывести информацию о сотрудниках", "Вывести информацию о менеджарах зарплата которых больше средней зарплаты клерков", "Вывести информацию о сотрудниках которых приняли позже начальника" };
            var menu = new Menu(items);
            string choice;
            do
            {
                Console.Clear();
                menu.Print();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            foreach (var employee in employees)
                            {
                                Console.WriteLine(employee.GetInfoAboutEmployee());
                            }
                        }
                        break;
                    case "2":
                        {
                            double avgClerckSalary = 0;
                            int countOfClerk = 1;
                            foreach (var employee in employees)
                            {
                                if (employee.Position == Position.Clerk)
                                {
                                    avgClerckSalary += employee.Salary;
                                    countOfClerk++;
                                }
                            }
                            avgClerckSalary = avgClerckSalary / countOfClerk;

                            foreach (var employee in employees)
                            {
                                if (employee.Position == Position.Manager && employee.Salary > avgClerckSalary)
                                {
                                       Console.WriteLine(employee.GetInfoAboutEmployee());                                   
                                }
                            }
                        }
                        break;
                    case "3":
                        {
                            DateTime DateOfAcceptanceForWorkBos = new DateTime();
                            foreach (var employee in employees)
                            {
                                if (employee.Position == Position.Bos)
                                {
                                    DateOfAcceptanceForWorkBos = employee.DateOfAcceptanceForWork;
                                }
                            }


                            foreach (var employee in employees)
                            {
                                if (employee.Position != Position.Bos && employee.DateOfAcceptanceForWork > DateOfAcceptanceForWorkBos)
                                {
                                    Console.WriteLine(employee.GetInfoAboutEmployee());
                                }
                            }
                        }
                        break;
                }
                Console.ReadKey();
            } while (choice != "5");
            


        }
    }
}
