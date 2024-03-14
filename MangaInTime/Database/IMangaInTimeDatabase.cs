using MangaInTime.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaInTime.Database
{
    public interface IMangaInTimeDatabase
    {
        Task<List<FavoriteManga>> GetFavoriteManga();
        Task<int> SaveFavoriteManga(FavoriteManga favoriteManga);
        Task<int> DeleteFavoriteManga(FavoriteManga favoriteManga);
    }
}
