using SQLite;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using QuizEarth.Helpers;
using QuizEarth.Models;

namespace QuizEarth.Data
{
    public class QuizEarthDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public QuizEarthDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Question).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Question)).ConfigureAwait(false);
                    initialized = true;
                }
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
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Question item)
        {
            return Database.DeleteAsync(item);
        }
    }
}