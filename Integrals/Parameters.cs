using System;
using System.Collections.Generic;

namespace Integrals
{
    public class Parameters
    {
        private int N { get; }

        public Parameters(int N)
        {
            this.N = N;
        }

        public List<Method> GetMethods()
        {
            return Methods[N];
        }

        private static Dictionary<int, List<Method>> Methods => new Dictionary<int, List<Method>>
        {
            {6, new List<Method> {new LeftRectangle(), new ThreeEight()}},
            {9, new List<Method> {new Trapeze(), new Simpson()}},
            {20, new List<Method> {new Simpson(), new Gregory()}},
        };

        public Func<double, double> GetIntegrand()
        {
            return Integrands[N];
        }

        private static Dictionary<int, Func<double, double>> Integrands => new Dictionary<int, Func<double, double>>
        {
            {6, x => Math.Pow(Math.E, x + Math.Sin(x))},
            {9, x => 1 / Math.Sqrt(1 + Math.Pow(x, 3))},
            {20, x => Math.Sqrt(x) * Math.Exp(x)},
        };
    }
}
