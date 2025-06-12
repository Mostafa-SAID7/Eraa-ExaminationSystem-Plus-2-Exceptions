using System;

public enum ExamMode
{
    Starting,
    Finished
}

public abstract class Exam
{
    public DateTime StartTime { get; set; }
    public int NumberOfQuestions { get; set; }
    public int Grade { get; set; }
    public int MarkOfExam { get; set; }
    public ExamMode Mode { get; set; }
    public Subject Subject { get; set; }

    public delegate void ExamStartedHandler(object sender, EventArgs e);
    public event ExamStartedHandler ExamStarted;

    protected Exam(DateTime startTime, int numberOfQuestions)
    {
        StartTime = startTime;
        NumberOfQuestions = numberOfQuestions;
        Subject = new Subject("General");
    }

    public virtual void NotifyStudents()
    {
        Student[] students = { new Student("Ali"), new Student("Sara") };
        foreach (var s in students)
        {
            ExamStarted += s.OnExamStarted;
        }
        ExamStarted?.Invoke(this, EventArgs.Empty);
    }

    public abstract void ShowExam(QuestionList questions);
}

public class FinalExam : Exam
{
    public FinalExam(DateTime startTime, int numberOfQuestions)
        : base(startTime, numberOfQuestions)
    { }

    public override void ShowExam(QuestionList questions)
    {
        // Handled in Main()
    }
}

public class Subject
{
    public string Name { get; set; }

    public Subject(string name)
    {
        Name = name;
    }
}

public class Student
{
    public string Name { get; set; }

    public Student(string name)
    {
        Name = name;
    }

    public void OnExamStarted(object sender, EventArgs e)
    {
        Console.WriteLine($"📢 Student {Name} has been notified: Exam Started!");
    }
}
