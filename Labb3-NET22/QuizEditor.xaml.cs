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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Labb3_NET22.DataModels;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for QuizEditor.xaml
    /// </summary>
    public partial class QuizEditor : UserControl
    {
        private Quiz _quiz;
        private string _title;

        public QuizEditor(Quiz quiz, string title)
        {
            InitializeComponent();
            _quiz = quiz;
            _title = title;

            TitleBox.Text = _quiz.Title;
            QuestList.ItemsSource = _quiz.Questions;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(Application.Current.MainWindow is MainWindow mw)
            {
                mw.Content = new Labb3_NET22.MainWindowView();
            }
        }

        private void QuestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuestList.SelectedItem is Question q)
            {
                QuestionBox.Text = q.Statement;
                Answer1Box.Text = q.Answers[0];
                Answer2Box.Text = q.Answers[1];
                Answer3Box.Text = q.Answers[2];
                Answer4Box.Text = q.Answers[3];
                CorrectAnswer.SelectedIndex = q.CorrectAnswer;
            }
        }


        private bool isUpdated()
        {
            if(QuestList.SelectedItem == null)
            {
                MessageBox.Show("Välj en fråga!");
                return false;
            }

            Question choosenQuestion = (Question)QuestList.SelectedItem;

            string questText = QuestionBox.Text.Trim();
            string a1 = Answer1Box.Text.Trim();
            string a2 = Answer2Box.Text.Trim();
            string a3 = Answer3Box.Text.Trim();
            string a4 = Answer4Box.Text.Trim();

            if(questText == "")
            {
                MessageBox.Show("Skriv in en fråga");
                return false;
            }

            if(a1 == "" || a2 == "" || a3 == "" || a4 == "")
            {
                MessageBox.Show("Skriv svar i alla rutorna");
                return false;
            }

            if (CorrectAnswer.SelectedIndex < 0 )
            {
                MessageBox.Show("Välj ett svar som ska vara rätt");
                return false;
            }

            choosenQuestion.Statement = questText;
            List<string> newAnswer = new List<string>();
            newAnswer.Add(a1);
            newAnswer.Add(a2);
            newAnswer.Add(a3);
            newAnswer.Add(a4);
            choosenQuestion.Answers = newAnswer;
            choosenQuestion.CorrectAnswer = CorrectAnswer.SelectedIndex;

            QuestList.Items.Refresh();
            MessageBox.Show("Frågan har uppdaterats!");
            return true;

        }

        public void EmptyAll()
        {
            QuestionBox.Text = "";
            Answer1Box.Text = "";
            Answer2Box.Text = "";
            Answer3Box.Text = "";
            Answer4Box.Text = "";
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _quiz.Title = TitleBox.Text.Trim();
            bool isSaved = isUpdated();
            if (!isSaved)
            {
                return;
            }
            try
            {
                await FileManager.SaveQuiz(_quiz);
                MessageBox.Show("Quizet har sparats!");
                QuestList.Items.Refresh();
                EmptyAll();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void DeletButton_Click(object sender, RoutedEventArgs e)
        {
            if(QuestList.SelectedItem is not Question q)
            {
                MessageBox.Show("Välj en fråga som ska bli raderad");
                return;
            }

            _quiz.Questions.Remove(q);
            QuestList.Items.Refresh();
            EmptyAll();

            try
            {
                await FileManager.SaveQuiz(_quiz);
                MessageBox.Show("Frågan är raderad och quizet är uppdaterat");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
