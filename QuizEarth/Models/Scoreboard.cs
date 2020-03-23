using System;
using System.Collections.Generic;
using System.Text;

namespace QuizEarth.Models
{
    public class Scoreboard
    {
        public int UserId { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string UserName { get; set; }

        public int Score { get; set; }
    }
}
