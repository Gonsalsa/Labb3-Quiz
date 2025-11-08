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
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : UserControl
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        public void StartButton_Click(Object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mw)
            {
                mw.Content = new Labb3_NET22.SelectQuiz();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if(Application.Current.MainWindow is MainWindow mw)
            {
                mw.Content = new SelectQuiz();
            }
        }

        private void NewQuizButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mw)
            {
                mw.Content = new QuizCreator();
            }
        }
    }
}
