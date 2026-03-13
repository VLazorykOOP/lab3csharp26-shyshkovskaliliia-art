namespace Lab3CSharp
{
    internal class Menu
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 3 ");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("      ЛАБОРАТОРНА РОБОТА №3");
                Console.WriteLine();
                Console.WriteLine("МЕНЮ:");
                Console.WriteLine("1. Завдання 1 - Клас Triangle (Трикутник)");
                Console.WriteLine("2. Завдання 2 - Ієрархія класів (Персона)");
                Console.WriteLine("0. Вихід");
                Console.WriteLine();
                Console.Write("Оберіть пункт меню: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        task1.Run();
                        break;
                    case "2":
                        task2.Run();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Програма завершила роботу.");
                        break;
                    default:
                        Console.WriteLine("Помилка невірний вибір");
                        break;
                }

                Console.WriteLine("\nНатисніть [Enter], щоб повернутись до меню...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {

                }
            }

        }
    }
}
