using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LeetCodeRepo.Solutions;

namespace SolutionConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            var t = GetSolutions();

            foreach (var implementation in t)
            {
                Console.WriteLine(implementation.Difficulty());
            }

            var x = 2;
        }

        private static IEnumerable<IAmALeetCodeSolution> GetSolutions()
        {
            var interfaceType = typeof(IAmALeetCodeSolution);

            var solutionAssembly = Assembly.GetAssembly(interfaceType);

            var interfaceImplementations = solutionAssembly
                .GetTypes()
                .Where(x => x.GetInterfaces()
                .Contains(interfaceType));

            return interfaceImplementations.Where(x => x.FullName != null).Select(x =>
                solutionAssembly.CreateInstance(x.FullName) as IAmALeetCodeSolution);
        }
    }
}
