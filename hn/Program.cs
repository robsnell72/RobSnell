using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hn
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] == "/standard")
            {
                for (int i=1;i<101;i++)
                {
                    HappyNumber hn = new HappyNumber(i);
                    Console.WriteLine($"({i})=>{hn.isHappy}");
                }

                Console.ReadLine();
            }
            else if (args[0] == "/parallel")
            {
                Parallel.For(0, 101,
                  index =>  {
                      HappyNumber hn = new HappyNumber(index);
                      Console.WriteLine($"({index})=>{hn.isHappy}");
                  }
                );

                Console.ReadLine();
            }
        }
    }
}
