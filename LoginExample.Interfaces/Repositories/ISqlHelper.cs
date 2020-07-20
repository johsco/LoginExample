using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LoginExample.Interfaces.Repositories
{
    public interface ISqlHelper
    {
        Task<IDataReader> GetDataReaderAsync(SqlCommand cmd);
    }
}