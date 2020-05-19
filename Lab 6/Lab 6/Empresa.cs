using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    class Empresa
    {
        private string name;
        private string rut;
        public Empresa(string name,string rut)
        { this.name = name;
            this.rut = rut;
        }
    }
}
