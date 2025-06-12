public class QuestionList
{
    private Question[] questions;
    private int index = 0;

    public int Length => index;

    public QuestionList(int capacity)
    {
        questions = new Question[capacity];
    }

    public void Add(Question q)
    {
        if (index < questions.Length)
        {
            questions[index++] = q;
        }
    }

    public Question this[int i] => questions[i];
}
