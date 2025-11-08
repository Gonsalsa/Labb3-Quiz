using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb3_NET22.DataModels;

public class Quiz
{
    public string Title { get; set; }
    public List<Question> Questions { get; set; }
    public Random r { get; set; }

    private List<Question> UsedQuestions = new();

    public Quiz(string title = "")
    {
        Title = title;
        Questions = new List<Question>();
        r = new Random();
    }

    public Question GetRandomQuestion()
    {
        if (Questions.Count == 0)
        {
            return null;
        }
        if (UsedQuestions.Count == Questions.Count)
        {
            return null;
        }

        var notUsed = Questions.Except(UsedQuestions).ToList();
        int index = r.Next(0, notUsed.Count);
        var nextQuest = notUsed[index];

        UsedQuestions.Add(nextQuest);
        return nextQuest;
    }

    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {
        Question q = new Question(statement, correctAnswer, answers);
        Questions.Add(q);
    }

    public void RemoveQuestion(int index)
    {
    }
}