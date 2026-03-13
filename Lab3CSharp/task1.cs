using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3CSharp
{
    internal class task1
    {
        class Triangle
        {
            protected int a, b, c;
            protected int color;

            public int SideA
            {
                get { return a; }
                set
                {
                    if (IsValidTriangle(value, b, c))
                        a = value;
                    else
                        Console.WriteLine($"Помилка!: Сторона A={value} не утворює трикутник зі сторонами {b} та {c}");
                }
            }

            public int SideB
            {
                get { return b; }
                set
                {
                    if (IsValidTriangle(a, value, c))
                        b = value;
                    else
                        Console.WriteLine($"Помилка!: Сторона B={value} не утворює трикутник зі сторонами {a} та {c}");
                }
            }

            public int SideC
            {
                get { return c; }
                set
                {
                    if (IsValidTriangle(a, b, value))
                        c = value;
                    else
                        Console.WriteLine($"Помилка!: Сторона C={value} не утворює трикутник зі сторонами {a} та {b}");
                }
            }

            public int Color
            {
                get { return color; }
            }

            public Triangle(int a, int b, int c, int color = 0)
            {
                if (IsValidTriangle(a, b, c))
                {
                    this.a = a;
                    this.b = b;
                    this.c = c;
                    this.color = color;
                }
                else
                {
                    throw new ArgumentException("Помилка: Задані сторони не утворюють трикутник!");
                }
            }

            public Triangle() : this(3, 3, 3, 0)
            {
                Console.WriteLine("Створено трикутник за замовчуванням");
            }

            public void PrintSides()
            {
                Console.WriteLine($"   Сторони: a = {a}, b = {b}, c = {c}");
            }

            public int GetPerimeter()
            {
                return a + b + c;
            }

            public double GetArea()
            {
                double p = GetPerimeter() / 2.0;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }

            public void PrintInfo()
            {
                PrintSides();
                Console.WriteLine($"   Периметр: {GetPerimeter()}");
                Console.WriteLine($"   Площа: {GetArea():F2}");
                Console.WriteLine($"   Колір (код): {Color}");
            }

            public override string ToString()
            {
                return $"Triangle[{a}, {b}, {c}] P={GetPerimeter()} S={GetArea():F2} Color={Color}";
            }

            private bool IsValidTriangle(int x, int y, int z)
            {
                return (x > 0 && y > 0 && z > 0) &&
                       (x + y > z) && (x + z > y) && (y + z > x);
            }
        }

        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("ЗАВДАННЯ 1 - Клас Triangle");
            Console.WriteLine();

            Triangle[] triangles = new Triangle[4];

            triangles[0] = new Triangle(3, 4, 5, 1);
            triangles[1] = new Triangle(5, 5, 5, 2);
            triangles[2] = new Triangle(6, 8, 10, 3);
            triangles[3] = new Triangle(7, 8, 9, 4);

            Console.WriteLine("Інформація про трикутники:");
            Console.WriteLine();

            for (int i = 0; i < triangles.Length; i++)
            {
                Console.WriteLine("Трикутник №{0}", i + 1);
                triangles[i].PrintSides();
                Console.WriteLine("Периметр: {0}", triangles[i].GetPerimeter());
                Console.WriteLine("Площа: {0:F2}", triangles[i].GetArea());
                Console.WriteLine("Колір: {0}", triangles[i].Color);
                Console.WriteLine();
            }

            Console.WriteLine("Тестування властивостей:");
            Console.WriteLine();

            Console.WriteLine("Трикутник №1 до зміни:");
            triangles[0].PrintSides();

            Console.WriteLine("Спроба змінити сторону A на 100:");
            triangles[0].SideA = 100;

            Console.WriteLine("Спроба змінити сторону A на 4:");
            triangles[0].SideA = 4;

            Console.WriteLine("Трикутник №1 після зміни:");
            triangles[0].PrintSides();
            Console.WriteLine();

            Console.WriteLine("Приклад звернення до об'єкта:");
            Triangle t = new Triangle(10, 10, 10, 5);
            Console.WriteLine("t.SideA = {0}", t.SideA);
            Console.WriteLine("t.Color = {0}", t.Color);
            Console.WriteLine("t.GetPerimeter() = {0}", t.GetPerimeter());
            Console.WriteLine("t.GetArea() = {0:F2}", t.GetArea());
            Console.WriteLine();

            Console.WriteLine("Натисніть будь-яку клавішу для повернення в меню...");
            Console.ReadKey();
        }

    }
}
