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

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for SelectQuiz.xaml
    /// </summary>
    public partial class SelectQuiz : UserControl
    {
        private string selectedTitle;
        private readonly bool editMode;
        public SelectQuiz(bool isEditing = false)
        {
            InitializeComponent();
            editMode = isEditing;
            
        }

        private void GetTitle()
        {
            var titles = FileManager.GetTitle();
            if(titles.Count == 0)
            {
                MessageBox.Show("Du har inga sparaade quiz");
                return;
            }
            ListOfQuizes.ItemsSource = titles;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button btn && btn.Content is string title)
            {
                selectedTitle = title;
                if(editMode)
                {
                    await 
                }
            }
        }

        private async Task Editing(string title)
        {
            var quiz = await FileManager.GetFiles(title);
            if(quiz == null)
            {
                MessageBox.Show("Kunde inte ladda quizet ordentligt");
                return;
            }
            if(Application.Current.MainWindow is MainWindow mw)
            {
                mw.Content = Labb3_NET22.QuizEditor(quiz, title);
            }
        }

       
    }
}
