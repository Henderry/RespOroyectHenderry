using appMarket.Interfaces;
using appMarket.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMarket.Layers.BLL
{
    internal class BLLProvincia : IBLLProvincia
    {
        public List<Provincia> GetAll()
        {
            IDALProvincia dal = new DAL.DALProvincia();
            return dal.GetAll();
        }
    }
}
