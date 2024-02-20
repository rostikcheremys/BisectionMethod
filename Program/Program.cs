using System;

namespace Program
{
    class Program
    {
        private static double BisectionMethod(Func<double, double> function, double a, double b, double eps)
        {
            while (Math.Abs(a - b) > eps)
            {
                double c = (a + b) / 2;

                if (function(a) * function(c) > 0)
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

        private static (double, double) Calculation(Func<double, double> function, double a, double b)
        {
            double step = (b - a) / 10;

            int intervalA = 0;
            int intervalB = 0;

            double[] x = new double[10];
            double[] fx = new double[10];

            for (int i = 0; i < 10; i++)
            {
                x[i] = a + i * step;
                fx[i] = function(a + i * step);
            }

            for (int i = 1; i < fx.Length + 1; i++)
            {
                if (fx[i - 1] * fx[i] < 0)
                {
                    intervalB = i;
                    intervalA = i - 1;
                    break;
                }
            }

            double pointA = x[intervalA];
            double pointB = x[intervalB];

            if (function(pointA) * function(pointB) > 0)
            {
                Console.WriteLine("Неправильний iнтервал!");
            }

            return (pointA, pointB);
        }

        public static void Main()
        {
            Func<double, double> function = x => Math.Pow(x, 2) * Math.Cos(x) - 0.2;

            double a = -2 * Math.PI;
            double b = 2 * Math.PI;

            (double, double) interval = Calculation(function, a, b);

            double result = BisectionMethod(function, interval.Item1, interval.Item2, 0.1);
            Console.WriteLine($"F(x): {function(result)}");
        }
    }
}