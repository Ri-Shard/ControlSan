using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class RestauranteRepository{
        
        private readonly SqlConnection _connection;
        private readonly List<Restaurante> _restaurante = new List<Restaurante>();
        public RestauranteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }


       public void Guardar(Restaurante restaurante)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Restaurantes (NombreRestaurante,Direccion,Evaluacion,Nit,Estado,Idueño) 
                                        values (@NombreRestaurante,@Direccion,@Evaluacion,@Nit,@Estado,@Idueño)";
                command.Parameters.AddWithValue("@NombreRestaurante", restaurante.NombreRestaurante);
                command.Parameters.AddWithValue("@Direccion", restaurante.Direccion);
                command.Parameters.AddWithValue("@Evaluacion", restaurante.Evaluacion);
                command.Parameters.AddWithValue("@Nit", restaurante.Nit);
                command.Parameters.AddWithValue("@Estado", restaurante.Estado);
                command.Parameters.AddWithValue("@Idueño", restaurante.Id);
                var filas = command.ExecuteNonQuery();
                
            }
        }
        public void Eliminar(Restaurante restaurante)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from restaurantes where Nit=@Nit";
                command.Parameters.AddWithValue("@Nit", restaurante.Nit);
                command.ExecuteNonQuery();
            }
        }
     public List<Restaurante> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Restaurante> restaurantes = new List<Restaurante>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Restaurantes";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Restaurante restaurante = DataReaderMapToRestaurante(dataReader);
                        restaurantes.Add(restaurante);
                    }
                }
            }
            return restaurantes;
        }

        public Restaurante BuscarPorNit(string Nit)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Restaurantes where Nit=@Nit";
                command.Parameters.AddWithValue("@Nit", Nit);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToRestaurante(dataReader);
            }
        }

        private Restaurante DataReaderMapToRestaurante(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Restaurante restaurante = new Restaurante();
            restaurante.NombreRestaurante = (string)dataReader["NombreRestaurante"];
            restaurante.Direccion = (string)dataReader["Direccion"];
            restaurante.Estado = (string)dataReader["Estado"];
            restaurante.Evaluacion = (string)dataReader["Evaluacion"];
            restaurante.Nit = (string)dataReader["Nit"];
            restaurante.Id = (string)dataReader["Idueño"];
            return restaurante;
            
         }


        
    }
}
