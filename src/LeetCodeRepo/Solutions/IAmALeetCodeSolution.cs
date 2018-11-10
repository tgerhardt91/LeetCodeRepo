using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeRepo.Solutions
{
    public interface IAmALeetCodeSolution
    {
        bool Execute();
        int SolutionId();
        string Difficulty();
        string Description();
    }
}
