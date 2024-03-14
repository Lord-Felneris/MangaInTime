using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaInTime.Model
{
    public partial class FavoriteManga : ObservableObject
    {
        [ObservableProperty]
        [property: PrimaryKey]
        [property: AutoIncrement] private int id;
        [ObservableProperty] private string? title;
        [ObservableProperty] private string? mangaImg;
        [ObservableProperty] private string? urlToManga;
        [ObservableProperty] private DateTime? dateOfAdd;
    }

    public partial class FavoriteMangaResult : ObservableObject
    {
        [ObservableProperty] private List<FavoriteMangaResult>? mangaResult;
    }
}
