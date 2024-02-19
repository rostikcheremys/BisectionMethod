using System;

namespace Program
{
    abstract class Program
    {
        private static double Function(double x)
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
            int intervalA = 0;
            int intervalB = 0;

            double[] x = new double[10]; 
            double[] fx = new double[10]; 
            
            for (int i = 0; count < 10; i++)
            {
                fx[i] = Function(a + i * step);
                x[i] = a + i * step;
                count++;
            }
            
            for (int i = 1; i < fx.Length + 1; i++)
            {
                if (fx[i] < 0)
                {
                    intervalB = i;
                    intervalA = i - 1;
                    break;
                }
            }
            
            double pointA = x[intervalA];
            double pointB = x[intervalB];
            
            if (Function(pointA) * Function(pointB) > 0)
            {
                Console.WriteLine("Неправильний iнтервал!");
                return;
            }
            
            double result = BisectionMethod(Function, pointA, pointB, 0.1);
            Console.WriteLine($"F(x): {Function(result)}");
        }
    }
}