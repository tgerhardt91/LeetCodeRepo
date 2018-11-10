using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LeetCodeRepo.Solutions;

namespace SolutionConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var helper = new SolutionConsoleHelper();

            var solutions = helper.GetSolutionsOrderedById().ToList();

            var selection = GetSolutionSelectionFromUser(solutions.ToList());

            ExecuteSelection(solutions, selection);
        }

        private static void ExecuteSelection(IEnumerable<IAmALeetCodeSolution> solutions, int selection)
        {
            var solutionToExecute = solutions.FirstOrDefault(s => s.SolutionId() == selection);

            solutionToExecute?.Execute();
        }

        private static int GetSolutionSelectionFromUser(List<IAmALeetCodeSolution> solutions)
        {
            DisplaySolutions(solutions);

            return PromptUserForSelection(solutions);
        }

        private static void DisplaySolutions(IEnumerable<IAmALeetCodeSolution> solutions)
        {
            const int textSpacer = 3;

            var space = new String(' ', textSpacer);

            Console.WriteLine($"Solution# {space}|{space} Description {space}|{space} Difficulty");
            Console.WriteLine();

            foreach (var solution in solutions)
            {
                Console.WriteLine($"{solution.SolutionId()} {space}|{space} {solution.Description()} {space}|{space} {solution.Difficulty()}");
            }
        }

        private static int PromptUserForSelection(List<IAmALeetCodeSolution> solutions)
        {
            Console.WriteLine("Please select a problem to run (1, 2, etc.)");

            var selection = Convert.ToInt32(Console.ReadLine());

            var validSelections = solutions.Select(s => s.SolutionId());

            if (!validSelections.Contains(selection))
            {
                Console.WriteLine("Invalid Selection");
                PromptUserForSelection(solutions);
            }

            return selection;
        }
    }
}
