using System;

namespace ArrayExam
{
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> head;

        /// <summary>
        /// 리스트가 비어 있으면 Head에 새 노드를 할당하고,
        /// 비어 있지 않으면 마지막 노드를 찾아 이동한 후
        /// 마지막 노드 다음에 새 노드를 추가한다.
        /// (만약 Head와 함께 Tail 필드를 추가하고 마지막 노드를 Tail 필드에 저장한다면,
        /// Add 메서드에서 새 노드를 추가할 때 Tail이 가리키는 마지막 노드 다음에 직접 새 노드를 추가할 수 있다)
        /// </summary>
        /// <param name="newNode"></param>
        public void Add(SinglyLinkedListNode<T> newNode)
        {
            if (head == null) // 리스트가 비어 있으면
            {
                head = newNode;
            }
            else // 비어 있지 않으면
            {
                var current = head;
                // 마지막 노드로 이동하여 추가
                while (current != null && current.Next != null) // 다음 노드가 null일 경우 break
                {
                    current = current.Next;
                }
                current.Next = newNode; // 비어있는 다음 노트에 새로운 노드를 삽입
            }
        }

        public void AddAfter(SinglyLinkedListNode<T> current, SinglyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null) // 헤드 혹은 인자가 하나라도 null인 경우 예외처리
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next; // 신규 노드에 다음 헤드를 현재에 다음 노드로 연결
            current.Next = newNode; // 현재에 다음 노드는 신규 노드로 초기화
        }

        public void Remove(SinglyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null) // 현재 헤드 혹은 인자가 null일 경우 바로 반환
            {
                return;
            }

            if (removeNode == head) // 삭제할 노드가 첫 노드와 일치할 경우
            {
                head = head.Next; // 다음 노드를 현재 요소(헤드)로 초기화
                removeNode = null;
            }
            else // 첫 노드와 일치하지 않을 경우
            {
                var current = head;

                // 현재 요소가 null이거나 다음 요소가 삭제 요소와 같을 경우 break
                // (삭제 노드와 일치하는 노드를 현재 노드에 초기화하는 과정)
                while (current != null && current.Next != removeNode)
                {
                    current = current.Next; // 현재 노드를 다음 노드로 초기화 후 반복
                }

                if (current != null) // 현재 노드가 null이 아닐 경우
                {
                    // current.Next = 삭제 노드와 일치하는 노드
                    // removeNode.Next = 삭제할 노드의 다음 노드
                    current.Next = removeNode.Next;
                    removeNode = null;
                }
            }
        }

        public SinglyLinkedListNode<T> GetNode(int index)
        {
            var current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            //만약 index가 리스트 카운트보다 크면 
            //null이 리턴됨 => 연결된 다음 노드가 null이기 때문
            return current;
        }

        public int Count()
        {
            int cnt = 0;

            var current = head;
            while (current != null) // 연결된 다음 노드가 null일 때까지 반복
            {
                cnt++;
                current = current.Next;
            }
            return cnt;
        }

        public static void ShowExample()
        {
            var list = new SinglyLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(new SinglyLinkedListNode<int>(i));
            }

            var node = list.GetNode(2);
            list.Remove(node);

            node = list.GetNode(1);
            list.AddAfter(node, new SinglyLinkedListNode<int>(100));

            int count = list.Count();

            for (int i = 0; i < count; i++)
            {
                var n = list.GetNode(i);
                Console.WriteLine(n.Data);
            }
        }

    }
}
