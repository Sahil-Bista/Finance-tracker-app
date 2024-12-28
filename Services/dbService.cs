using SQLite;
using Corsework.Model;


namespace Corsework.Services
{
	public class dbService
	{
		private const string DB_NAME = "Finance_App_db.db3";
		private readonly SQLiteAsyncConnection _connection;

		public dbService()
		{
			_connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory,DB_NAME));
			_connection.CreateTableAsync<TransactionModel>();
		}

		public async Task<List<TransactionModel>> GetTransactions()
		{
			return await _connection.Table<TransactionModel>().ToListAsync();
		}


		public async Task<TransactionModel> GetById(Guid id)
		{
			return await _connection.Table<TransactionModel>().Where(x=>x.TransactionId == id).FirstOrDefaultAsync();
		}

		public async Task Create(TransactionModel transaction)
		{
            try
            {
                await _connection.InsertAsync(transaction);
                Console.WriteLine("Transaction saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving transaction: {ex.Message}");
                throw;
            }

        }

        public async Task Update(TransactionModel transaction)
		{
			await _connection.UpdateAsync(transaction);
		}


        public async Task<bool> DeleteById(Guid id)
        {
            var transaction = await _connection.Table<TransactionModel>().Where(x => x.TransactionId == id).FirstOrDefaultAsync();

            if (transaction != null)
            {
                await _connection.DeleteAsync(transaction);
                return true;
            }

            return false; 
        }

    }
}
