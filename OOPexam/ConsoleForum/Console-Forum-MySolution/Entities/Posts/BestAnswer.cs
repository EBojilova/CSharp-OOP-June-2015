namespace ConsoleForum.Entities.Posts
{
    using System.Text;

    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    public class BestAnswer : Answer
    {
        public BestAnswer(int id, IUser author, string body)
            : base(id, author, body)
        {
        }

        public override string ToString()
        {
            var bestAnswer = new StringBuilder();
            bestAnswer.AppendLine(new string('*', OutputUtility.Delimeter));
            bestAnswer.AppendLine(base.ToString());
            bestAnswer.Append(new string('*', OutputUtility.Delimeter));
            return bestAnswer.ToString();
        }
    }
}