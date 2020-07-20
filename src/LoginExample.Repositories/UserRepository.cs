using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using LoginExample.Interfaces;
using LoginExample.Interfaces.Repositories;
using LoginExample.Models;
using Microsoft.VisualBasic;

namespace LoginExample.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IAppSettings _appSettings;
        private readonly ISqlHelper _sqlHelper;

        public UserRepository(IAppSettings appSettings, ISqlHelper sqlHelper)
        {
            _appSettings = appSettings;
            _sqlHelper = sqlHelper;
        }
        public async Task<bool> LoginUserAsync(UserLoginRequest loginRequest)
        {
            await using var conn = new SqlConnection(_appSettings.LoginDb);
            await using var command = new SqlCommand("LoginUser", conn);
            
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("userName", loginRequest.UserName);
            command.Parameters.AddWithValue("password", loginRequest.Password);

            var results = await _sqlHelper.GetDataReaderAsync(command);

            //Here we would serialize data to DTO to use for UserContext. But just returning true for now.
            return results.Read();
        }
    }
}