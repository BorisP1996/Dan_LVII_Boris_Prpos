using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    public class Service1 : IService1
    {
        public static string location = AppDomain.CurrentDomain.BaseDirectory + @"\Content.txt";
        static int counter = 0;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<string> ReadFile()
        {
            StreamReader sr = new StreamReader(location);
            string line = null;
            List<string> lineList = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                lineList.Add(line);
            }
            sr.Close();
            return lineList;
        }

        public int FindMinimumOrder()
        {
            List<string> list = ReadFile();

            string lastLine = list[list.Count - 1];

            string[] array = lastLine.Split(' ').ToArray();

            int lastNumber = Convert.ToInt32(array[0]);
            return lastNumber;

        }

        public void CreateNewItem(string name, int amount, int price)
        {
            //Console.WriteLine("Enter name for new item:");

            //string name = Console.ReadLine();

            //while (String.IsNullOrEmpty(name))
            //{
            //    Console.WriteLine("Name can not be empty, please try again:");
            //    name = Console.ReadLine();
            //}

            //Console.WriteLine("Insert amount for new item:");
            //int amount;
            //string inputAmount = Console.ReadLine();
            //bool tryParse = Int32.TryParse(inputAmount,out amount);
            //while (!tryParse || amount<0)
            //{
            //    Console.WriteLine("Amount must be positive number. Please try again:");
            //    inputAmount = Console.ReadLine();
            //}

            //Console.WriteLine("Insert price for new item:");
            //int price;
            //string inputPrice = Console.ReadLine();
            //bool tryPrice = Int32.TryParse(inputPrice, out price);
            //while (!tryPrice || price<0)
            //{
            //    Console.WriteLine("Price must be positive number:");
            //    inputPrice = Console.ReadLine();
            //}
            int order = FindMinimumOrder();
            Item item = new Item(order, name, amount, price);
            item.WriteToFile(order);

        }








        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }



        public void WriteFile()
        {


        }

        public void anything()
        {
            Console.WriteLine("sta bilo");
        }

        public List<Item> CreateObjectList()
        {
            List<string> lineList = ReadFile();
            List<Item> itemList = new List<Item>();

            for (int i = 0; i < lineList.Count; i++)
            {
                string[] array = lineList[i].Split(' ').ToArray();
                int order = Convert.ToInt32(array[0]);
                string name = array[1];
                int amount = Convert.ToInt32(array[2]);
                int price = Convert.ToInt32(array[3]);
                Item item = new Item(order, name, amount, price);
                itemList.Add(item);
            }

            return itemList;
        }

        public void WriteObjectListToFile(List<Item> list)
        {
            //List<Item> itemList = CreateObjectList();

            using (FileStream fs = File.Open(location, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                lock (fs)
                {
                    fs.SetLength(0);
                }
            }

            foreach (var item in list)
            {
                item.WriteToFileID();
            }
        }

        public void WriteBillToFile()
        {
            //string location = AppDomain.CurrentDomain.BaseDirectory + @"\Content.txt";
        }


        public void CreateBill(List<string> list, int total)
        {
            string count = counter.ToString();
            string timeStamp = DateTime.Now.ToString("dd-MM-yyy_H:mm:ss");

            string location = AppDomain.CurrentDomain.BaseDirectory+ @"\Racun" + "_" + count +"_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + ".txt";
            
            StreamWriter sw = new StreamWriter(location);

            sw.WriteLine(timeStamp);
            foreach (string item in list)
            {
                sw.WriteLine(item);
            }
            sw.WriteLine("Total price:{0}",total);
            sw.Close();
            counter++;
        }
    }
}
