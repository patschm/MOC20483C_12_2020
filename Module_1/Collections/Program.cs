using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array is een rijtje van gelijkgestemde waardes
            // Benaderbaar middels een index
            // Aangesloten geheugen
            // Is immutable

            int[] array = new int[10] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            //array[0] = 10;
            //array[1] = 20;
            //Console.WriteLine(array[5]);
            int[,] matrix = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            Console.WriteLine(matrix[1,1]);
            int[,,] kubus = new int[3, 3, 3];

            // jagged
            int[][] jagged = new int[5][];
            jagged[0] = new int[5];
            jagged[1] = new int[10];

            List<int> lst = new List<int>();
            lst.Add(4);

            Dictionary<string, int> lookup = new Dictionary<string, int>();
            lookup.Add("een", 1);
            Console.WriteLine(lookup["een"]);

            // LIFO
            Stack<long> stack = new Stack<long>();
            stack.Push(5);
            long nr = stack.Pop();

            // FIFO
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Eerste");
            string eerste = queue.Dequeue();

            // Bloedjesnel
            for(int i = 0; i < array.Length; i++)
            {
                int tmp = array[i];
                Console.WriteLine(tmp);
            }

            // Iets trager vanwege iterator design pattern dat is toegepast
            foreach(int tmp in array)
            {
                Console.WriteLine(tmp);
            }

        }
    }
}
