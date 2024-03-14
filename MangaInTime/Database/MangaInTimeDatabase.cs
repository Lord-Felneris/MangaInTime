using MangaInTime.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaInTime.Database
{
    public class MangaInTimeDatabase : IMangaInTimeDatabase
    {
        SQLiteAsyncConnection Database;
        async Task Init()
        {
            if (Database is not null)
                return;
            Database = new SQLiteAsyncConnection(Constant.DatabasePath, Constant.Flags);
            await Database.CreateTableAsync<FavoriteManga>();
        }

        public async Task<FavoriteManga> GetFavoriteMangaByTitle(string title)
        {
            await Init();
            return await Database.Table<FavoriteManga>().Where(i => i.Title == title).FirstOrDefaultAsync();
        }

        public async Task<int> SaveFavoriteManga(FavoriteManga favoriteManga)
        {
            await Init();
            if(favoriteManga.Id != 0)
            {
                return await Database.UpdateAsync(favoriteManga);
            }
            else
            {
                return await Database.InsertAsync(favoriteManga);
            }

        }

        public async Task<int> DeleteFavoriteManga(FavoriteManga favoriteManga)
        {
            await Init();
            return await Database.DeleteAsync(favoriteManga);
        }

        public async Task<List<FavoriteManga>> GetFavoriteManga()
        {
            await Init();
            return await Database.Table<FavoriteManga>().ToListAsync();
        }
    }
}
