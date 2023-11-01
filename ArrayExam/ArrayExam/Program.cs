using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedList<string>();
            list.Add(new DoublyLinkedListNode<string>("1"));
            list.Add(new DoublyLinkedListNode<string>("2"));
            list.Add(new DoublyLinkedListNode<string>("3"));
            list.Add(new DoublyLinkedListNode<string>("4"));

            var t = list.GetNode(2);
            list.Remove(t);
        }
    }
}
