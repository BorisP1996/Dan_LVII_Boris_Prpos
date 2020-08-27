using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Service
{

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void anything();

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        List<string> ReadFile();

        [OperationContract]
        void WriteFile();

        [OperationContract]
        void WriteBillToFile();

        [OperationContract]
        void CreateBill(List<string> list, int total);

        [OperationContract]
        int FindMinimumOrder();

        [OperationContract]
        void CreateNewItem(string name,int amount,int price);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        List<Item> CreateObjectList();

        [OperationContract]
        void WriteObjectListToFile(List<Item> list);

    }


    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
