using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3_NET22
{
    public class ScoreWindowViewModel : INotifyCollectionChanged
    {
        private string _score { get; set; }
        public string Score
        {
            get { return _score; }

            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public ScoreWindowView ()
        {
            var importScore = PlayQuizViewModel.
        }

    }
}
