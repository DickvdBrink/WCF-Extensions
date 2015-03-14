using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceClientTest.Service1;

namespace WcfServiceClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client c = new Service1Client();
            c.GetData(1);
        }
    }
}
