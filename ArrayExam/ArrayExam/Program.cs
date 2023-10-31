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
            var list = new SinglyLinkedList<string>();

            for (int i = 0; i < 20; i++)
            {
                list.Add(new SinglyLinckedListNode<string>(i.ToString()));
            }

            for (int i = 0; i < list.Count(); i++)
            {
                SinglyLinckedListNode<string> node = list.GetNode(i);
                Console.WriteLine(node.Data);
            }

        }
    }
}
