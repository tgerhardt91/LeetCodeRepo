using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LeetCodeRepo.Solutions;

namespace SolutionConsole
{
    public class SolutionConsoleHelper
    {
        public IEnumerable<IAmALeetCodeSolution> GetSolutionsOrderedById()
        { 
            var interfaceType = typeof(IAmALeetCodeSolution);

            var solutionAssembly = Assembly.GetAssembly(interfaceType);

            var interfaceImplementations = solutionAssembly
                .GetTypes()
                .Where(x => x.GetInterfaces()
                    .Contains(interfaceType));

            return interfaceImplementations.Where(x => x.FullName != null).Select(x =>
                solutionAssembly.CreateInstance(x.FullName) as IAmALeetCodeSolution).OrderBy(x => x.SolutionId());
        }
    }
}
