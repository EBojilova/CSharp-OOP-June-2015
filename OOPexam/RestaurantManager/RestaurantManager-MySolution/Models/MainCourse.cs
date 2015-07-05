namespace RestaurantManager.Models
{
    using System.Text;

    using RestaurantManager.Interfaces;

    internal class MainCourse : Meal, IMainCourse
    {
        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, MainCourseType type)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.Type = type;
        }

        public MainCourseType Type { get; private set; }

        public override string ToString()
        {
            ////Type: Soup
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Type: {0}", this.Type).AppendLine();
            return sb.ToString();
        }
    }
}