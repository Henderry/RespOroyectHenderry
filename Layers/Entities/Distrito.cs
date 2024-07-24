using appMarket.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMarket.Layers.DAL
{
    internal class Distrito
    {
        public int IdDistrito { get; set; }
        public Provincia Provincia { get; set; }
        public String DescripccionDistrito { get; set; }
    }
}
