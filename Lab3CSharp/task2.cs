using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3CSharp
{
    internal class task2
    {
        class Person
        {
            protected string name;
            protected int age;
            protected string gender;

            public Person(string name, int age, string gender)
            {
                this.name = name;
                this.age = age;
                this.gender = gender;
            }

            public virtual void Show()
            {
                Console.WriteLine("Персона: {0}, Вік: {1}, Стать: {2}", name, age, gender);
            }

            public virtual double GetSalary()
            {
                return 0;
            }

            public string Name { get { return name; } }
            public int Age { get { return age; } }
        }
        class Employee : Person
        {
            protected string position;
            protected double salary;

            public Employee(string name, int age, string gender, string position, double salary)
                : base(name, age, gender)
            {
                this.position = position;
                this.salary = salary;
            }

            public override void Show()
            {
                Console.WriteLine("Службовець: {0}, Вік: {1}, Посада: {2}, Зарплата: {3:F2}",
                    name, age, position, salary);
            }

            public override double GetSalary()
            {
                return salary;
            }
        }
        class Worker : Person
        {
            protected int workHours;
            protected double rate;

            public Worker(string name, int age, string gender, int workHours, double rate)
                : base(name, age, gender)
            {
                this.workHours = workHours;
                this.rate = rate;
            }
            public override void Show()
            {
                Console.WriteLine("Робітник: {0}, Вік: {1}, Годин: {2}, Ставка: {3:F2}, Зарплата: {4:F2}",
                    name, age, workHours, rate, GetSalary());
            }
            public override double GetSalary()
            {
                return workHours * rate;
            }
        }
        class Engineer : Person
        {
            protected string specialization;
            protected int projects;
            protected double baseSalary;

            public Engineer(string name, int age, string gender, string specialization, int projects, double baseSalary)
                : base(name, age, gender)
            {
                this.specialization = specialization;
                this.projects = projects;
                this.baseSalary = baseSalary;
            }
            public override void Show()
            {
                Console.WriteLine("Інженер: {0}, Вік: {1}, Спеціальність: {2}, Проекти: {3}, Зарплата: {4:F2}",
                    name, age, specialization, projects, GetSalary());
            }

            public override double GetSalary()
            {
                return baseSalary + projects * 1000;
            }
        }

        static void FillArray(Person[] people)
        {
            people[0] = new Employee("Петренко О.", 35, "чол", "Менеджер", 15000);
            people[1] = new Worker("Коваленко І.", 28, "чол", 160, 250);
            people[2] = new Engineer("Шевченко М.", 42, "чол", "Програміст", 5, 20000);
            people[3] = new Employee("Бондаренко Т.", 31, "жін", "Бухгалтер", 12000);
            people[4] = new Worker("Мельник В.", 45, "чол", 180, 300);
            people[5] = new Engineer("Лисенко О.", 38, "жін", "Інженер", 8, 18000);
        }

        static void SortBySalary(Person[] people)
        {
            for (int i = 0; i < people.Length - 1; i++)
            {
                for (int j = 0; j < people.Length - i - 1; j++)
                {
                    if (people[j].GetSalary() > people[j + 1].GetSalary())
                    {
                        Person temp = people[j];
                        people[j] = people[j + 1];
                        people[j + 1] = temp;
                    }
                }
            }
        }

        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Лабораторна робота №3");
            Console.WriteLine("Ієрархія класів: Персона, Службовець, Робітник, Інженер");
            Console.WriteLine();

            Person[] people = new Person[6];
            FillArray(people);

            Console.WriteLine("Масив до сортування:");
            Console.WriteLine(new string('-', 70));
            for (int i = 0; i < people.Length; i++)
            {
                people[i].Show();
            }
            Console.WriteLine();

            SortBySalary(people);

            Console.WriteLine("Масив після сортування (за зарплатою):");
            Console.WriteLine(new string('-', 70));
            for (int i = 0; i < people.Length; i++)
            {
                people[i].Show();
            }
            Console.WriteLine();
            Console.WriteLine("Статистика:");
            double totalSalary = 0;
            for (int i = 0; i < people.Length; i++)
            {
                totalSalary += people[i].GetSalary();
            }
            Console.WriteLine("Загальний фонд зарплати: {0:F2} грн", totalSalary);
            Console.WriteLine("Середня зарплата: {0:F2} грн", totalSalary / people.Length);

            Console.WriteLine();
            Console.WriteLine("Програма завершила роботу");
            Console.WriteLine("Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }

    }
}
