using SQLite;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using QuizEarth.Helpers;
using QuizEarth.ViewModels;

namespace QuizEarth.Data
{
    public class TodoItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public TodoItemDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(CountryQuestionsList).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(CountryQuestionsList)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<CountryQuestionsList>> GetItemsAsync()
        {
            return Database.Table<CountryQuestionsList>().ToListAsync();
        }

        public Task<List<CountryQuestionsList>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<CountryQuestionsList>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<CountryQuestionsList> GetItemAsync(int id)
        {
            return Database.Table<CountryQuestionsList>().Where(i => i.CountryId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(CountryQuestionsList item)
        {
            if (item.CountryId != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(CountryQuestionsList item)
        {
            return Database.DeleteAsync(item);
        }
    }
}