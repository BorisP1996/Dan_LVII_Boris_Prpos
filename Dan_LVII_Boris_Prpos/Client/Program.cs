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

            //List<Item> list = proxy.CreateObjectList().ToList();

            //foreach (Item item in list)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //Console.WriteLine("Enter number for item you want to change:");
            //int itemNumber = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("enter new price");
            //int newPrice = Convert.ToInt32(Console.ReadLine());

            //Item selectedItem = list[itemNumber - 1];
            //selectedItem.Price = newPrice;

            //proxy.WriteObjectListToFile(list);


            bool work = false;

            while (work == false)
            {

                Console.WriteLine("1. Update product price");
                Console.WriteLine("2. Update product amount");
                Console.WriteLine("3. Update product name");
                Console.WriteLine("4. Add new product");
                Console.WriteLine("5. Display every product");
                Console.WriteLine("6. Create bill");
                Console.WriteLine("7. Exit");
                string pick;
                switch (pick=Console.ReadLine())
                {
                    case "1":
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
                        Console.WriteLine("Price has been modified");
                        break;
                    case "2":
                        List<Item> list1 = proxy.CreateObjectList().ToList();

                        foreach (Item item in list1)
                        {
                            Console.WriteLine(item.ToString());
                        }

                        Console.WriteLine("Enter number for item you want to change:");
                        int itemNumber1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new amount");
                        int newAmount = Convert.ToInt32(Console.ReadLine());

                        Item selectedItem1 = list1[itemNumber1 - 1];
                        selectedItem1.Amount = newAmount;

                        proxy.WriteObjectListToFile(list1);
                        Console.WriteLine("Amount has been modified");
                        break;
                    case "3":
                        List<Item> list2 = proxy.CreateObjectList().ToList();

                        foreach (Item item in list2)
                        {
                            Console.WriteLine(item.ToString());
                        }

                        Console.WriteLine("Enter number for item you want to change:");
                        int itemNumber2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new name");
                        string newName = Console.ReadLine();

                        Item selectedItem2 = list2[itemNumber2 - 1];
                        selectedItem2.Name = newName;

                        proxy.WriteObjectListToFile(list2);
                        Console.WriteLine("Name has been modified");
                        break;
                    case "4":
                        Console.WriteLine("Enter name for new product");
                        string name = Console.ReadLine();
                        name = ReplaceBlankSpace(name);
                        Console.WriteLine("Enter amount");
                        int Amount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter price");
                        int Price = Convert.ToInt32(Console.ReadLine());
                        proxy.CreateNewItem(name,Amount,Price);
                        Console.WriteLine("New item is added.");
                        break;
                    case "5":
                        List<Item> listDisplay = proxy.CreateObjectList().ToList();

                        foreach (Item item in listDisplay)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case "6":
                       
                        List<string> bucketList = new List<string>();
                        int total_amount = 0;
                        bool spin = false;
                        while (spin == false)
                        {
                            List<Item> listBill = proxy.CreateObjectList().ToList();

                            foreach (Item item in listBill)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.WriteLine("Select number for product you want to buy or press x to exit");
                            string input = Console.ReadLine();
                            if (input=="x")
                            {
                                break;
                            }
                            int serialNum = Convert.ToInt32(input);
                            Item pickedItem = listBill[serialNum - 1];
                            string nameItem = pickedItem.Name;
                            Console.WriteLine("Insert amount you want to buy");
                            int pickedAmount = Convert.ToInt32(Console.ReadLine());
                            while (pickedAmount > pickedItem.Amount)
                            {
                                Console.WriteLine("Can not buy that many products, try with smaller amount.");
                                pickedAmount = Convert.ToInt32(Console.ReadLine());
                            }
                            pickedItem.Amount -= pickedAmount;
                            string total = nameItem + "_" + pickedAmount.ToString() + "*" + pickedItem.Price.ToString();
                            total_amount += pickedAmount * pickedItem.Price; 
                            bucketList.Add(total);
                            Console.WriteLine("Product is added to your bucket list. Press x to finish shoping or any other key to continue.");
                            proxy.WriteObjectListToFile(listBill);
                            string input2 = Console.ReadLine();
                            if (input2=="x")
                            {
                                break;
                            }
                        }
                        if (bucketList.Count>0)
                        {
                            proxy.CreateBill(bucketList, total_amount);
                            Console.WriteLine("Bill is created and saved in file.");
                        }
                                      
                        break;
                    case "7":
                        work = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

                Console.ReadKey();
            }
        }

        static string ReplaceBlankSpace(string name)
        {
            char[] array = name.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]==' ')
                {
                    array[i] = '_';
                }
            }

            string result = string.Join("", array);
            return result;
        }
    }
}

