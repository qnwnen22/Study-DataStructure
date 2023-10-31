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
            if (head == null) // 리스트가 비어 있으면
            {
                head = newNode;
                head.Next = head;
                head.Prev = head;
            }
            else // 비어 있지 않으면 헤드와 테일 사이에 삽입
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

            // 삭제할 노드가 헤드 노드이고 노드가 1개이면
            if (removeNode == head && head == head.Next)
            {
                head = null;
            }
            else // 아니면 Prev 노드와 Next 노드를 연결
            {
                removeNode.Prev.Next = removeNode.Next;
                removeNode.Next.Prev = removeNode.Prev;
            }

            removeNode = null;
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
            // 정수형 원형 연결 리스트 생성
            var list = new CircularLinkedList<int>();

            // 리스트에 0 ~ 5 추가
            for (int i = 0; i < 5; i++)
            {
                list.Add(new DoublyLinkedListNode<int>(i));
            }

            // Index가 2인 요소 삭제
            var node = list.GetNode(2);
            list.Remove(node);

            // Index가 1인 요소 가져오기
            node = list.GetNode(1);
            // Index가 1인 뒤에 100 삽입
            list.AddAfter(node, new DoublyLinkedListNode<int>(100));

            // 리스트 카운터 체크
            int count = list.Count();

            // 원형 리스트 확인 위해 리스트 두배 출력
            // 결과: 0 1 100 3 4 0 100 3 4
            node = list.GetNode(0);
            for (int i = 0; i < count * 2; i++)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
        }
    }
}
