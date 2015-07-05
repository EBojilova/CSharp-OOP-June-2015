namespace ConsoleForum.Commands
{
    using System;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    internal class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            string title = this.Data[1];
            string body = this.Data[2];
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            var question = new Question(this.Forum.Questions.Count + 1, this.Forum.CurrentUser, title, body);
            this.Forum.Questions.Add(question);
            this.Forum.Output.AppendFormat(Messages.PostQuestionSuccess, question.Id).AppendLine();
        }
    }
}