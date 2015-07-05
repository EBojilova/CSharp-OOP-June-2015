using RestaurantManager.Interfaces;
using System;

namespace RestaurantManager.Models
{
    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, MainCourseType type)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.Type = type;
        }

        public MainCourseType Type { get; private set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                string.Format("Type: {0}", this.Type);
        }
    }
}
