using Corsework.Model;
using SQLite;
using System.Linq.Expressions;


namespace Corsework.Services
{
    internal class dbDebtService
    {

        private const string DB_NAME = "Finance_App_db.db2";
        private readonly SQLiteAsyncConnection _connection;

        public dbDebtService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<DebtModel>();
        }

        public async Task<List<DebtModel>> GetDebts()
        {
            return await _connection.Table<DebtModel>().ToListAsync();
        }


        

        public async Task<DebtModel> GetById(Guid id)
        {
            return await _connection.Table<DebtModel>().Where(x => x.DebtId == id).FirstOrDefaultAsync();
        }

        public async Task Create(DebtModel debt)
        {
            try
            {
                await _connection.InsertAsync(debt);
                Console.WriteLine("Debt added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving transaction: {ex.Message}");
                throw;
            }

        }

        public async Task<bool> ClearDebt(Guid id)
        {
            try
            {
                var debt = await _connection.Table<DebtModel>().Where(x => x.DebtId == id).FirstOrDefaultAsync();

                if (debt != null)
                {
                    debt.IsCleared = true;
                    debt.ClearedDate = DateTime.Now;
                    int rowsAffected = await _connection.UpdateAsync(debt);
                    Console.WriteLine($"Rows affected : {rowsAffected}");
                    return rowsAffected > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing debt: {ex.Message}");
                return false;
            }
        }
    }
}
