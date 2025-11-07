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
    /// Interaction logic for ScoreWindowView.xaml
    /// </summary>
    public partial class ScoreWindowView : UserControl
    {
        public ScoreWindowView(PlayQuizViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            if(Application.Current.MainWindow is MainWindow mw)
            {
                mw.Content = new Labb3_NET22.MainWindowView();
            }
        }
    }
}
