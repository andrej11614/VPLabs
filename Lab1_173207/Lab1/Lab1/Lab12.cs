using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Lab12
    {
       /* static void Main(string[] args)
        {
            int k;
            int[] arr=new int[0];
            while (true)
            {
                Console.WriteLine("Slucajno Generirani - 0");
                Console.WriteLine("Manuelno Vnesuvanje - 1");

                try
                {
                    k = Convert.ToInt32(Console.ReadLine());
                    if (k != 1 && k != 0) continue;
                    else break;

                }
                catch (Exception e) {
                    continue;
                }
            }
            if (k == 1)
            {
                int N = Convert.ToInt32(Console.ReadLine());

                arr = new int[N];

                for (int i = 0; i < N; i++)
                {
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }


            }
            if (k == 0) {
                Random rnd = new Random();
                int N = rnd.Next(1,10);
                arr = new int[N];
                for (int i = 0; i < N; i++)
                {
                    arr[i] = rnd.Next(1,1000);
                }
            }
            Console.WriteLine(arr.Sum() / arr.Length+" prosecno");
            Console.WriteLine(arr.Max()+" max");
            Console.WriteLine(arr.Min()+" min");
            Console.ReadKey();
        }*/
    }
}
