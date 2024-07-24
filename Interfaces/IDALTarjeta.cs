using appMarket.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMarket.Interfaces
{
    internal interface IDALTarjeta
    {
        List<Tarjeta> GetAll();

        void Insert(Tarjeta t);

        void Delete(int idTarjeta);

        Tarjeta GetById(int id);

        void Update(Tarjeta t);


    }
}
