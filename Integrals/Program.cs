using System;

namespace Integrals
{
    class Program
    {
        public static void Main(string[] args)
        {
            var N = Parameters.N;
            var methods = Parameters.GetMethods();
            var integrand = Parameters.GetIntegrand();

            var left = 0.1*N;
            var right = 0.5 + 0.2*N;
            var steps = new[] {0.1, 0.05, 0.025};
            var format = "{0,-20} {1,-20} {2,-20}";

            Console.WriteLine("N = " + N);
            Console.WriteLine(format, "Method", "Integral value", "Error");

            foreach (var step in steps)
            {
                Console.WriteLine(step);

                foreach (var method in methods)
                {
                    Console.WriteLine(format,
                        method.GetType().Name,
                        method.ComplexCalc(integrand, left, right, step),
                        method.Error(integrand, left, right, step));
                }

                Console.WriteLine();
            }
        }
    }
}