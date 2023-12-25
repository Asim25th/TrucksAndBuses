namespace TrucksAndBuses
{
    class Bus : Auto
    {
        private int people;
        private double weight;

        public void Start()
        {
            Input();
            Output();
            Move();
        }

        protected override void Input()
        {
            base.Input();
            int avgWeight = 80;
            Console.WriteLine($"\nСПРАВКА: При весе от 1000 кг  скорость становится в 1,5 раза меньше, \nа при весе от 2000 кг - в 2 раза меньше. Средний вес человека - {avgWeight} кг");
            Console.Write("Введите количество пассажиров (до 50): ");
            people = Convert.ToInt32(Console.ReadLine());
            while (people > 50)
            {
                Console.Write("ОШИБКА: Введено некорректное значение. Попробуйте ещё раз\nВведите количество пассажиров (до 50): ");
                people = Convert.ToInt32(Console.ReadLine());
            }
            weight = people * avgWeight;

            if (weight >= 2000)
            {
                speed = Math.Round(speed / 2, 2);
            }
            else if (weight >= 1000)
            {
                speed = Math.Round(speed / 1.5, 2);
            }

            if (speed <= 40)
            {
                consumption = Math.Round(consumption * 2, 2);
            }
            else if (speed > 90)
            {
                consumption = Math.Round(consumption * 1.5, 2);
            }
        }

        protected override void Output()
        {
            Console.Write($"\nВес: {Math.Round(weight, 3)} кг");
            base.Output();
            Stop();
        }

        //protected override void Move()
        //{
        //    if (weight >= 2000)
        //    {
        //        speed = Math.Round(speed / 2, 2);
        //    }
        //    else if (weight >= 1000)
        //    {
        //        speed = Math.Round(speed / 1.5, 2);
        //    }

        //    if (speed <= 40)
        //    {
        //        consumption = Math.Round(consumption * 2, 2);
        //    }
        //    else if (speed > 90)
        //    {
        //        consumption = Math.Round(consumption * 1.5, 2);
        //    }

        //    base.Move();
        //}

        private void Stop() // остановки
        {
            int cost = 40;
            cost *= people;
            Console.WriteLine($"Выручка за эту поездку: {cost} руб.");
        }
    }
}
