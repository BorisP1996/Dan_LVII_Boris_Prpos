using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            List<string> list = new List<string>();
            list = proxy.ReadFile().ToList();

            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
           


         
            





            Console.ReadKey();
        }
    }
}
