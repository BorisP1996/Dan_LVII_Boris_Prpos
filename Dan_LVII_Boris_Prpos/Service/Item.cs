using System;
using System.IO;

namespace Service
{
    /// <summary>
    /// Class that represents "objects" (basicaly they are lines of text in file)
    /// </summary>
    public class Item
    {
        public static string location = AppDomain.CurrentDomain.BaseDirectory + @"\Content.txt";

        public string Name { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int ID { get; set; }

        public Item()
        {

        }
        public Item(int order,string n, int a,int p)
        {
            ID = order;
            Name = n;
            Amount=a;
            Price = p;
        }

        Service1 service = new Service1();

        public void WriteToFile(int order)
        {
            StreamWriter sw = new StreamWriter(location,true);
            int incremented = order + 1;
            sw.WriteLine(incremented + " " + Name + " " + Amount + " " + Price);
            sw.Close();
            
        }

        public void WriteToFileID()
        {
            StreamWriter sw = new StreamWriter(location, true);
            
            sw.WriteLine(ID + " " + Name + " " + Amount + " " + Price);
            sw.Close();

        }
        public override string ToString()
        {
            string format = ID + " " + Name + " " + Amount + " " + Price;
            return format;
        }
    }
}