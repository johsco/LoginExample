using System.Data;

namespace LoginExample.Interfaces.Repositories
{
    public interface IUnitOfWorkd
    {
        IDbCommand GetSqlCommand(string sqlSproc);
    }
}