using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizEarth.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionControl : ContentPage
    {
        public QuestionControl()
        {
            InitializeComponent();
        }
    }
}