using SQLite;
using Corsework.Model;

namespace Corsework.Services
{
    public class dbUserService
    {
        private const string DB_NAME = "Finance_app_db.db1";
        private readonly SQLiteAsyncConnection _connection;

        public dbUserService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory,DB_NAME));
            _connection.CreateTableAsync<UserModel>();
        }

        public async Task CreateUser(UserModel user)
        {
            try
            {
                await _connection.InsertAsync(user);
                Console.WriteLine("User Added Successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<UserModel> GetUserByEmailAndPassword(string email, string password)
        {
                // Query the UserModel table to find a user with the specified email and password
                return await _connection.Table<UserModel>()
                                         .Where(x => x.UserEmail == email && x.Password == password)
                                         .FirstOrDefaultAsync();
        }
    }
}
