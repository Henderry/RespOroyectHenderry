using appMarket.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using appMarket.Interfaces;

namespace appMarket.Layers.DAL
{
    internal class DALProvincia : IDALProvincia
    {
        public List<Provincia> GetAll()
        {
            List<Provincia> lista = new List<Provincia>();

            string conn = FactoryConexion.CreateConnection();
            using (IDataBase db = FactoryDatabase.CreateDataBase(conn))
            {
                string sql = @"usp_SelectAllProvincias";
                var command = new SqlCommand(sql);
                //Nota: esto es obligatorio al usar store procedure
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var dataSet = db.ExecuteReader(command, "Provincia");
                // Con DataSet usamos un entorno desconectado
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Provincia p = new Provincia();
                    p.IdProvincia = Convert.ToInt32(row["IdProvincia"]);
                    p.Descripcion = row["Descripcion"].ToString();

                    lista.Add(p);
                }                
            }
            return lista;
        }
    }
}
