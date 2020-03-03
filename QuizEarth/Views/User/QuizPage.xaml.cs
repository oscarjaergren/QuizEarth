using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizEarth.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {
        private Animation _animation;

        public QuizPage()
        {
            InitializeComponent();
            Button_Clicked();
        }

        private void Button_Clicked()
        {
            var startValue = 0;
            var desiredValue = 0.6;

            if (_animation != null)
            {
                ProgressBar.AbortAnimation("Percentage");
            }

            _animation = new Animation(v =>
            {
                if (v == 0)
                {
                    ProgressBar.Percentage = 0;
                    return;
                }

                ProgressBar.Percentage = (float)(v / 100);
            }, startValue, desiredValue * 100, easing: Easing.SinInOut);

            _animation.Commit(ProgressBar, "Percentage", length: 2000,
                finished: (l, c) => { _animation = null; });
        }

    }
}