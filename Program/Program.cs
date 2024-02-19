using System;

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
            double a = Convert.ToDouble(-2 * Math.PI);
            double b = Convert.ToDouble(2 * Math.PI);
            double step = (b - a) / 10;
            
            int count = 0;
            int interval1 = 0;
            int interval2 = 0;

            double[] x = new double[10]; 
            double[] fx = new double[10]; 
            
            for (int i = 0; count < 10; i++)
            {
                fx[i] = F(a + i * step);
                x[i] = (a + i * step);
                count++;
            }
            
            for (int i = 1; i < fx.Length + 1; i++)
            {
                if (fx[i] < 0)
                {
                    interval2 = i;
                    interval1 = i - 1;
                    break;
                }
            }
            
            double point1 = x[interval1];
            double point2 = x[interval2];
            
            if (F(point1) * F(point2) > 0)
            {
                Console.WriteLine("Неправильний iнтервал!");
                return;
            }
            
            double result = BisectionMethod(F, point1, point2, 0.1);
            Console.WriteLine($"F(x): {F(result)}");
        }
    }
}