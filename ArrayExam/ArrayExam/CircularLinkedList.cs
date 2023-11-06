using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExam
{

    public class CircularLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;

        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
                head.Next = head;
                head.Prev = head;
            }
            else
            {
                var tail = head.Prev;

                head.Prev = newNode;
                tail.Next = newNode;

                newNode.Prev = tail;
                newNode.Next = head;
            }
        }

        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            current.Next.Prev = newNode;

            newNode.Prev = current;
            current.Next = newNode;
        }

        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            if (removeNode == head && head == head.Next)
            {
                head = null;
            }
            else
            {
                removeNode.Prev.Next = removeNode.Next;
                removeNode.Next.Prev = removeNode.Prev;
            }
        }

        public DoublyLinkedListNode<T> GetNode(int index)
        {
            if (head == null) return null;

            int cnt = 0;
            var current = head;
            while (cnt < index)
            {
                current = current.Next;
                cnt++;
                if (current == head)
                {
                    return null;
                }
            }

            return current;
        }

        public int Count()
        {
            if (head == null) return 0;
            int cnt = 0;
            var current = head;
            do
            {
                cnt++;
                current = current.Next;
            }
            while (current != head);
            return cnt;
        }

        public static void ShowExample()
        {
            var list = new CircularLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(new DoublyLinkedListNode<int>(i));
            }

            var node = list.GetNode(2);
            list.Remove(node);

            node = list.GetNode(1);
            list.AddAfter(node, new DoublyLinkedListNode<int>(100));

            int count = list.Count();

            node = list.GetNode(0);
            for (int i = 0; i < count * 2; i++)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
        }

        public static bool IsCircular(DoublyLinkedListNode<T> head)
        {
            if (head == null) return true;

            var current = head;
            while (current != null)
            {
                current = current.Next;
                if (current == head)
                {
                    return true;
                }
            }

            return false;
        }

        //public static bool Is
    }
}
