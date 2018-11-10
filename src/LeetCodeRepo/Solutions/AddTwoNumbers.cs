using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using LeetCodeRepo.Utility;
using Xunit;
using Xunit.Sdk;

namespace LeetCodeRepo.Solutions
{
    public class AddTwoNumbers : IAmALeetCodeSolution
    {
        public bool Execute()
        {
            var linkedList1 = new LinkedList();
            linkedList1.Add(2);
            linkedList1.Add(4);
            linkedList1.Add(3);

            var linkedList2 = new LinkedList();
            linkedList2.Add(5);
            linkedList2.Add(6);
            linkedList2.Add(4);

            var solution = Solution(linkedList1.Head, linkedList2.Head);

            return IsCorrect(solution);
        }

        public int SolutionId() => 2;

        public string Difficulty() => "Medium";

        public string Description() => "Add Two Numbers";

        private static int Solution(Node list1, Node list2)
        {
            return GetIntegerFromLinkedList(list1) + GetIntegerFromLinkedList(list2);
        }

        private static int GetIntegerFromLinkedList(Node currentNode)
        {
            var multiplyer = 1;
            var total = 0;

            while (currentNode != null)
            {
                total += Convert.ToInt32(currentNode.Data) * multiplyer;

                multiplyer *= 10;

                currentNode = currentNode.Next;
            }

            return total;
        }

        private static bool IsCorrect(int solution)
        {
            return solution == 807;
        }
    }
}
