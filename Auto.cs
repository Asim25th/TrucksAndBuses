namespace TrucksAndBuses
{
    class Auto
    {
        protected int maxFuel; // объем бака
        protected double fuel; // оьъем топлива в баке
        protected double speed; // скорость
        protected double consumption; // расход топлива на 100 км
        protected double distance = 0; // длина пути
        protected double distanceTraveled = 0; // пройденное растояние
        protected double mileage = 0; // пробег
        protected Random random = new Random();

        protected virtual void Input() // ввод
        {
            do
            {
                Console.Write("Введите объём бака (до 60 л): ");
                maxFuel = Convert.ToInt32(Console.ReadLine());
                if (maxFuel > 60)
                {
                    Console.WriteLine("ОШИБКА: Введено некорректное значение. Попробуйте ещё раз");
                }
            }
            while (maxFuel > 60);

            fuel = random.Next(0, maxFuel + 1);

            Console.WriteLine("\nСПРАВКА: При скорости до 40 км/ч топливо тратится в 2 раза больше, а при скорости от 90 км/ч - в 1,5 раза больше");
            do
            {
                Console.Write("Введите скорость (до 120 км/ч): ");
                speed = Convert.ToDouble(Console.ReadLine());
                if (speed > 120)
                {
                    Console.WriteLine("ОШИБКА: Введено некорректное значение. Попробуйте ещё раз");
                }

            } while (speed > 120);

            do
            {
                Console.Write("\nВведите расход топлива на 100 км (от 7 до 15 л): ");
                consumption = Convert.ToDouble(Console.ReadLine());
                if (consumption < 7 || consumption > 15)
                {
                    Console.WriteLine("ОШИБКА: Введено некорректное значение. Попробуйте ещё раз");
                }

            } while (consumption < 7 || consumption > 15);
        }

        protected virtual void Output() // вывод
        {
            Console.WriteLine($"\nСкорость: {Math.Round(speed, 3)} км/ч\nРасход на 100 км: {Math.Round(consumption, 3)} л\nПройдено: {Math.Round(distanceTraveled, 3)} км\nОсталось: {Math.Round(distance - distanceTraveled, 3)} км\nПробег: {Math.Round(mileage, 3)} км\nТопливо: {Math.Round(fuel, 3)}/{maxFuel} л");
        }

        protected virtual void Move() // езда
        {
            distanceTraveled = 0;
            distance = random.Next(10, 300);
            Console.WriteLine($"\nВы начинаете свой путь длиной в {Math.Round(distance, 3)} км\nНажмите Enter, чтобы продолжить");
            Console.ReadKey();
            do
            {
                distanceTraveled += fuel / (consumption / 100);
                if (distanceTraveled < distance)
                {
                    fuel = 0;
                    mileage += distanceTraveled;
                    Output();
                    Refilling();
                    Output();
                    Console.WriteLine("\nНажмите Enter, чтобы продолжить");
                    Console.ReadKey();
                }
                else
                {
                    fuel = (distanceTraveled - distance) * (consumption / 100);
                    distanceTraveled = distance;
                    mileage += distanceTraveled;
                    Output();

                    Console.WriteLine("\nЖелаете ли вы продолжить свою дорогу?\n");
                    Console.WriteLine("1. Продолжить путь\n2. Оставить поездки на этот раз");
                    Console.Write("\nВведите номер выбранного варианта: ");
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.WriteLine("\nЖелаете ли заправиться, чтобы продолжить путь?\n\n1. Да\n2. Нет");
                        Console.Write("\nВведите номер выбранного варианта: ");
                        userChoice = Convert.ToInt32(Console.ReadLine());
                        if (userChoice == 1)
                        {
                            Refilling();
                        }
                        Output();
                        Move();
                    }
                    else
                    {
                        Console.Clear();
                        Program.Main();
                        break;
                    }
                }
            } while (distanceTraveled < distance);

        }

        protected void Refilling() // заправка
        {
            Console.Write($"\nВведите количество топлива, которое вы хотите залить (до {Math.Round(maxFuel - fuel, 3)} л): ");
            double input = Convert.ToDouble(Console.ReadLine());
            if (input <= maxFuel - fuel)
            {
                fuel += input;
            }
            else
            {
                Console.WriteLine("ОШИБКА: Введено некорректное значение. Попробуйте ещё раз");
                Refilling();
            }
        }
    }
}