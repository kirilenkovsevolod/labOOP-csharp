using System;

namespace ProductionLibrary
{
    public class RepairShop : Production
    {
        protected string specialization;

        public string Specialization
        {
            get { return specialization; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    specialization = "не задана";
                else
                    specialization = value;
            }
        }

        public RepairShop() : base()
        {
            Specialization = "не задана";
        }

        public RepairShop(string name, int workerCount, string specialization)
            : base(name, workerCount)
        {
            Specialization = specialization;
        }

        public RepairShop(RepairShop other)
            : base(other)
        {
            specialization = other.specialization;
        }

        public override void Show()
        {
            Console.WriteLine("Мастерская \"" + name + "\", специализация: " + specialization + ", рабочих: " + workerCount);
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Специализация: ");
            Specialization = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            string[] specs = { "авто", "бытовая техника", "обувь", "мебель", "электроника" };
            specialization = specs[rnd.Next(specs.Length)];
        }

        public override bool Equals(object obj)
        {
            if (obj is RepairShop r)
                return base.Equals(obj) && specialization == r.specialization;
            return false;
        }
    }
}
