namespace Labb3_NET22.DataModels;

public class Question
{
    public string Statement { get; set; }
    public string[] Answers { get; set; }
    public int CorrectAnswer { get; set; }

    public Question(string statement, int correctAnswers, params string[] answers)
    {
        Statement = statement;
        CorrectAnswer = correctAnswers;
        Answers = answers;
    }

    public bool isCorrect(int selectedIndex)
    {
        return selectedIndex == CorrectAnswer;
    }

}