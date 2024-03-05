using System;
using System.Collections.Generic;

namespace Program
{
    abstract class Program
    {
        private static double BisectionMethod(Func<double, double> function, double a, double b, double eps)
        {
            while (Math.Abs(function((a + b) / 2)) > eps)
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

        private static List<double> FindAllRoots(Func<double, double> function, double a, double b, double step)
        {
            List<double> roots = new List<double>();

            for (double current = a; current <= b; current += step)
            {
                double intervalA = current;
                double intervalB = current + step;

                if (function(intervalA) * function(intervalB) <= 0)
                {
                    double root = BisectionMethod(function, intervalA, intervalB, 0.1);
                    roots.Add(root);
                }
            }

            return roots;
        }

        public static void Main()
        {
            Func<double, double> function = x => Math.Pow(x, 2) * Math.Cos(x) - 0.2;

            double a = -2 * Math.PI;
            double b = 2 * Math.PI;

            double step = 0.1;

            List<double> allRoots = FindAllRoots(function, a, b, step);

            if (allRoots.Count == 0)
            {
                Console.WriteLine("No roots found in the specified interval.");
            }
            else
            {
                Console.WriteLine("All roots:");
                foreach (var root in allRoots)
                {
                    Console.WriteLine($"F({root}) = {function(root)}");
                }
            }
        }
    }
}