using System;

namespace ProductionLibrary
{
    public class Warehouse : IInit
    {
        private string address;
        private int capacity;

        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    address = "не задан";
                else
                    address = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (value < 0)
                    capacity = 0;
                else
                    capacity = value;
            }
        }

        public Warehouse()
        {
            Address = "не задан";
            Capacity = 0;
        }

        public Warehouse(string address, int capacity)
        {
            Address = address;
            Capacity = capacity;
        }

        public void Show()
        {
            Console.WriteLine("Склад \"" + address + "\", вместимость: " + capacity);
        }

        public void Init()
        {
            Console.Write("Адрес склада: ");
            Address = Console.ReadLine();
            Console.Write("Вместимость: ");
            capacity = int.Parse(Console.ReadLine());
            if (capacity < 0) capacity = 0;
        }

        public void RandomInit()
        {
            string[] addrs = { "Ленина 5", "Мира 12", "Строителей 3", "Заводская 1" };
            address = addrs[Production.rnd.Next(addrs.Length)];
            capacity = Production.rnd.Next(100, 5000);
        }
    }
}
