using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaInTime.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        public INavigate Navigation { get; set; } = new Navigator();
    }
}
