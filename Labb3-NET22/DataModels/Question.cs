using System.Collections.Generic;

namespace Labb3_NET22.DataModels;

public class Question
{
    public string Statement { get; set; }
    public List<string> Answers { get; set; } = new List<string>();
    public int CorrectAnswer { get; set; }
      
    public bool isCorrect(int selectedIndex)
    {
        return selectedIndex == CorrectAnswer;
    }

}