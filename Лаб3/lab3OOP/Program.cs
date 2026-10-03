using System;

class Program
{

    static void Main(string[] args)
    {
        const double minx = 0.1, maxx = 0.8;
        const int cntx = 10;
        const int n = 3;
        const double eps = 0.0001;
        const double step = (maxx - minx) / cntx;

        for (int i = 0; i <= cntx; i++) //взял 11 точек
        {
            double x = minx + i * step;
            double sn = 0;
            double an = x;
            for (int j = 0; j < n; j++)  //вычисляем SN
            {
                sn += an;
                an = an * Math.Pow(x, 4) * (4 * j + 1) / (4 * j + 5);
            }
            double se = 0;
            double ae = x;
            int je = 0;
            while (ae >= eps)  //вычисляем SE
            {
                se += ae;
                ae = ae * Math.Pow(x, 4) * (4 * je + 1) / (4 * je + 5);
                je++;
            }
            double y = 0.25 * Math.Log((1 + x) / (1 - x)) + 0.5 * Math.Atan(x);  //вычисляем Y
            Console.WriteLine($"X{i + 1} = {x}  SN{i + 1} = {sn}  SE{i + 1} = {se}  Y{i + 1} = {y}\n"); ;
        }
    }
}
