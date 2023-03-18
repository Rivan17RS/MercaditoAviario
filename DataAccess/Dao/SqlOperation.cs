using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> parameters;

        public SqlOperation()
        {
            parameters = new List<SqlParameter>();
        }

        public void AddVarcharParam(string paramName, string paramValue)
        {
            parameters.Add(new SqlParameter("@" + paramName, paramValue));
        }

        public void AddIntegerParam(string paramName, int paramValue)
        {
            parameters.Add(new SqlParameter("@" + paramName, paramValue));
        }

        public void AddDoubleParam(string paramName, double paramValue) 
        {
            parameters.Add(new SqlParameter("@" + paramName, paramValue));
        }

    }
}
