using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QuizEarth.Models;
using QuizEarth.PageModels.User;
using Xamarin.Forms;

namespace QuizEarth.Converters
{
    public class IndexValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is Binding binding &&
                value is Scoreboard score &&
                binding.Source is CollectionView collectionView &&
                collectionView.BindingContext is LeaderboardPageModel viewModel)
            {
                return viewModel.ScoreboardList.IndexOf(score) + 1;
            }

            return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
