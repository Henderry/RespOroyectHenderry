using appMarket.Layers.DAL;
using appMarket.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMarket.Interfaces
{
    internal interface IBLLTarjeta
    {
        List<Tarjeta> GetAll();

        void Insertr(Tarjeta t);

        void Save(Tarjeta t);

        void Delete(int id);
    }
}
