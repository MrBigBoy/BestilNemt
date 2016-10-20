using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBestilNemtService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Person findPerson(int id);

        [OperationContract]
        void createPerson(Person person);
        [OperationContract]
        List<Person> GetALlPerson();


        // TODO: Add your service operations here
        [OperationContract]
        Warehouse GetWarehouse(int id);

        [OperationContract]
        List<Warehouse> GetAllWarehouses();

        [OperationContract]
        void RemoveWarehouse(int id);

        [OperationContract]
        void AddWarehouse(Warehouse warehouse);

        [OperationContract]
        void UpdateWarehouse(Warehouse warehouse);
    }
}
