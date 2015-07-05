namespace ConsoleForum
{
    using System;
    using System.Linq;

    using ConsoleForum.Entities.Posts;
    using ConsoleForum.Utility;

    public class ExtendedForum : Forum
    {
        protected override void ExecuteCommandLoop()
        {
             this.Output.AppendLine(new string('~', OutputUtility.Delimeter));
            if (this.IsLogged)
            {
                this.Output.AppendFormat(Messages.UserWelcomeMessage, this.CurrentUser.Username).AppendLine();
            }
            else
            {
                this.Output.AppendLine(Messages.GuestWelcomeMessage); 
            }

            int hotQuestions = this.Questions.Count(q => q.Answers.Any(a => a is BestAnswer));
            int activeUsers = this.Answers.GroupBy(a => a.Author.Id).Count(g => g.Count() >= 3);
            this.Output.AppendFormat(Messages.GeneralHeaderMessage, hotQuestions, activeUsers).AppendLine();
            this.Output.AppendLine(new string('~', OutputUtility.Delimeter));
            Console.Write(this.Output);
            base.ExecuteCommandLoop();
        }
    }
}