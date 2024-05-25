
using Calcucator.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calcucator.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        
        public MainPageViewModel()
        {
            
        }
        [ObservableProperty]
        public string buttonPlusText = "+";

        [ObservableProperty]
        public string buttonMinusText = "-";

        [ObservableProperty]
        public string buttonDivideText = "/";

        [ObservableProperty]
        public string buttonMultiplyText = "*";

        [ObservableProperty]
        public int button1Text = 1;

        [ObservableProperty]
        public int button2Text = 2;

        [ObservableProperty]
        public int button3Text = 3;

        [ObservableProperty]
        public int button4Text = 4;

        [ObservableProperty]
        public int button5Text = 5;

        [ObservableProperty]
        public int button6Text = 6;

        [ObservableProperty]
        public int button7Text = 7;

        [ObservableProperty]
        public int button8Text = 8;

        [ObservableProperty]
        public int button9Text = 9;

        [ObservableProperty]
        public string displayText = "";

        private bool _hasError;

        [RelayCommand]
        private void ButtonClicked(string value)
        {
            if (!_hasError)
            {
                DisplayText += value;
            }
            else
            {
                DisplayText = ""; // Reset display text only if there was an error
                _hasError = false; // Reset error flag
            }
        }


        [RelayCommand]
        private void Solve()
        {
            if (string.IsNullOrEmpty(DisplayText))
            {
                DisplayText = "Invalid input!";
                _hasError = true;
            }
            else 
            { 
                MainPageModel model = new MainPageModel();            
                double result = model.Solve(DisplayText);
                DisplayText = result.ToString();
                
            }

        }

        [RelayCommand]
        public void Empty()
        {
            DisplayText = 0.0.ToString();
        }

    }
}
