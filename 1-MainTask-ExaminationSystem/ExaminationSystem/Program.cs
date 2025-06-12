// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of questions:");
        int numQuestions = int.Parse(Console.ReadLine());

        QuestionList questionList = new QuestionList(numQuestions);

        for (int i = 0; i < numQuestions; i++)
        {
            Console.WriteLine($"\n--- Question {i + 1} ---");
            Console.WriteLine("Choose type (1: True/False, 2: Multiple Choice):");
            int type = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Header:");
            string header = Console.ReadLine();

            Console.WriteLine("Enter Marks:");
            int marks = int.Parse(Console.ReadLine());

            Question q = type switch
            {
                1 => new TrueOrFalse(header, marks),
                2 => new ChooseAll(header, marks),
                _ => throw new ArgumentException("Invalid type")
            };

            questionList.Add(q);
        }

        Console.WriteLine("\nDo you want to start the exam now? (Y/N)");
        string startInput = Console.ReadLine();

        if (!startInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Exam canceled. Exiting.");
            return;
        }

        TimeSpan duration;
        while (true)
        {
            Console.WriteLine("Enter exam duration in format HH:MM:SS (e.g., 1:00:00 for 1 hour):");
            string input = Console.ReadLine();
            if (TimeSpan.TryParse(input, out duration))
                break;
            Console.WriteLine("Invalid time format. Please try again.");
        }

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.Add(duration);
        bool midpointNotified = false;

        Exam exam = new FinalExam(startTime, questionList.Length);

        Console.WriteLine("\n--- Exam Started ---");

        for (int i = 0; i < questionList.Length; i++)
        {
            DateTime now = DateTime.Now;

            // Midpoint notification
            double elapsedSeconds = (now - startTime).TotalSeconds;
            if (!midpointNotified && elapsedSeconds >= duration.TotalSeconds / 2.0)
            {
                midpointNotified = true;
                Console.WriteLine("\nYou are halfway through the exam.\n");
            }

            if (now > endTime)
            {
                Console.WriteLine("\nTime is up! Exam finished.");
                break;
            }

            var q = questionList[i];
            Console.WriteLine($"\nQ{i + 1}:");
            Console.WriteLine(q);
            Console.Write("Your Answer: ");
            string userInput = Console.ReadLine();

            bool isCorrect = q.CheckAnswer(userInput);
            if (isCorrect)
            {
                exam.Grade += q.Marks;
                Console.WriteLine($"===== Correct! You earned {q.Marks} marks.=====");
            }
            else
            {
                Console.WriteLine("===== Incorrect. You earned 0 marks.=====");
            }

            exam.MarkOfExam += q.Marks;
        }

        exam.Mode = ExamMode.Finished;
        TimeSpan totalTimeTaken = DateTime.Now - startTime;

        Console.WriteLine($"\n===== Your final grade: {exam.Grade} out of {exam.MarkOfExam} =====");
        Console.WriteLine($"===== Exam time is: {duration.Hours} h {duration.Minutes} m {duration.Seconds} s =====");
        Console.WriteLine($"===== Time spent to finish the exam: {totalTimeTaken.Hours} h {totalTimeTaken.Minutes} m {totalTimeTaken.Seconds} s =====");
    }
}
