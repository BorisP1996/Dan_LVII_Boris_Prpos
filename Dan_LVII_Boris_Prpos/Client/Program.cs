using Service;
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
            // List<string> list = new List<string>();
            // list = proxy.ReadFile().ToList();

            // foreach (string item in list)
            // {
            //     Console.WriteLine(item);
            // }

            //// proxy.CreateNewItem("Brasno", 20, 30);
            // Console.WriteLine("proslo");

            List<Item> list = proxy.CreateObjectList().ToList();

            foreach (Item item in list)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Enter number for item you want to change:");
            int itemNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter new price");
            int newPrice = Convert.ToInt32(Console.ReadLine());

            Item selectedItem = list[itemNumber - 1];
            selectedItem.Price = newPrice;

            proxy.WriteObjectListToFile(list);

           
            Console.ReadKey();
        }
       
    }
}
