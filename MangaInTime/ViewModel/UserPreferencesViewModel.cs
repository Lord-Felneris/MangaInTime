using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaInTime.ViewModel
{
    public partial class UserPreferencesViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NotSelect))]
        private bool select;
        public bool NotSelect => !Select;

        [ObservableProperty] private bool startupLast;
        [ObservableProperty] private string startupUrl;


        [RelayCommand]
        public async Task SavePreferences()
        {
            Preferences.Default.Set("ThemeSelection",Select);
            Preferences.Default.Set("StartupLast", StartupLast);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            if(StartupLast == false)
            {
                Preferences.Default.Remove("StartupUrl");
            }
            await Toast.Make("Restart to save your preference!", ToastDuration.Long, 5).Show(cancellationTokenSource.Token);
        }

        public void SetStartupStatus(string url)
        {
            if(StartupLast == true)
            {
                StartupUrl = url;
                Preferences.Default.Set("StartupUrl", StartupUrl);
            }
        }
        public UserPreferencesViewModel() 
        {
            Select = Preferences.Default.Get("ThemeSelection",true);
            StartupLast = Preferences.Default.Get("StartupLast",true);
            StartupUrl = Preferences.Default.Get("StartupUrl","https://www.google.fr");
        }

    }
}
