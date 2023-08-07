using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Custom_RadioGroup_For_Enumeration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_RadioGroup_For_Enumeration.ViewModels
{
    public partial class MainPageViewModel:ObservableObject
    {
        [ObservableProperty]
        SmokerStateEnum? selectedSmokerStateEnum;
        [RelayCommand]
        public void ShowSelectedValue()
        {
            Shell.Current.DisplayAlert("Selected Value", this.SelectedSmokerStateEnum?.ToString()??"null", "OK");
        }
    }
}
