using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizEarth.PageModels.User.PopUps;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizEarth.Views.User.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VictoryPopUpPage : PopupPage
    {
        public VictoryPopUpPage(int userId, int countryId, int score)
        {
            BindingContext = new VictoryPopUpPageModel(userId, countryId, score);

            InitializeComponent();
        }
    }
}