using MvvmHelpers.Commands;
using QuizEarth.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using QuizEarth.Data;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QuizEarth.PageModels.User
{
    public class LeaderboardPageModel
    {
        public List<Scoreboard> RawScoreboard { get; set; }

        public ObservableCollection<Scoreboard> ScoreboardList { get; set; }


        public ICommand ReturnToMapCommand { get; set; }


        public LeaderboardPageModel()
        {
            ReturnToMapCommand = new MvvmHelpers.Commands.Command(OnReturnToMap);
            ScoreboardList = new ObservableCollection<Scoreboard>();
        }

        private void OnReturnToMap()
        {
            MainThread.BeginInvokeOnMainThread(() => { Shell.Current.GoToAsync("//map"); });
        }

        // Sorts the scoreboard 
        private void SortScoreboard()
        {
            RawScoreboard?.Sort(SortByScore);
        }

        // Compare the scores
        static int SortByScore(Scoreboard p1, Scoreboard p2)
        {
            return p2.Score.CompareTo(p1.Score);
        }

        private async Task GetScores()
        {
            RawScoreboard = await App.Database.GetScoreboard();
        }

        public async Task OnAppearing()
        {
            await GetScores();
            SortScoreboard();

            foreach (var scoreboard in RawScoreboard)
            {
                ScoreboardList.Add(scoreboard);
            }
        }
    }
}