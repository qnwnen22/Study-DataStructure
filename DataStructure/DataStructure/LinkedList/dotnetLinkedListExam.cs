using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.LinkedList
{
    public class DotnetLinkedListExam
    {
        public static void ShowExample()
        {
            var list = new LinkedList<string>();
            list.AddLast("Apple");
            list.AddLast("Banana");
            list.AddLast("Lemon");

            var node = list.Find("Banana");
            var newNode = new LinkedListNode<string>("Grape");

            // 새 Grape 노드를 Banana 노드 뒤에 추가
            list.AddAfter(node, newNode);

            // 리스트 출력
            list.ToList().ForEach(p => Console.WriteLine(p));

            // Grape 삭제
            list.Remove("Grape");

            // Enumerator를 이용한 리스트 출력
            foreach (var m in list)
            {
                Console.WriteLine(m);
            }

        }
    }
}
