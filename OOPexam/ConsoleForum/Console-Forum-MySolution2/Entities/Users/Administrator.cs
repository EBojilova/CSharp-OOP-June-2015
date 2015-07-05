namespace ConsoleForum.Entities.Users
{
    using ConsoleForum.Contracts;

    internal class Administrator : User, IAdministrator
    {
        public Administrator(int id, string name, string password, string email)
            : base(id, name, password, email)
        {
        }
    }
}