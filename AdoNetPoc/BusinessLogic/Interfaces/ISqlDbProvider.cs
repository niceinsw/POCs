using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISqlDbProvider
    {
        Task<SqlDataReader> ExcecuteReaderProcedure(string storedProcedure, SqlParameter[] parameters = null);
        Task<int> ExecuteNonQueryProcedure(string storedProcedure, SqlParameter[] parameters = null);
    }
}
