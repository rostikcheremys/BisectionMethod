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
            Console.Write("Введiть iнтервали через пробiл: ");
            string[] input = Console.ReadLine().Split(' ');

            double a = double.Parse(input[0]);
            double b = double.Parse(input[1]);
            
            if (F(a) * F(b) > 0)
            {
                Console.WriteLine("Неправильний iнтервал!");
                return;
            }
            
            double x = BisectionMethod(F, a, b, 0.1);
            
            Console.WriteLine($"F(x): {F(x)}");
        }
    }
}