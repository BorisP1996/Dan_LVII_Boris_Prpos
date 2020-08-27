using Client.Validate;
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
            bool work = false;
            Validation validate = new Validation();

            while (work == false)
            {

                Console.WriteLine("\n1. Update product price");
                Console.WriteLine("2. Update product amount");
                Console.WriteLine("3. Update product name");
                Console.WriteLine("4. Add new product");
                Console.WriteLine("5. Display every product");
                Console.WriteLine("6. Create bill");
                Console.WriteLine("7. Exit");
                Console.WriteLine("\nPick one option from the list:\n");
                string pick;
                switch (pick=Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("*Name*Amount*Price*");
                        List<Item> list = proxy.CreateObjectList().ToList();

                        foreach (Item item in list)
                        {
                            Console.WriteLine(item.ToString());
                        }

                        Console.WriteLine("\nEnter number for item that will receive new price:\n");
                        
                        int itemNumber;
                        bool tryItem = Int32.TryParse(Console.ReadLine(), out itemNumber);
                        while (!tryItem || itemNumber<1 || itemNumber>list.Count)
                        {
                            Console.WriteLine("Please enter number from the list:");
                            tryItem = Int32.TryParse(Console.ReadLine(), out itemNumber);
                        }
                        Console.WriteLine("Enter new price:");
                        int newPrice; 
                        bool TryPrice = Int32.TryParse(Console.ReadLine(), out newPrice);
                        while (!TryPrice || newPrice<1)
                        {
                            Console.WriteLine("Please insert number:");
                            TryPrice = Int32.TryParse(Console.ReadLine(), out newPrice);
                        }
                        Item selectedItem = list[itemNumber - 1];
                        selectedItem.Price = newPrice;

                        proxy.WriteObjectListToFile(list);
                        Console.WriteLine("Price has been modified");
                        break;
                    case "2":
                        Console.WriteLine("*Name*Amount*Price*");
                        List<Item> list1 = proxy.CreateObjectList().ToList();

                        foreach (Item item in list1)
                        {
                            Console.WriteLine(item.ToString());
                        }

                        Console.WriteLine("\nEnter number for item that will receive new amount:\n");
                        int itemNumber1;
                        bool tryItem2 = Int32.TryParse(Console.ReadLine(), out itemNumber1);
                        while (!tryItem2 || itemNumber1 < 1 || itemNumber1 > list1.Count)
                        {
                            Console.WriteLine("Please enter number from the list:");
                            tryItem2 = Int32.TryParse(Console.ReadLine(), out itemNumber1);
                        }

                        Console.WriteLine("Enter new amount");
                        int newAmount;
                        bool tryAmount = Int32.TryParse(Console.ReadLine(), out newAmount);
                        while (!tryAmount || newAmount<0)
                        {
                            Console.WriteLine("Please insert number:");
                            tryAmount = Int32.TryParse(Console.ReadLine(), out newAmount);
                        }

                        Item selectedItem1 = list1[itemNumber1 - 1];
                        selectedItem1.Amount = newAmount;

                        proxy.WriteObjectListToFile(list1);
                        Console.WriteLine("Amount has been modified");
                        break;
                    case "3":
                        Console.WriteLine("*Name*Amount*Price*");
                        List<Item> list2 = proxy.CreateObjectList().ToList();

                        foreach (Item item in list2)
                        {
                            Console.WriteLine(item.ToString());
                        }

                        Console.WriteLine("\nEnter number for item that will receive new name:\n");

                        int itemNumber2;
                        bool tryItem3 = Int32.TryParse(Console.ReadLine(), out itemNumber2);
                        while (!tryItem3 || itemNumber2 < 1 || itemNumber2 > list2.Count)
                        {
                            Console.WriteLine("Please enter number from the list:");
                            tryItem3 = Int32.TryParse(Console.ReadLine(), out itemNumber2);
                        }


                        Console.WriteLine("Enter new name");
                        string newName = Console.ReadLine();
                        while (String.IsNullOrEmpty(newName))
                        {
                            Console.WriteLine("Name can not be empty. Please try again:");
                            newName = Console.ReadLine();
                        }
                        newName = ReplaceBlankSpace(newName);
                        Item selectedItem2 = list2[itemNumber2 - 1];
                        selectedItem2.Name = newName;

                        proxy.WriteObjectListToFile(list2);
                        Console.WriteLine("Name has been modified");
                        break;
                    case "4":
                        Console.WriteLine("\nEnter name for new product\n");
                        string name = Console.ReadLine();
                        while (String.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Name can not be empty. Please try again:");
                            name = Console.ReadLine();
                        }
                        name = ReplaceBlankSpace(name);
                        Console.WriteLine("\nEnter new amount\n");
                        int newAmount1;
                        bool tryAmount4 = Int32.TryParse(Console.ReadLine(), out newAmount1);
                        while (!tryAmount4 || newAmount1 < 1)
                        {
                            Console.WriteLine("Amount must be positive number:");
                            tryAmount4 = Int32.TryParse(Console.ReadLine(), out newAmount1);
                        }


                        Console.WriteLine("\nEnter price\n");
                        int newPrice1;
                        bool tryAmount5 = Int32.TryParse(Console.ReadLine(), out newPrice1);
                        while (!tryAmount5 || newPrice1 < 1)
                        {
                            Console.WriteLine("Price must be positive number:");
                            tryAmount5 = Int32.TryParse(Console.ReadLine(), out newPrice1);
                        }
                        proxy.CreateNewItem(name,newAmount1,newPrice1);
                        Console.WriteLine("New item is added.");
                        break;
                    case "5":
                        Console.WriteLine("*Name*Amount*Price*");
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
                            Console.WriteLine("*Name*Amount*Price*");

                            List<Item> listBill = proxy.CreateObjectList().ToList();

                            foreach (Item item in listBill)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.WriteLine("\nSelect number for product you want to buy or press x to exit\n");
                            string inputS = Console.ReadLine();
                            
                            if (inputS=="x")
                            {
                                break;
                            }
                            int input;
                            bool TryFinal = Int32.TryParse(inputS, out input);
                            while (!TryFinal || input<1 || input>listBill.Count)
                            {
                                Console.WriteLine("Please select number from the list:");
                                inputS = Console.ReadLine();
                                TryFinal = Int32.TryParse(inputS, out input);
                            }
                            
                            Item pickedItem = listBill[input - 1];
                            string nameItem = pickedItem.Name;
                            Console.WriteLine("Insert amount you want to buy");
                            int pickedAmount;
                            bool tryAmountFinal = Int32.TryParse(Console.ReadLine(), out pickedAmount);
                            while (!tryAmountFinal || pickedAmount > pickedItem.Amount)
                            {
                                Console.WriteLine("Insert number smaller or equal to available amount:");
                                tryAmountFinal = Int32.TryParse(Console.ReadLine(), out pickedAmount);
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
                            Console.WriteLine("\nBill is created and saved in file.");
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

