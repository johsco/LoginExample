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

        public UserRepository(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public async Task<bool> LoginUserAsync(UserLoginRequest loginRequest)
        {
            await using var conn = new SqlConnection(_appSettings.LoginDb);
            await using var command = new SqlCommand("LoginUser", conn);
            
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("userName", loginRequest.UserName);
            command.Parameters.AddWithValue("password", loginRequest.Password);

            await conn.OpenAsync();

            //If one exists, user and password are correct and return
            var results = await command.ExecuteReaderAsync();

            //Here we would serialize data to DTO to use for UserContext. But just returning true for now.
            return results.HasRows;
            
        }
    }
}