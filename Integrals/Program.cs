using System;

namespace Integrals
{
    class Program
    {
        public static void Main(string[] args)
        {
            // ReSharper disable once InconsistentNaming
            var N = int.Parse(args[0]);
            var parameters = new Parameters(N);

            var methods = parameters.GetMethods();
            var integrand = parameters.GetIntegrand();
            var left = parameters.Left;
            var right = parameters.Right;
            var steps = new[] {0.1, 0.05, 0.025};
            var format = "{0,-20} {1,-20} {2,-20}";

            Console.WriteLine("N = " + N + "\n");
            Console.WriteLine(format, "Step/Method", "Integral value", "Error");

            
            foreach (var method in methods)
            {
                Console.WriteLine(method.GetName());

                foreach (var step in steps)
                {
                    Console.WriteLine(format,
                        step,
                        method.ComplexCalc(integrand, left, right, step),
                        method.Error(integrand, left, right, step));
                }

                Console.WriteLine();
            }

            var gaussMethod = parameters.GetGaussMethod();
            Console.WriteLine(format, "Method", "Integral value", "C1 and C2");
            Console.WriteLine(format, gaussMethod.GetName(), gaussMethod.Calc(), gaussMethod.C1() + " and " + gaussMethod.C2());
        }
    }
}