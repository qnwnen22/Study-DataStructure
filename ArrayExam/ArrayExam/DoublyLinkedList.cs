using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExam
{
    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;

        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null) // 리스트가 비어 있으면
            {
                head = newNode;
            }
            else // 비어 있지 않으면, 마지막으로 이동하여 추가
            {
                var current = head;
                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }

                // 추가할 때 양방향 연결
                current.Next = newNode;
                newNode.Prev = current;
            }
        }

        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidCastException();
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

            // 삭제 노드가 첫 노드이면
            if (removeNode == head)
            {

                head = head.Next;
                if (head != null)
                {
                    head.Prev = null;
                }
            }
            else // 첫 노드가 아니면, Prev노드와 Next노드를 연결
            {
                removeNode.Prev.Next = removeNode.Next;
                if (removeNode.Next != null)
                {
                    removeNode.Next.Prev = removeNode.Prev;
                }
            }

            removeNode = null;
        }

        public DoublyLinkedListNode<T> GetNode(int index)
        {
            var current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            // 만약 index가 리스트 카운트보다 크면 null리턴
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
            // 정수형 이중 연결 리스트 생성
            var list = new DoublyLinkedList<int>();

            // 리스트에 0 ~ 4 추가
            for (int i = 0; i < 5; i++)
            {
                list.Add(new DoublyLinkedListNode<int>(i));
            }

            // Index가 2인 요소 삭제
            var node = list.GetNode(2);
            list.Remove(node);

            // Index가 1인 요소 가져오기
            node = list.GetNode(1);
            // Index가 1인 요소 뒤에 100삽입
            list.AddAfter(node, new DoublyLinkedListNode<int>(100));

            // 리스트 카운터 체크
            int count = list.Count();

            //전체 리스트 출력
            //결과 : 0 1 100 3 4
            for (int i = 0; i < count; i++)
            {
                var n = list.GetNode(i);
                Console.WriteLine(n.Data);
            }

            // 리스트 역으로 출력
            // 결과 4 3 100 1 0
            node = list.GetNode(4);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(node.Data);
                node = node.Prev;
            }
        }
    }
}
