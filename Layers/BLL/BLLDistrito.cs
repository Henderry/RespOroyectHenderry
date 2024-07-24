using appMarket.Interfaces;
using appMarket.Layers.DAL;
using appMarket.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMarket.Layers.BLL
{
    internal class BLLDistrito : IBLLDistrito
    {
        public List<Distrito> GetAll()
        {
            IDALDistrito dal = new DALDistrito();
            var lista = dal.GetAll();
            return lista.OrderBy(x => x.DescripccionDistrito).ToList();
        }

        public void Save(Distrito t)
        {
            if (t.DescripccionDistrito.Length < 3)
                throw new ApplicationException("La descripción debe tener al menos 3 letras");

            IDALDistrito dal = new DALDistrito();

            Distrito existe = dal.GetById(t.IdDistrito);
            if (existe == null)
                dal.Insert(t);
            else
                dal.Update(t);
        }

    }
}
