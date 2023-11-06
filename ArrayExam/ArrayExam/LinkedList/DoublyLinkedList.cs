using System;
namespace ArrayExam
{
    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;

        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null) // 현재가 비어 있을 경우
            {
                head = newNode;
            }
            else // 현재가 비어 있지 않을 경우
            {
                var current = head;
                // 논리적으로 current는 null이 될 수 없음
                // current.Next가 null이 아닐 경우 종료
                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
                newNode.Prev = current;
                newNode.Next = null;
            }
        }

        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            // 노드 중에 하나라도 null일 경우 예외처리
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
            // 노드가 null일 경우 처리하지 않음
            if (head == null || removeNode == null)
            {
                return;
            }

            if (removeNode == head)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Prev = null;
                }
            }
            else
            {
                removeNode.Prev.Next = removeNode.Next;
                if (removeNode.Next != null)
                {
                    removeNode.Next.Prev = removeNode.Prev;
                }
            }
        }

        public DoublyLinkedListNode<T> GetNode(int index)
        {
            var current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public int Count()
        {
            int cnt = 0;

            var current = head;
            while (current != null)
            {
                cnt++;
                current = current.Next;
            }

            return cnt;
        }

        public static void ShowExample()
        {
            var list = new DoublyLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(new DoublyLinkedListNode<int>(i));
            }

            var node = list.GetNode(2);
            list.Remove(node);

            node = list.GetNode(1);
            list.AddAfter(node, new DoublyLinkedListNode<int>(100));

            int count = list.Count();

            for (int i = 0; i < count; i++)
            {
                var n = list.GetNode(i);
                Console.WriteLine(n.Data);
            }

            node = list.GetNode(4);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(node.Data);
                node = node.Prev;
            }

        }
    }
}
