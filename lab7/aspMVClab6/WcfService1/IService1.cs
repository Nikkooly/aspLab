using PhoneRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Contact> GetDist();

        [OperationContract]
        string AddDict(Contact contact);

        [OperationContract]
        string UpdDict(Contact contact);

        [OperationContract]
        string DelDict(Contact contact);
    }
}
