using appMarket.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using appMarket.Interfaces;

namespace appMarket.Layers.DAL
{
    internal class DALDistrito : IDALDistrito
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

        public void Insert(Distrito t)
        {
            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                string sql = @"Insert into Distrito(IdDistrito,IdProvincia,DescripcionDistrito) values (@IdDistrito,@IdProvincia,@DescripcionDistrito)";
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@IdDistrito", t.IdDistrito);
                command.Parameters.AddWithValue("@IdProvincia", t.Provincia.IdProvincia);
                command.Parameters.AddWithValue("@DescripcionDistrito", t.DescripccionDistrito);
                command.CommandType = CommandType.Text;
                command.CommandText = sql;

                db.ExecuteNonQuery(command);
            }
        }
        public void Update(Distrito t)
        {
            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                string sql = @"Update Distrito  SET IdDistrito = IdDistrito, IdProvincia = @IdProvincia,
                DescripcionDistrito = @DescripcionDistrito
                Where IdDistrito = @IdDistrito";
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@IdDistrito", t.IdDistrito);
                command.Parameters.AddWithValue("@DescripcionDistrito", t.DescripccionDistrito);
                command.CommandType = CommandType.Text;
                command.CommandText = sql;

                db.ExecuteNonQuery(command);
            }
        }

        public Distrito GetById(int idDistrito)
        {
            string conn = FactoryConexion.CreateConnection();
            using (IDataBase db = FactoryDatabase.CreateDataBase(conn))
            {
                string sql = @"select * from Distrito With (NoLock) where IdDistrito = " + idDistrito;
                var command = new SqlCommand(sql);
                var reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    Distrito d = new Distrito();
                    d.IdDistrito = Convert.ToInt32(reader["IdDistrito"]);
                    d.DescripccionDistrito = reader["Descripcion"].ToString();
                    int idProvincia = Convert.ToInt32(reader["IdProvincia"]);
                    //ser eficicente con GetByID
                    d.Provincia = new DALProvincia().GetAll().FirstOrDefault(x => x.IdProvincia == idProvincia);

                    return d;
                }
            }
            return null;
        }

    }
}

