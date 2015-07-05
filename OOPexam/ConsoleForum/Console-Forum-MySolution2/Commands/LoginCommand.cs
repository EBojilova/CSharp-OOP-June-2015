namespace ConsoleForum.Commands
{
    using System.Linq;

    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    internal class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var username = this.Data[1];
            var password = PasswordUtility.Hash(this.Data[2]);
            var currentUser = this.Forum.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (currentUser == null)
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }
            if (this.Forum.CurrentUser == currentUser)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            this.Forum.CurrentUser = currentUser;
            this.Forum.Output.AppendFormat(Messages.LoginSuccess, this.Forum.CurrentUser.Username).AppendLine();
        }
    }
}