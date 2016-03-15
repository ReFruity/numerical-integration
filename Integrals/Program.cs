using System;

namespace Integrals
{
    class Program
    {
        public static void Main(string[] args)
        {
            var N = int.Parse(args[0]);
            var parameters = new Parameters(N);
            var methods = parameters.GetMethods();
            var integrand = parameters.GetIntegrand();

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

            var gauss2 = new Gauss2(integrand, left, right);
            Console.WriteLine(format, "Method", "Integral value", "C1 and C2");
            Console.WriteLine(format, gauss2.GetType().Name, gauss2.Calc(), gauss2.C1() + " and " + gauss2.C2());
        }
    }
}