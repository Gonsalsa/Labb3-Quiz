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
        public QuizManager Quiz { get; set; }
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
            //Quiz = quiz;
            //CorrectAnswers = 0;
            //TotalAnswerd = 0;

            Quiz = new QuizManager("TestQuiz");
            //Quiz.AddQuestion("Vad heter Svergies huvudstad?", 0, "Stockholm", "Göteborg", "Malmö");
            //Quiz.AddQuestion("Vilken färg har himmelen?", 2, "Röd", "Grön", "Blå");
            //Quiz.AddQuestion("Hur många ben har en katt?", 1, "5", "4", "75");

            Quiz.Questions = quiz.Questions;


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

        public bool NextQuestion(int selectedIndex)
        {
            TotalAnswerd++;
            bool isRIght = CurrentQuestion.isCorrect(selectedIndex);
            if (isRIght)
            {
                CorrectAnswers++;
            }
            CurrentQuestion = Quiz.GetRandomQuestion();
            if (CurrentQuestion == null)
            {
                isFinished = true;
            }

            OnPropertyChange(nameof(CurrentQuestion));
            OnPropertyChange(nameof(ScoreText));

            return isRIght;

        }



    }
}
