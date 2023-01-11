using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KuberBankApplicationProject2
{
   public class OurMultithreading
    {
        public void process()
        {
            Console.WriteLine("please wait process is working----");
            for (int i=0;i<=7;i++)
            {
                Console.WriteLine("\t-");
                Thread.Sleep(500);
                
            }
            Console.WriteLine();
        }

    }
}
