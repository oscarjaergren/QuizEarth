using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizEarth.Services
{
    public interface IDataStore<T>
    {
        SQLiteConnection GetDataBaseConnection();

        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}