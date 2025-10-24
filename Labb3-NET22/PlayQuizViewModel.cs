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

        public PlayQuizViewModel()
        {
            Quiz = new Quiz("TestQuiz");
            Quiz.AddQuestion("Vad heter Kejsaren i början av filmen Gladiator?", 2, "Maximus Decimus Veridius", "Comodius", "Marcus Aurelius", "Caesar");
            Quiz.AddQuestion("Vem var ringaren i Notre Dame?", 0, "Quasimodo", "Nostradamus", "Quizer", "Quijote");
            Quiz.AddQuestion("Vilken bok ingår inte i orginal Millenium Triologin?", 1, "Män som hatar Kvinnor", "Det som inte dödar oss", "Flickan som lekte med elden", "Luftslottet som sprängdes");

            CurrentQuestion = Quiz.GetRandomQuestion();
            SelectedAnswerIndex = -1;
            OnPropertyChange("CurrentQuestion");
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

            CurrentQuestion = Quiz.GetRandomQuestion();

            var nextQuest = QuestionAnswerd.Any(q => q.Statement == CurrentQuestion.Statement);

            if (nextQuest == true)
            {
                
                CurrentQuestion = Quiz.GetRandomQuestion();
            }

            OnPropertyChange("CurrentQuestion");
            OnPropertyChange("ScoreText");

        }



    }
}
