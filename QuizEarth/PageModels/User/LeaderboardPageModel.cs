using MvvmHelpers.Commands;
using QuizEarth.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QuizEarth.PageModels.User
{
    public class LeaderboardPageModel
    {
        public List<Scoreboard> ScoreboardList { get; set; }

        public ICommand ReturnToMapCommand { get; set; }


        public LeaderboardPageModel()
        {
            ReturnToMapCommand = new MvvmHelpers.Commands.Command(OnReturnToMap);


            //GetScores();
            //SortScoreboard();
        }

        private void OnReturnToMap()
        {
            MainThread.BeginInvokeOnMainThread(() => { Shell.Current.GoToAsync("//map"); });
        }

        // Sorts the scoreboard 
        private void SortScoreboard()
        {
            ScoreboardList.Sort(SortByScore);
        }

        // Compare the scores
        static int SortByScore(Scoreboard p1, Scoreboard p2)
        {
            return p1.Score.CompareTo(p2.Score);
        }

        private async Task GetScores()
        {
            ScoreboardList = await App.Database.GetScoreboard();
        }
    }
}