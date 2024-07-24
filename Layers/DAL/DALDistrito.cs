using appMarket.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMarket.Layers.DAL
{
    internal class DALDistrito
    {
        public List<Distrito> GetAll()
        {
            List<Distrito> lista = new List<Distrito>();

            string conn = FactoryConexion.CreateConnection();
            using (IDataBase db = FactoryDatabase.CreateDataBase(conn))
            {
                string sql = @"select * from Distrito With (NoLock)";
                var command = new SqlCommand(sql);
                //Nota: esto es obligatorio al usar store procedure
                var reader = db.ExecuteReader(command);
                // Con DataSet usamos un entorno desconectado
                while (reader.Read())
                {
                    Distrito d = new Distrito();
                    d.IdDistrito = Convert.ToInt32(reader["IdDistrito"]);
                    d.DescripccionDistrito = reader["Descripcion"].ToString();
                    int idProvincia = Convert.ToInt32(reader["IdProvincia"]);
                    //ser eficicente con GetByID
                    d.Provincia = new DALProvincia().GetAll().FirstOrDefault(x => x.IdProvincia == idProvincia);
                    lista.Add(d);
                }
            }
            return lista;
        }
    }
}
}
