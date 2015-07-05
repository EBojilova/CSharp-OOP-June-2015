namespace ConsoleForum.Entities.Posts
{
    using ConsoleForum.Contracts;

    public abstract class Post : IPost
    {
        protected Post(int id, IUser author, string body)
        {
            this.Id = id;
            this.Author = author;
            this.Body = body;
        }

        public int Id { get; set; }

        public string Body { get; set; }

        public IUser Author { get; set; }

        public abstract override string ToString();
    }
}