using System;
using System.Linq;
using System.Collections.Generic;

public abstract class Question
{
    public string Header { get; set; }
    public int Marks { get; set; }

    protected Question(string header, int marks)
    {
        Header = header;
        Marks = marks;
    }

    public abstract bool CheckAnswer(string userInput);
    public abstract override string ToString();
}

public class TrueOrFalse : Question
{
    public bool CorrectAnswer { get; set; }

    public TrueOrFalse(string header, int marks)
        : base(header, marks)
    {
        while (true)
        {
            Console.WriteLine("Enter correct answer (true/false):");
            string input = Console.ReadLine()?.Trim().ToLower();
            if (bool.TryParse(input, out bool result))
            {
                CorrectAnswer = result;
                break;
            }
            else
            {
                Console.WriteLine("❌ Invalid input. Please enter 'true' or 'false'.");
            }
        }
    }

    public override bool CheckAnswer(string userInput)
    {
        return bool.TryParse(userInput, out bool userAnswer) && userAnswer == CorrectAnswer;
    }

    public override string ToString() => $"{Header}\nChoose True or False:";
}

public class ChooseAll : Question
{
    public string[] Options = new string[4];
    public string[] CorrectAnswers;

    public ChooseAll(string header, int marks)
        : base(header, marks)
    {
        HashSet<string> uniqueOptions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < Options.Length; i++)
        {
            while (true)
            {
                Console.WriteLine($"Enter option {i + 1}:");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("❌ Option cannot be empty.");
                }
                else if (!uniqueOptions.Add(input))
                {
                    Console.WriteLine("❌ Duplicate option. Please enter a unique value.");
                }
                else
                {
                    Options[i] = input;
                    break;
                }
            }
        }

        while (true)
        {
            Console.WriteLine("Enter correct answers (comma-separated):");
            CorrectAnswers = Console.ReadLine()?
                .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            if (CorrectAnswers == null || CorrectAnswers.Length == 0)
            {
                Console.WriteLine("❌ You must enter at least one correct answer.");
                continue;
            }

            if (!CorrectAnswers.All(ans => Options.Contains(ans, StringComparer.OrdinalIgnoreCase)))
            {
                Console.WriteLine("❌ Some answers are not among the provided options. Try again.");
                continue;
            }

            break;
        }
    }

    public override bool CheckAnswer(string userInput)
    {
        var userAnswers = userInput?
            .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();

        if (userAnswers == null || userAnswers.Length != CorrectAnswers.Length)
            return false;

        return CorrectAnswers.All(ans =>
            userAnswers.Contains(ans, StringComparer.OrdinalIgnoreCase));
    }

    public override string ToString()
        => $"{Header}\nChoose all that apply:\nOptions: {string.Join(", ", Options)}";
}
