using System;

namespace ProductionLibrary
{
    public class Factory : Production
    {
        protected string productProfile;

        public string ProductProfile
        {
            get { return productProfile; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    productProfile = "не задано";
                else
                    productProfile = value;
            }
        }

        public Factory() : base()
        {
            ProductProfile = "не задано";
        }

        public Factory(string name, int workerCount, string productProfile)
            : base(name, workerCount)
        {
            ProductProfile = productProfile;
        }

        public Factory(Factory other)
            : base(other)
        {
            productProfile = other.productProfile;
        }

        public override void Show()
        {
            Console.WriteLine("Фабрика \"" + name + "\", продукция: " + productProfile + ", рабочих: " + workerCount);
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Продукция: ");
            ProductProfile = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            string[] products = { "мебель", "кондитерские изделия", "ткани", "станки", "игрушки" };
            productProfile = products[rnd.Next(products.Length)];
        }

        public override bool Equals(object obj)
        {
            if (obj is Factory f)
                return base.Equals(obj) && productProfile == f.productProfile;
            return false;
        }
    }
}
