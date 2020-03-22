using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers.Commands;
using QuizEarth.Views.User;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace QuizEarth.PageModels.User.PopUps
{
    public class VictoryPopUpPageModel : BaseViewModel
    {
        private string _countryName;

        private readonly int _countryId;

        private readonly int _userId;


        public VictoryPopUpPageModel(int userId, int countryId, int score)
        {
            _countryId = countryId;
            _userId = userId;
            Score = score;
        }

        public ICommand GoToLeaderboardCommand => new AsyncCommand(OnGoToLeaderboard);
        public ICommand GoToMapCommand => new AsyncCommand(OnGoToMap);

        public int Score { get; set; }


        private async Task OnGoToLeaderboard()
        {
            await PopupNavigation.Instance.PopAllAsync();
            await Shell.Current.Navigation.PopAsync();
            await Shell.Current.GoToAsync("//leaderboard");
        }

        private async Task OnGoToMap()
        {
            await PopupNavigation.Instance.PopAllAsync();
            await Shell.Current.Navigation.PopAsync();
        }

        public string CountryName
        {
            get => _countryName;
            set => SetProperty(ref _countryName, value);
        }
    }
}