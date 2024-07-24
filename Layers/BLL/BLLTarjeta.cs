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
    internal class BLLTarjeta : IBLLTarjeta
    {
        public List<Tarjeta> GetAll()
        {
            IDALTarjeta dal = new DALTarjeta();
            var lista = dal.GetAll();
            return lista.OrderBy(x => x.DescripcionTarjeta).ToList();
        }

        public void Insertr(Tarjeta t)
        {
            if (t.DescripcionTarjeta.Length < 3)
                throw new ApplicationException("La descripción debe tener al menos 3 letras");

            IDALTarjeta dal = new DALTarjeta();
            dal.Insert(t);
        }

        public void Save(Tarjeta t)
        {
            if (t.DescripcionTarjeta.Length < 3)
                throw new ApplicationException("La descripción debe tener al menos 3 letras");

            IDALTarjeta dal = new DALTarjeta();

            Tarjeta existe = dal.GetById(t.IdTarjeta);
            if (existe == null)
                dal.Insert(t);
            else
                dal.Update(t);
        }
        public void Delete(int id)
        {
            IDALTarjeta dal = new DALTarjeta();
            Tarjeta existe = dal.GetById(id);
            if(existe == null)
                throw new ApplicationException($"La tarjeta con código {id} no existe!");

            dal.Delete(id);

        }
    }
}
