using System;
using System.Collections.Generic;

namespace Integrals
{
    public static class Parameters
    {
        public static int N => 20;

        public static List<Method> GetMethods()
        {
            var result = Methods[N];

            result.Add(new Gauss2());

            return result;
        }

        private static Dictionary<int, List<Method>> Methods => new Dictionary<int, List<Method>>
        {
            {9, new List<Method> {new Trapeze(), new Simpson()}},
            {20, new List<Method> {new Simpson(), new Gregory()}},
        };

        public static Func<double, double> GetIntegrand()
        {
            return Integrands[N];
        }

        private static Dictionary<int, Func<double, double>> Integrands => new Dictionary<int, Func<double, double>>
        {
            {9, x => 1 / Math.Sqrt(1 + Math.Pow(x, 3))},
            {20, x => Math.Sqrt(x) * Math.Exp(x)},
        };
    }
}
