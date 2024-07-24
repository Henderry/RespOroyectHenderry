using appMarket.Layers.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMarket.Interfaces
{
    internal interface IBLLDistrito
    {
        List<Distrito> GetAll();
        void Save(Distrito t);
    }
}
