using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Labb3_NET22.DataModels;

namespace Labb3_NET22
{
    public class PlayQuizViewModel : INotifyPropertyChanged
    {
        public Quiz Quiz { get; set; }
        public Question CurrentQuestion { get; set; }
        public int SelectedAnswerIndex { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalAnswerd { get; set; }

        public bool isFinished = false;

        public List<Question> QuestionAnswerd = new List<Question>();

        public string ScoreText
        {
            get
            {
                int percent = 0;
                if (TotalAnswerd > 0)
                {
                    percent = (int)((double)CorrectAnswers / TotalAnswerd * 100);
                }
                return $"Rätt: {CorrectAnswers} / {TotalAnswerd} ({percent}%)";
            }
        }

        public PlayQuizViewModel(Quiz quiz)
        {
            Quiz = quiz;
            CorrectAnswers = 0;
            TotalAnswerd = 0;
            CurrentQuestion = Quiz.GetRandomQuestion();
            OnPropertyChange(nameof(CurrentQuestion));
            OnPropertyChange(nameof(ScoreText));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChange([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void NextQuestion(int selectedIndex)
        {
            TotalAnswerd++;
            if (CurrentQuestion.isCorrect(selectedIndex))
            {
                CorrectAnswers++;
            }

            QuestionAnswerd.Add(CurrentQuestion);
                                                      
            bool isUsed = true;

            while (isUsed)
            {
                CurrentQuestion = Quiz.GetRandomQuestion();

                var nextQuest = QuestionAnswerd.Any(q => q.Statement == CurrentQuestion.Statement);

                if (QuestionAnswerd.Count == Quiz.Questions.Count)
                {
                    isFinished = true;
                    isUsed = false;
                    break;
                }

                    if (nextQuest == true)
                {
                    CurrentQuestion = Quiz.GetRandomQuestion();

                }
                else
                {
                    isUsed = false;
                    break;
                }

            }



            OnPropertyChange("CurrentQuestion");
            OnPropertyChange("ScoreText");

        }



    }
}
