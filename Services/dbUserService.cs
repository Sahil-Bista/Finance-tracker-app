using SQLite;
using Corsework.Model;

namespace Corsework.Services
{
    public class dbUserService
    {
        private const string DB_NAME = "users.db";
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

        public async Task<UserModel> GetUser()
        {
            try
            {
                // Retrieve the first user from the UserModel table
                var user = await _connection.Table<UserModel>().FirstOrDefaultAsync();
                if (user == null)
                {
                    Console.WriteLine("No user found in the database.");
                }
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user: {ex.Message}");
                return null;
            }
        }

        public async Task<int> GetUserCount()
		{
			try
			{
				// Execute a COUNT query on the UserModel table
				var userCount = await _connection.Table<UserModel>().CountAsync();
				return userCount;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error counting users: {ex.Message}");
				return 0;  // Return 0 if an error occurs
			}
		}
    }
}
