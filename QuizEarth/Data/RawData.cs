using System;
using System.Collections.Generic;
using System.Text;
using QuizEarth.Models;

namespace QuizEarth.Data
{
    public static class RawData
    {
        public static List<Question> GetSwedenQuestions()
        {
            var question1 = new Question
            {
                QuestionText = "What is the capital of Sweden",
                CountryId = 153,
                Answer1 = "Stockholm",
                Answer2 = "Ikea",
                Answer3 = "Gothenburg",
                Answer4 = "Lund",
                CorrectAnswer = "Stockholm",
            };

            var question2 = new Question
            {
                QuestionText = "Which awards take place every year in Stockholm?",
                CountryId = 153,
                Answer1 = "Oscars",
                Answer2 = "People’s Choice",
                Answer3 = "Nobel",
                Answer4 = "Ikea",
                CorrectAnswer = "Nobel",
            };

            var question3 = new Question
            {
                QuestionText = "Which of these music acts are Swedish",
                CountryId = 153,
                Answer1 = "David Bowie",
                Answer2 = "ABBA",
                Answer3 = "Fleetwood Mac",
                Answer4 = "Bon Jovi",
                CorrectAnswer = "ABBA",
            };

            var question4 = new Question
            {
                QuestionText = "What is the Swedish currency",
                CountryId = 153,
                Answer1 = "Krona",
                Answer2 = "Euro",
                Answer3 = "Pound",
                Answer4 = "Dollar",
                CorrectAnswer = "Krona",
            };

            var question5 = new Question
            {
                QuestionText = "What is the Swedish population?",
                CountryId = 153,
                Answer1 = "9.8 million",
                Answer2 = "9.6 million",
                Answer3 = "9.5 million",
                Answer4 = "9.2 million",
                CorrectAnswer = "9.5 million",
            };

            var question6 = new Question
            {
                QuestionText = "Where does Sweden import trash from",
                CountryId = 153,
                Answer1 = "France",
                Answer2 = "Germany",
                Answer3 = "Norway",
                Answer4 = "Australia",
                CorrectAnswer = "Norway",
            };

            var question7 = new Question
            {
                QuestionText = "What did a former king become when he lost his throne",
                CountryId = 153,
                Answer1 = "Bartender",
                Answer2 = "Pirate",
                Answer3 = "Prime Minister",
                Answer4 = "Doctor",
                CorrectAnswer = "Pirate",
            };

            var question8 = new Question
            {
                QuestionText = "What is Sweden considered?",
                CountryId = 153,
                Answer1 = "A first world country",
                Answer2 = "A second world country",
                Answer3 = "A third world country",
                Answer4 = "A fourth world country",
                CorrectAnswer = "A third world country",
            };

            var question9 = new Question
            {
                QuestionText = "Which of these were invented in Sweden?",
                CountryId = 153,
                Answer1 = "Nicorette",
                Answer2 = "TV",
                Answer3 = "Earphones",
                Answer4 = "Bagel",
                CorrectAnswer = "Nicorette",
            };

            var question10 = new Question
            {
                QuestionText = "Which world war did Sweden not take part in?",
                CountryId = 153,
                Answer1 = "WW1",
                Answer2 = "WW2",
                Answer3 = "Both",
                Answer4 = "None",
                CorrectAnswer = "None",
            };

            var question11 = new Question
            {
                QuestionText = "Which sea separates Sweden and Denmark",
                CountryId = 153,
                Answer1 = "Baltic",
                Answer2 = "Artic",
                Answer3 = "Indian",
                Answer4 = "Pacific",
                CorrectAnswer = "Baltic",
            };

            var question12 = new Question
            {
                QuestionText = "When did Sweden become a member of the EU?",
                CountryId = 153,
                Answer1 = "1996",
                Answer2 = "1995",
                Answer3 = "1994",
                Answer4 = "1993",
                CorrectAnswer = "1995",
            };

            var question13 = new Question
            {
                QuestionText = "When is national day in Sweden?",
                CountryId = 153,
                Answer1 = "4th of june",
                Answer2 = "5th of june",
                Answer3 = "6th of june",
                Answer4 = "7th of june",
                CorrectAnswer = "6th of june",
            };

            var question14 = new Question
            {
                QuestionText = "Sweden has the highest number of which fast food restaurants per capita in Europe?",
                CountryId = 153,
                Answer1 = "Burger King",
                Answer2 = "KFC",
                Answer3 = "Subway",
                Answer4 = "McDonalds",
                CorrectAnswer = "McDonalds",
            };

            var question15 = new Question
            {
                QuestionText = "Which of these is famously swedish",
                CountryId = 153,
                Answer1 = "Ikea",
                Answer2 = "Burger King",
                Answer3 = "Walmart",
                Answer4 = "Target",
                CorrectAnswer = "Ikea",
            };

            List<Question> swedishQuestions = new List<Question>
            {
                question1,
                question2,
                question3,
                question4,
                question5,
                question6,
                question7,
                question8,
                question9,
                question10,
                question11,
                question12,
                question13,
                question14,
                question14,
                question15
            };

            return swedishQuestions;
        }

        public static List<Question> GetScottishQuestions()
        {
            var question1 = new Question
            {
                QuestionText = "What is the capital of Scotland?",
                CountryId = 168,
                Answer1 = "Edinburgh",
                Answer2 = "Glasgow",
                Answer3 = "Dundee",
                Answer4 = "Aberdeen",
                CorrectAnswer = "Glasgow",
            };

            var question2 = new Question
            {
                QuestionText = "What is Scotland’s national animal",
                CountryId = 168,
                Answer1 = "Lion",
                Answer2 = "Unicorn",
                Answer3 = "Nessy",
                Answer4 = "Dog",
                CorrectAnswer = "Nessy",
            };

            var question3 = new Question
            {
                QuestionText = "How many flags does Scotland have?",
                CountryId = 168,
                Answer1 = "1",
                Answer2 = "2",
                Answer3 = "3",
                Answer4 = "0",
                CorrectAnswer = "2",
            };

            var question4 = new Question
            {
                QuestionText = "Which Scottish city is home to Robert Gordon University",
                CountryId = 168,
                Answer1 = "Edinburgh",
                Answer2 = "Glasgow",
                Answer3 = "Stirling",
                Answer4 = "Aberdeen",
                CorrectAnswer = "Aberdeen",
            };

            var question5 = new Question
            {
                QuestionText = "Which of these became an official language of Scotland in 2005 ? ",
                CountryId = 168,
                Answer1 = "English",
                Answer2 = "Gaelic",
                Answer3 = "Irish",
                Answer4 = "French",
                CorrectAnswer = "Gaelic",
            };

            var question6 = new Question
            {
                QuestionText = "What is the largest city in Scotland",
                CountryId = 168,
                Answer1 = "Dundee",
                Answer2 = "Aberdeen",
                Answer3 = "Glasgow",
                Answer4 = "Edinburgh",
                CorrectAnswer = "Glasgow",
            };

            var question7 = new Question
            {
                QuestionText = "What is the oldest university in Scotland",
                CountryId = 168,
                Answer1 = "University of Edinburgh",
                Answer2 = "University of Glasgow",
                Answer3 = "University of St Andrews",
                Answer4 = "Glasgow Caledonian University",
                CorrectAnswer = "University of St Andrews",
            };

            var question8 = new Question
            {
                QuestionText = "Who is not a famous Scot?",
                CountryId = 168,
                Answer1 = "Alexander Graham Bell",
                Answer2 = "William Wallace",
                Answer3 = "Queen Victoria",
                Answer4 = "Mary Queen of Scots",
                CorrectAnswer = "Queen Victoria",
            };

            var question9 = new Question
            {
                QuestionText = "Roughly, what is the population of Scotland?",
                CountryId = 168,
                Answer1 = "5 million",
                Answer2 = "5.5 million",
                Answer3 = "6 million",
                Answer4 = "6.5 million",
                CorrectAnswer = "6.5 million",
            };

            var question10 = new Question
            {
                QuestionText = "How many cities are there in Scotland",
                CountryId = 168,
                Answer1 = "4",
                Answer2 = "6",
                Answer3 = "3",
                Answer4 = "7",
                CorrectAnswer = "6",
            };

            var question11 = new Question
            {
                QuestionText = "What is the name of the pouch worn at the front of a kilt",
                CountryId = 168,
                Answer1 = "A pouch",
                Answer2 = "A manbag",
                Answer3 = "A sporran",
                Answer4 = "Kilt pocket",
                CorrectAnswer = "A sporran",
            };

            var question12 = new Question
            {
                QuestionText = "What is Scotland’s longest river",
                CountryId = 168,
                Answer1 = "The Tay",
                Answer2 = "The Clyde",
                Answer3 = "The Thames",
                Answer4 = "The river Yarrow",
                CorrectAnswer = "The Tay",
            };

            var question13 = new Question
            {
                QuestionText = "What is a famous Scottish instrument",
                CountryId = 168,
                Answer1 = "Bagpipes",
                Answer2 = "Guitar",
                Answer3 = "Drums",
                Answer4 = "Flute",
                CorrectAnswer = "Bagpipes",
            };

            var question14 = new Question
            {
                QuestionText = "Which loch contains more water than all the English and Welsh lakes put together?",
                CountryId = 168,
                Answer1 = "Tay",
                Answer2 = "Fine",
                Answer3 = "Lomond",
                Answer4 = "Ness",
                CorrectAnswer = "Lomond",
            };

            var question15 = new Question
            {
                QuestionText = "What is a traditional Scottish dish",
                CountryId = 168,
                Answer1 = "Haggis",
                Answer2 = "Curry",
                Answer3 = "Lamb",
                Answer4 = "Cheeseburger",
                CorrectAnswer = "Haggis",
            };

            List<Question> scottishQuestions = new List<Question>();
            scottishQuestions.Add(question1);
            scottishQuestions.Add(question2);
            scottishQuestions.Add(question3);
            scottishQuestions.Add(question4);
            scottishQuestions.Add(question5);
            scottishQuestions.Add(question6);
            scottishQuestions.Add(question7);
            scottishQuestions.Add(question8);
            scottishQuestions.Add(question9);
            scottishQuestions.Add(question10);
            scottishQuestions.Add(question11);
            scottishQuestions.Add(question12);
            scottishQuestions.Add(question13);
            scottishQuestions.Add(question14);
            scottishQuestions.Add(question14);
            scottishQuestions.Add(question15);

            return scottishQuestions;
        }
    }
}