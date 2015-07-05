namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    internal class Question : Post, IQuestion
    {
        public Question(int id, IUser author, string title, string body)
            : base(id, author, body)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title { get; set; }

        public IList<IAnswer> Answers { get; private set; }

        public override string ToString()
        {
            var question = new StringBuilder();
            question.AppendFormat("[ Question ID: {0} ]", this.Id).AppendLine();
            question.AppendFormat("Posted by: {0}", this.Author.Username).AppendLine();
            question.AppendFormat("Question Title: {0}", this.Title).AppendLine();
            question.AppendFormat("Question Body: {0}", this.Body).AppendLine();
            question.AppendLine(new string('=', OutputUtility.Delimeter));
            if (!this.Answers.Any())
            {
                // tuka triabva da vnimavame da sme inicializirali Answers v konstructora s nov list
                question.Append("No answers");
            }
            else
            {
                question.AppendLine("Answers:");
                var hasBestAnswer = this.Answers.FirstOrDefault(a => a is BestAnswer) as BestAnswer;
                if (hasBestAnswer != null)
                {
                    question.AppendLine(hasBestAnswer.ToString());
                    var leftAnswers = this.Answers.ToList();
                    leftAnswers.Remove(hasBestAnswer);
                    question.Append(string.Join(Environment.NewLine, leftAnswers.Select(a => a.ToString())));
                }
                else
                {
                    question.Append(string.Join(Environment.NewLine, this.Answers.Select(a => a.ToString())));
                }
            }

            // [ Question ID: {id} ]
            // Posted by: {author}
            // Question Title: {title}
            // Question Body: {body}
            // ====================
            // {answers}
            return question.ToString();
        }
    }
}