using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Service
{
    public class Service1 : IService1
    {
        //path of the main file
        public static string location = AppDomain.CurrentDomain.BaseDirectory + @"\Content.txt";
        //counter used for naming files
        static int counter = 0;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        /// <summary>
        /// Method takes file content and creates List<string>
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Find last (the biggest) order number in file
        /// </summary>
        /// <returns></returns>
        public int FindMinimumOrder()
        {
            List<string> list = ReadFile();

            string lastLine = list[list.Count - 1];

            string[] array = lastLine.Split(' ').ToArray();

            int lastNumber = Convert.ToInt32(array[0]);
            return lastNumber;

        }
        /// <summary>
        /// Create new item and save it into file
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        public void CreateNewItem(string name, int amount, int price)
        {           
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
        //WCF creates many problems with methods=>so I was trying all kinds of different stuff, that's the reason for these nonsense methods
        public void WriteFile()
        {


        }
        public void anything()
        {
            Console.WriteLine("sta bilo");
        }

        /// <summary>
        /// Take content of file and create list of objects
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// This method will be called whenever changes are made. First it clears the content of the file and then writes new state
        /// </summary>
        /// <param name="list"></param>
        public void WriteObjectListToFile(List<Item> list)
        {
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
        //another useless method
        public void WriteBillToFile()
        {
            //string location = AppDomain.CurrentDomain.BaseDirectory + @"\Content.txt";
        }
        /// <summary>
        /// Method creates bill,name of the file contains static counter and timestamp
        /// </summary>
        /// <param name="list"></param>
        /// <param name="total"></param>
        public void CreateBill(List<string> list, int total)
        {
            string count = counter.ToString();
            string timeStamp = DateTime.Now.ToString("dd-MM-yyy_H:mm:ss");
            //create name of the file (asked in task specification)
            string location = AppDomain.CurrentDomain.BaseDirectory+ @"\Racun" + "_" + count +"_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + ".txt";
            
            StreamWriter sw = new StreamWriter(location);
            //insert timestamp into file=>create one bill and than look at file content=>it will be clear to you
            sw.WriteLine(timeStamp);
            //write elements of the list
            foreach (string item in list)
            {
                sw.WriteLine(item);
            }
            //write total price
            sw.WriteLine("Total price:{0}",total);
            sw.Close();
            //increment counter
            counter++;
        }
    }
}
