using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3_NET22.DataModels
{
    public class Quiz
    {
        public string Title { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();

     
    }
}
