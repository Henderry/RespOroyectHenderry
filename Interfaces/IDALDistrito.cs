using appMarket.Layers.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMarket.Interfaces
{
    internal interface IDALDistrito
    {
        List<Distrito> GetAll();
        void Insert(Distrito t);
        void Update(Distrito t);
        Distrito GetById(int idDistrito);
    }
}
