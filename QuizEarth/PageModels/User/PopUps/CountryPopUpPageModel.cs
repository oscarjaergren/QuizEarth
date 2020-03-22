using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers.Commands;
using QuizEarth.Views.User;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace QuizEarth.PageModels.User.PopUps
{
    public class CountryPopUpPageModel : BaseViewModel
    {
        private string _countryName;

        private readonly int _countryId;

        public CountryPopUpPageModel(int countryId, string countryName)
        {
            _countryId = countryId;
            _countryName = countryName;
        }

        private async Task OnGoToQuiz()
        {
            await PopupNavigation.Instance.PopAllAsync();
            Routing.RegisterRoute("quizPage", typeof(QuizPage));
            await Shell.Current.GoToAsync($"quizPage?_countryId={_countryId}");
        }

        public ICommand GoToQuizCommand => new AsyncCommand(OnGoToQuiz);

        public string CountryName
        {
            get => _countryName;
            set => SetProperty(ref _countryName, value);
        }
    }
}
