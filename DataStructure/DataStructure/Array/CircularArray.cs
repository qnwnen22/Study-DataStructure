using System;

namespace DataStructure.Array
{
    public class CircularArray
    {
        public static void ShowExample(int startIndex = 2)
        {
            char[] A = "abcdefgh".ToCharArray();

            for (int i = 0; i < A.Length; i++)
            {
                int index = (startIndex + i) % A.Length;
                Console.WriteLine(A[index]);
            }
        }
    }
}
