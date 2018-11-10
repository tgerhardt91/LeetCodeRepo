using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeRepo.Utility
{
    public class Node
    {
        public Node Next;
        public object Data;
    }

    public class LinkedList
    {
        public Node Head;
        private Node _current;

        public LinkedList()
        {
            Head = new Node();
        }

        public void Add(object data)
        {
            var toAdd = new Node {Data = data};

            if (ListIsEmpty(Head))
                SetHeadAndAdvanceCurrent(toAdd);
            else
                SetAndAdvanceCurrent(toAdd);           
        }

        private static bool ListIsEmpty(Node head)
        {
            return head?.Data == null;
        }

        private void SetHeadAndAdvanceCurrent(Node nodeToAdd)
        {
            Head = nodeToAdd;
            _current = Head;
        }

        private void SetAndAdvanceCurrent(Node nodeToAdd)
        {
            _current.Next = nodeToAdd;
            _current = _current.Next;
        }
    }
}
