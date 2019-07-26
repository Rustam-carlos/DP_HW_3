using System;

namespace DP_HW_3
{   
    interface IRotor
    {
        void Rotation();
    }
    // класс ДВС
    class InternalCombustionEngine : IRotor
    {
        public void Rotation()
        {
            Console.WriteLine("Ротор вращает ДВС");
        }
    }
    class ElectricGenerator
    {
        public void Work(IRotor transport)
        {
            transport.Rotation();
        }
    }
    // интерфейс природной силы
    interface IRenewableEnergy
    {
        void Move();
    }
    // класс воды
    class Water : IRenewableEnergy
    {
        public void Move()
        {
            Console.WriteLine("Ротор вращает падающая вода");
        }
    }
    // класс ветра
    class Wind : IRenewableEnergy
    {
        public void Move()
        {
            Console.WriteLine("Ротор вращает ветер");
        }
    }
    // Адаптер от Wind к IRotor
    class WaterAdapter : IRotor
    {
        Water river;
        public WaterAdapter(Water w)
        {
            river = w;
        }

        public void Rotation()
        {
            river.Move();
        }
    }
    // Адаптер от Wind к IRotor
    class WindAdapter : IRotor
    {
        Wind wind;
        public WindAdapter(Wind x)
        {
            wind = x;
        }

        public void Rotation()
        {
            wind.Move();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // генератор
            ElectricGenerator Generator = new ElectricGenerator();
            // ДВС
            InternalCombustionEngine ICE = new InternalCombustionEngine();
            // вырабатываем энергию с помощью ДВС
            Generator.Work(ICE);
            // топливо кончается и возобновление дорого, надо использовать текущую воду
            Water river = new Water();
            // используем адаптер
            IRotor riverMove = new WaterAdapter(river);
            // вырабатываем энергию с помощью реки/водопада
            Generator.Work(riverMove);
            // река может пересохнуть или замерзнуть, надо дополнительно предксмотреть силу ветра
            Wind wind = new Wind();
            // используем адаптер
            IRotor WindMove = new WindAdapter(wind);
            // вырабатываем энергию с помощью ветра
            Generator.Work(WindMove);

            Console.Read();
        }
    }
}
