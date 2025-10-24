using System;
using System.Collections.Generic;

namespace Labb3_NET22.DataModels;   

public class Quiz
{
    public string Title { get; set; }
    public List<Question> Questions { get; set; }
    public Random r { get; set; }

    public Quiz(string title = "")
    {
        Title = title;
        Questions = new List<Question>();
        r = new Random();
    }

    public Question GetRandomQuestion()
    {
        int index = r.Next(0, Questions.Count);
        return Questions[index];
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