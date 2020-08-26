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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<string> ReadFile()
        {
            string location = AppDomain.CurrentDomain.BaseDirectory + @"\Content.txt";


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
            throw new NotImplementedException();
        }
    }
}
