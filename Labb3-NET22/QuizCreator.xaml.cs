using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Labb3_NET22.DataModels;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for QuizCreator.xaml
    /// </summary>
    public partial class QuizCreator : UserControl
    {
        public Quiz CurrentQuiz = new Quiz();

        public bool ControllInput()
        {
            string Question = QuestionBox.Text.Trim();

            string[] answers = new[] { Answer1Box, Answer2Box, Answer3Box, Answer4Box }.Select(AB => AB.Text.Trim()).ToArray();

            int CorrectAnswer = CorrectAnswerBox.SelectedIndex;

            if (string.IsNullOrWhiteSpace(Question))
            {
                MessageBox.Show("Skriv en fråga!");
                return false;
            }

            if (answers.Any(A => string.IsNullOrWhiteSpace(A)))
            {
                MessageBox.Show("Fyll alla svar!");
                return false;
            }

            if (CorrectAnswer < 0 || CorrectAnswer >= answers.Length)
            {
                MessageBox.Show("Du måste välja ett svar!");
                return false;
            }

            return true;
        }

        public void ClearPage()
        {
            QuestionBox.Text = string.Empty;
            Answer1Box.Text = string.Empty;
            Answer2Box.Text = string.Empty;
            Answer3Box.Text = string.Empty;
            Answer4Box.Text = string.Empty;
            CorrectAnswerBox.SelectedIndex = -1;
        }

        public QuizCreator()
        {
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.Content = new Labb3_NET22.MainWindowView();
            }
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            ControllInput();
            if (ControllInput() == false)
            {
                return;
            }

            string Question = QuestionBox.Text.Trim();

            string[] answers = new[] { Answer1Box, Answer2Box, Answer3Box, Answer4Box }.Select(A => A.Text.Trim()).ToArray();
            int CorrectAnswer = CorrectAnswerBox.SelectedIndex;

            Question NewQuestion = new Question
            {
                Statement = Question,
                CorrectAnswer = CorrectAnswer,
                Answers = answers.ToList()
            };
            CurrentQuiz.Questions.Add(NewQuestion);
            MessageBox.Show("Frågan har lagts till!");
            ClearPage();
            //CurrentQuiz = new Quiz();
        }

        private async void SaveQuizButton_Click(object sender, RoutedEventArgs e)
        {
            string Title = TitleBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(TitleBox.Text))
            {
                MessageBox.Show("Skriv in en Titel!");
                return;
            }
            CurrentQuiz.Title = Title;

            if(CurrentQuiz ==  null)
            {
                CurrentQuiz = new Quiz();
            }

            if (CurrentQuiz.Questions == null)
            {
                MessageBox.Show("Det måste vara minst en fråga i quizet för att det ska kunna sparas!");
                return;
            }

            await FileManager.SaveQuiz(CurrentQuiz);
            MessageBox.Show("Quizet Sparat!");
            ClearPage();
            //CurrentQuiz = new Quiz();

        }


    }
}
