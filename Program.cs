namespace TrucksAndBuses
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Доступные виды транспорта:\n\n1. Автобус\n2. Грузовик");
            Console.Write("\nВведите номер желаемого транспорта: ");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Console.Clear();
                Console.WriteLine("АВТОБУС");
                Bus bus = new Bus();
                bus.Start();
            }
            else if (input == 2)
            {
                Console.Clear();
                Console.WriteLine("ГРУЗОВИК");
                Truck truck = new Truck();
                truck.Start();
            }
            else
            {
                Console.WriteLine("ОШИБКА: Введено некорректное значение. Нажмите Enter и попробуйте ещё раз");
                Console.ReadKey();
                Console.Clear();
                Main();
            }
        }
    }
}