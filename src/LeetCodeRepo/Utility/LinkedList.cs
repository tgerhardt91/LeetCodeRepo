using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeRepo.Utility
{
    public class Node
    {
        public Node Next;
        public Object Data;
    }

    public class LinkedList
    {
        public Node Head;

        public void Add(Object data)
        {
            Node toAdd = new Node();
            toAdd.Data = data;
            Node current = Head;

            current.Next = toAdd;
        }
    }
}
