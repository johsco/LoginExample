using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using LoginExample.Interfaces.Repositories;

namespace LoginExample.Repositories
{
    [ExcludeFromCodeCoverage]
    public class SqlHelper: ISqlHelper
    {
        public async Task<IDataReader> GetDataReaderAsync(SqlCommand cmd)
        {
            //Make sure there is a connection
            if (cmd.Connection == null)
            {
                throw new ArgumentException("SqlConnection required");
            }

            await cmd.Connection.OpenAsync();

            var results = await cmd.ExecuteReaderAsync();

            return results;
        }
    }
}