namespace TrucksAndBuses
{
    class Truck : Auto
    {
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
            Console.WriteLine($"\nСПРАВКА: При весе от 2500 кг скорость становится в 1,5 раза меньше, а при весе от 4000 - в 2 раза меньше");
            Console.Write($"Введите вес груза (до 5000 кг): ");
            weight = Convert.ToDouble(Console.ReadLine());
            while (weight > 5000)
            {
                Console.Write("ОШИБКА: Введено некорректное значение. Попробуйте ещё раз\nВведите вес груза (до 5000 кг): ");
                weight = Convert.ToDouble(Console.ReadLine());
            }

            if (weight >= 4000)
            {
                speed = Math.Round(speed / 2, 2);
            }
            else if (weight >= 2500)
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
        }

        //protected override void Move()
        //{
        //    if (weight >= 4000)
        //    {
        //        speed = Math.Round(speed / 2, 2);
        //    }
        //    else if (weight >= 2500)
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
    }
}
