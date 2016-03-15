using System;
using System.Collections.Generic;

namespace Integrals
{
    public class Parameters
    {
        private int N { get; }
        public double Left => 0.1 * N;
        public double Right => 0.5 + 0.2 * N;

        public Parameters(int N)
        {
            this.N = N;
        }

        public IEnumerable<Method> GetMethods()
        {
            return Methods[N];
        }

        private static Dictionary<int, IEnumerable<Method>> Methods => new Dictionary<int, IEnumerable<Method>>
        {
            {6, new List<Method> {new LeftRectangle(), new ThreeEight()}},
            {9, new List<Method> {new Trapeze(), new Simpson()}},
            {20, new List<Method> {new Simpson(), new Gregory()}},
        };

        public IGaussMethod GetGaussMethod()
        {
            return GaussMethods[N];
        }

        private Dictionary<int, IGaussMethod> GaussMethods => new Dictionary<int, IGaussMethod>
        {
            {6, new Gauss2(GetIntegrand(), Left, Right)},
            {9, new Gauss3(GetIntegrand(), Left, Right)},
            {20, new Gauss2(GetIntegrand(), Left, Right)},
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
