using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb3_NET22.DataModels;

public class QuizManager
{
    public string Title { get; set; }
    public List<Question> Questions { get; set; }
    public Random r { get; set; }

    private List<Question> UsedQuestions = new();

    private int index = 0;

    public QuizManager(string title = "")
    {
        Title = title;
        Questions = new List<Question>();
        //r = new Random();
    }

    public Question? GetNextQuestion()
    {
        if (Questions.Count == 0)
        {
            return null;
        }
        if (UsedQuestions.Count == Questions.Count)
        {
            return null;
        }

        if (index > (Questions.Count - 1))
        {
            return null;
        }

        var nextQuest = Questions[index];
        UsedQuestions.Add(nextQuest);
        index++;
        return nextQuest;
    }

    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {
        Question q = new Question
        {
            Statement = statement,
            CorrectAnswer = correctAnswer,
            Answers = answers.ToList()
        };
        Questions.Add(q);
    }


}