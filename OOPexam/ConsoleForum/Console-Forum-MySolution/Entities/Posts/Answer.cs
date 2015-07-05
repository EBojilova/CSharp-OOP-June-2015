namespace ConsoleForum.Entities.Posts
{
    using System.Text;

    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    public class Answer : Post, IAnswer
    {
        public Answer(int id, IUser author, string body)
            : base(id, author, body)
        {
        }

        public override string ToString()
        {
            var answer = new StringBuilder();
            answer.AppendFormat("[ Answer ID: {0} ]", this.Id).AppendLine();
            answer.AppendFormat("Posted by: {0}", this.Author.Username).AppendLine();
            answer.AppendFormat("Answer Body: {0}", this.Body).AppendLine();
            answer.Append(new string('-', OutputUtility.Delimeter));

            // [ Answer ID: {id} ]
            // Posted by: {author}
            // Answer Body: {body}
            // --------------------
            return answer.ToString();
        }
    }
}