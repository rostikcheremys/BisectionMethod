using System;
using System.Runtime.InteropServices;

namespace Program
{
    abstract class Program
    {
        private static double F(double x)
        {
            return Math.Pow(x, 2) * Math.Cos(x) - 0.2;
        }
        
        private static double BisectionMethod(Func<double, double> f, double a, double b, double eps)
        {
            while (Math.Abs(a - b) > eps)
            {
                double c = (a + b) / 2;
                
                if (f(a) * f(c) > 0)
                {
                    a = c;
                }
                else
                {
                    b = c;
                }
            }
            
            return (a + b) / 2;
        }
        
        public static void Main()
        {
            double a = -6.283;
            
            int count = 0;

            double step = 0.4 * Math.PI;
            
            double[] xxx = new double[10]; 
            double[] intervals = new double[10]; 
            
            for (int i = 0; count < 10; i++)
            {
                intervals[i] = F(a + i * step);
                xxx[i] = (a + i * step);
                count++;
            }
            
            Console.WriteLine(string.Join(", ", xxx));

           
            int intervals1 = 0;
            int intervals2 = 0;
            
            for (int i = 1; i < intervals.Length + 1; i++)
            {
                if (intervals[i] < 0)
                {
                    intervals2 = i;
                    intervals1 = i - 1;
                    break;
                }
            }
            double toch1 = xxx[intervals1];
            double toch2 = xxx[intervals2];
            
            
            if (F(toch1) * F(toch2) > 0)
            {
                Console.WriteLine("Неправильний iнтервал!");
                return;
            }
            
            double x = BisectionMethod(F, toch1, toch2, 0.1);
           
            
            Console.WriteLine($"F(x): {F(Math.Round(x, 2))}");
        }
    }
}