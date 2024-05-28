using Calcucator.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace Calcucator.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel()
        {
            // Constructor logic if needed
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
            if (_hasError)
            {
                DisplayText = ""; // Reset display text if there was an error
                _hasError = false; // Reset error flag
            }

            DisplayText += value;
        }

        [RelayCommand]
        private async Task SolveAsync()
        {
            if (string.IsNullOrEmpty(DisplayText))
            {
                await DisplayAlert("Invalid input!", "Error", "OK");
                return;
            }

            try
            {
                MainPageModel model = new MainPageModel();
                double result = model.Solve(DisplayText);
                DisplayText = result.ToString();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error calculating result: " + ex.Message, "Error", "OK");
            }
        }

        [RelayCommand]
        public void Empty()
        {
            DisplayText = "";
            _hasError = false;
        }

        private async Task DisplayAlert(string message, string title, string button)
        {
            // Assuming you have a way to access the current Page, typically through a service or dependency injection
            await App.Current.MainPage.DisplayAlert(title, message, button);
            _hasError = true;
        }
    }
}
