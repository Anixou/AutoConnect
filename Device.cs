using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoConnect
{
    public class Device
    {
        public string Name;
        public string Address;
        public Device(string name, string adresse) { 
            
            Name = name;
            Address = adresse;
        }
    }
}
