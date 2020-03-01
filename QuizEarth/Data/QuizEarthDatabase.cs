using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizEarth.Helpers;
using QuizEarth.Models;
using SQLite;

namespace QuizEarth.Data
{
    public class QuizEarthDatabase
    {
        private static readonly Lazy<SQLiteAsyncConnection> LazyInitializer = new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags));

        private static bool _initialized;

        public QuizEarthDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        private static SQLiteAsyncConnection Database => LazyInitializer.Value;

        private async Task InitializeAsync()
        {
            if (!_initialized)
                if (Database.TableMappings.All(m => m.MappedType.Name != typeof(Question).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Question)).ConfigureAwait(false);
                    _initialized = true;
                }
        }

        public Task<List<Question>> GetItemsAsync()
        {
            return Database.Table<Question>().ToListAsync();
        }

        public Task<List<Question>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Question>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Question> GetItemAsync(int id)
        {
            return Database.Table<Question>().Where(i => i.CountryId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Question item)
        {
            if (item.CountryId != 0)
                return Database.UpdateAsync(item);
            return Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(Question item)
        {
            return Database.DeleteAsync(item);
        }
    }
}