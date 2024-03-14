using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using MangaInTime.Database;
using MangaInTime.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MangaInTime.ViewModel
{
    public partial class SearchMangaViewModel : BaseViewModel
    {
        [ObservableProperty] private string baseUrl = "https://www.google.fr";
        private readonly MangaInTimeDatabase database;
        private readonly UserPreferencesViewModel userPreferences;
        public ICommand AddNewMangaAsFavorite { get; }

        void OnTapped(object s)
        {
            AddMangaDialog();
        }

        private async void AddMangaDialog()
        {
            string result = await Application.Current.MainPage.DisplayPromptAsync("Add a new favorite Manga", "what's manga's name?");
            if (result != null)
            {
                FavoriteManga favoriteManga = new FavoriteManga{ 
                    Title = result,
                    MangaImg = "https://e7.pngegg.com/pngimages/343/773/png-clipart-question-mark-question-mark.png",
                    UrlToManga = BaseUrl,
                    DateOfAdd = DateTime.Now 
                };
                await database.SaveFavoriteManga(favoriteManga);
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                await Toast.Make($"{result} save as favorite manga!", ToastDuration.Long, 5).Show(cancellationTokenSource.Token);
            }

        }
        public void RemindLastPage()
        {
            userPreferences.SetStartupStatus(BaseUrl);
        }

        public void SetRemindUrl()
        {
            if(userPreferences.StartupUrl != BaseUrl)
            {
                BaseUrl = userPreferences.StartupUrl;
            }
        }
        public SearchMangaViewModel()
        {
            database = new(); // init a database
            userPreferences = new UserPreferencesViewModel();
            SetRemindUrl();
            AddNewMangaAsFavorite = new Command(OnTapped);
        }
    }
}
