using appMarket.Interfaces;
using appMarket.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMarket.Layers.DAL
{
    internal class DALTarjeta : IDALTarjeta
    {
        public List<Tarjeta> GetAll()
        {
            List<Tarjeta> lista = new List<Tarjeta>();

            string conn = FactoryConexion.CreateConnection();
            using (IDataBase db = FactoryDatabase.CreateDataBase(conn))
            {
                string sql = @"select * from Tarjeta With (NoLock)";
                var command = new SqlCommand(sql);
                var reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    Tarjeta t = new Tarjeta();
                    t.IdTarjeta = Convert.ToInt32(reader["IdTarjeta"]);
                    t.DescripcionTarjeta = reader["DescripcionTarjeta"].ToString();

                    lista.Add(t);
                }
            }

            return lista;
        }

        public Tarjeta GetById(int id)
        {           
            string conn = FactoryConexion.CreateConnection();
            using (IDataBase db = FactoryDatabase.CreateDataBase(conn))
            {
                string sql = @"select * from Tarjeta With (NoLock) where IdTarjeta = @Id";
                var command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@Id", id);
                var reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    Tarjeta t = new Tarjeta();
                    t.IdTarjeta = Convert.ToInt32(reader["IdTarjeta"]);
                    t.DescripcionTarjeta = reader["DescripcionTarjeta"].ToString();

                    return t;
                }                
            }
            return null;
        }

        public void Insert(Tarjeta t)
        {
            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                string sql = @"Insert into Tarjeta(IdTarjeta,DescripcionTarjeta) values (@IdTarjeta,@DescripcionTarjeta)";
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@IdTarjeta", t.IdTarjeta);
                command.Parameters.AddWithValue("@DescripcionTarjeta", t.DescripcionTarjeta);
                command.CommandType = CommandType.Text;
                command.CommandText = sql;

                db.ExecuteNonQuery(command);
            }
        }

        public void Update(Tarjeta t)
        {
            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                string sql = @"Update Tarjeta SET DescripcionTarjeta = @DescripcionTarjeta Where IdTarjeta = @IdTarjeta";
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@IdTarjeta", t.IdTarjeta);
                command.Parameters.AddWithValue("@DescripcionTarjeta", t.DescripcionTarjeta);
                command.CommandType = CommandType.Text;
                command.CommandText = sql;

                db.ExecuteNonQuery(command);
            }
        }

        public void Delete(int idTarjeta)
        {
            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                string sql = @"Delete from Tarjeta where IdTarjeta = @IdTarjeta";
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@IdTarjeta", idTarjeta);
                command.CommandType = CommandType.Text;
                command.CommandText = sql;

                db.ExecuteNonQuery(command);
            }

        }
    }
}
