using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using WcfService1;

namespace WcfHostConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(WcfService1.Service1));
            serviceHost.Open();
        }
    }
}
