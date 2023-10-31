using System;

namespace ArrayExam
{
    public class SinglyLinkedList<T>
    {
        private SinglyLinckedListNode<T> head;

        public void Add(SinglyLinckedListNode<T> newNode)
        {

            if (head == null) // 리스트가 비어 있으면
            {
                head = newNode;
            }
            else // 비어 있지 않으면
            {
                var current = head;
                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void AddAfter(SinglyLinckedListNode<T> current, SinglyLinckedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new ApplicationException();
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public void Remove(SinglyLinckedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            if (removeNode == head)
            {
                head = head.Next;
                removeNode = null;
            }
            else
            {
                var current = head;

                // 단방향이므로 삭제할 노드의
                // 바로 이전 노드를 검색해야함
                while (current != null && current.Next != removeNode)
                {
                    current = current.Next;
                }

                if (current != null)
                {
                    // 이전 노드의 Next에 삭제노드의 Next를 할당
                    current.Next = removeNode.Next;
                    removeNode = null;
                }
            }
        }

        public SinglyLinckedListNode<T> GetNode(int index)
        {
            var current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            // 만약 index가 리스트 카운트보다 크면
            // null이 리턴됨
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

        /// <summary>
        /// 구현한 단일 연결 리스트의 기본 기능을 테스트 하기 위하여, 
        /// 단일 연결 리스트에 0, 1, 2, 3, 4 요소를 추가하고, 
        /// 중간의 2를 삭제하고 대신 100을 넣은 후, 
        /// 리스트 전체를 출력하는 예제코드
        /// </summary>
        public static void ShowExample()
        {
            // 정수형 단일 연결 리스트 생성
            var list = new SinglyLinkedList<int>();

            // 리스트에 0 ~ 4 추가
            for (int i = 0; i < 5; i++)
            {
                list.Add(new SinglyLinckedListNode<int>(i));
            }

            // Index가 2인 요소 삭제
            var node = list.GetNode(2);
            list.Remove(node);

            // Index가 1인 요소 가져오기
            node = list.GetNode(1);
            // Index가 1인 요소 뒤에 100 삽입
            list.AddAfter(node, new SinglyLinckedListNode<int>(100));

            // 리스트 카운트 체크
            int count = list.Count();

            // 전체 리스트 출력
            // 결과 : 0 1 100 3 4
            for (int i = 0; i < count; i++)
            {
                var n = list.GetNode(i);
                Console.WriteLine(n.Data);
            }

        }
    }
}
