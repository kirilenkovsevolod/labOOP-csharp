using System;

namespace ProductionLibrary
{
    public class Workshop : Factory, ICloneable
    {
        protected int workshopNumber;
        protected string master;

        public int WorkshopNumber
        {
            get { return workshopNumber; }
            set
            {
                if (value < 1)
                    workshopNumber = 1;
                else
                    workshopNumber = value;
            }
        }

        public string Master
        {
            get { return master; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    master = "не назначен";
                else
                    master = value;
            }
        }

        public Workshop() : base()
        {
            WorkshopNumber = 1;
            Master = "не назначен";
        }

        public Workshop(string name, int workerCount, string productProfile, int workshopNumber, string master)
            : base(name, workerCount, productProfile)
        {
            WorkshopNumber = workshopNumber;
            Master = master;
        }

        public Workshop(Workshop other)
            : base(other)
        {
            workshopNumber = other.workshopNumber;
            master = other.master;
        }

        public override void Show()
        {
            Console.WriteLine("Цех №" + workshopNumber + " \"" + name + "\" (" + productProfile + "), мастер: " + master + ", рабочих: " + workerCount);
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Номер цеха: ");
            workshopNumber = int.Parse(Console.ReadLine());
            if (workshopNumber < 1) workshopNumber = 1;
            Console.Write("Мастер: ");
            Master = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            workshopNumber = rnd.Next(1, 20);
            string[] masters = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов" };
            master = masters[rnd.Next(masters.Length)];
        }

        public override bool Equals(object obj)
        {
            if (obj is Workshop w)
                return base.Equals(obj) && workshopNumber == w.workshopNumber && master == w.master;
            return false;
        }

        public object Clone()
        {
            return new Workshop(this);
        }

        public Workshop ShallowCopy()
        {
            return (Workshop)MemberwiseClone();
        }
    }
}
