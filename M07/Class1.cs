using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M07
{
    class Program1
    {
        static void ASfga()
        {
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();

            Console.ReadLine();
        }
    }

    interface IMovable
    {
        void Move();
    }

    class PetrolMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на бензине");
        }
    }

    class ElectricMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на электричестве");
        }
    }

    class Car
    {
        protected int passengers; // кол-во пассажиров
        protected string model; // модель автомобиля

        public Car(int num, string model, IMovable mov)
        {
            this.passengers = num;
            this.model = model;
            Movable = mov;
        }

        public IMovable Movable { private get; set; }

        public void Move()
        {
            Movable.Move();
        }
    }
}
