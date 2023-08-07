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
    internal partial class MainPageViewModel:ObservableObject
    {
        [ObservableProperty]
        YesNoEnum? selectedYesNoEnum;
    }
}
