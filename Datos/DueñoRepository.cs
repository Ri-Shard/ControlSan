using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class DueñoRepository{
        
        private readonly SqlConnection _connection;
        private readonly List<Dueño> _dueño = new List<Dueño>();
        public DueñoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }


       public void Guardar(Dueño dueño)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Dueños (Nombre,Apellido,ID)
                                        values (@Nombre,@Apellido,@ID)";
                command.Parameters.AddWithValue("@Nombre", dueño.Nombre);
                command.Parameters.AddWithValue("@Apellido", dueño.Apellido);
                command.Parameters.AddWithValue("@ID", dueño.ID);

                var filas = command.ExecuteNonQuery();
                
            }
        }
        public void Eliminar(Dueño dueño)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Dueños where ID=@ID";
                command.Parameters.AddWithValue("@ID",dueño.ID);
                command.ExecuteNonQuery();
            }
        }
     public List<Dueño> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Dueño> dueños = new List<Dueño>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Dueños";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Dueño dueño = DataReaderMapToDueño(dataReader);
                        dueños.Add(dueño);
                    }
                }
            }
            return dueños;
        }

        public Dueño BuscarPorID(string ID)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Dueños where ID=@ID";
                command.Parameters.AddWithValue("@ID", ID);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToDueño(dataReader);
            }
        }

        private Dueño DataReaderMapToDueño(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Dueño dueño = new Dueño();
            dueño.Nombre = (string)dataReader["Nombre"];
            dueño.Apellido = (string)dataReader["Apellido"];
            dueño.ID = (string)dataReader["ID"];

            return dueño;
            
         }


        
    }
}
