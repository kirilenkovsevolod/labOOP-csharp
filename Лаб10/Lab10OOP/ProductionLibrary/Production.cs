using System;

namespace ProductionLibrary
{
    public interface IInit
    {
        void Init();
        void RandomInit();
    }

    public class Production : IInit, IComparable
    {
        public static Random rnd = new Random();

        protected string name;
        protected int workerCount;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    name = "Без названия";
                else
                    name = value;
            }
        }

        public int WorkerCount
        {
            get { return workerCount; }
            set
            {
                if (value < 0)
                    workerCount = 0;
                else
                    workerCount = value;
            }
        }

        public Production() : this("Без названия", 0)
        {
        }

        public Production(string name, int workerCount)
        {
            Name = name;
            WorkerCount = workerCount;
        }

        public Production(Production other)
        {
            name = other.name;
            workerCount = other.workerCount;
        }

        public virtual void Show()
        {
            Console.WriteLine("Производство \"" + name + "\", рабочих: " + workerCount);
        }

        public void ShowBaseInfo()
        {
            Console.WriteLine("[база] Производство \"" + name + "\", рабочих: " + workerCount);
        }

        public virtual void Init()
        {
            Console.Write("Название: ");
            Name = Console.ReadLine();
            Console.Write("Число рабочих: ");
            workerCount = int.Parse(Console.ReadLine());
            if (workerCount < 0) workerCount = 0;
        }

        public virtual void RandomInit()
        {
            string[] names = { "Альфа", "Восход", "Прогресс", "Заря", "Маяк", "Сокол" };
            name = names[rnd.Next(names.Length)];
            workerCount = rnd.Next(10, 1000);
        }

        public override bool Equals(object obj)
        {
            if (obj is Production p)
                return name == p.name && workerCount == p.workerCount;
            return false;
        }

        public int CompareTo(object obj)
        {
            Production temp = (Production)obj;
            if (this.workerCount > temp.workerCount) return 1;
            if (this.workerCount < temp.workerCount) return -1;
            return 0;
        }
    }
}
