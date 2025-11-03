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
    /// Interaction logic for QuizCreator.xaml
    /// </summary>
    public partial class QuizCreator : UserControl
    {
        private Quiz CurrentQuiz = new Quiz();

        public QuizCreator()
        {
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveQuizButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
