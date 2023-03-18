using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Dao
{
    public class SqlDao
    {

        private string ConnectionString = string.Empty;

        private static SqlDao instance = new SqlDao();

        public SqlDao()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Mercadito-DB"].ConnectionString;
        }

        public static SqlDao GetInstance()
        {

            if (instance == null)
                instance = new SqlDao();
            return instance;

        }

        public void ExcecuteStoredProcedure(SqlOperation operation)
        {
            var connection = new SqlConnection(ConnectionString);
            var command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = operation.ProcedureName;

            foreach (var p in operation.parameters)
            {
                command.Parameters.Add(p);
            }

            connection.Open();
            command.ExecuteNonQuery();

        }

        public List<Dictionary<string, object>> ExecuteStoredProcedureWithquery(SqlOperation operation) 
        {
            List<Dictionary<string, object>> lstresults = new List<Dictionary<string, object>>();
            var connection = new SqlConnection(ConnectionString);
            var command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = operation.ProcedureName;

            foreach (var p in operation.parameters)
            {
                command.Parameters.Add(p);
            }

            connection.Open();
            // Ejecuta el SP en la base de datos, pero nos devuelve datos
            //que tenemos que procesar para mostrar en pantalla luego
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read()) 
                {
                    var dicc = new Dictionary<string, object>();
                    //Se corre el dataSet y se obtiene un diccionario por cada linea
                    //de los resultados de datos
                    for(var fieldCounter = 0; fieldCounter < reader.FieldCount; fieldCounter++) 
                    {
                        dicc.Add(reader.GetName(fieldCounter), reader.GetValue(fieldCounter));
                    }
                    //Se agregan a la lista de datos
                    lstresults.Add(dicc);
                }
            }

            return lstresults;
        }

    }
}
