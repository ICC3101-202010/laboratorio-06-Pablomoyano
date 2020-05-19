using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    class Persona
    {
        private string name;
        private string lastname;
        private string rut;
        private string cargo;
        public Persona(string name,string lastname,string rut,string cargo)
        { this.name = name;
            this.lastname = lastname;
            this.rut = rut;
            this.cargo = cargo;
        }
    }
}
