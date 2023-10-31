using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExam
{
    public class SinglyLinckedListNode<T>
    {
        public T Data { get; set; }
        public SinglyLinckedListNode<T> Next { get; set; }


        public SinglyLinckedListNode(T data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
}
