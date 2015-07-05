namespace RestaurantManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using RestaurantManager.Interfaces;

    internal class Restaurant : IRestaurant
    {
        private string location;

        private string name;

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.Recipes = new List<IRecipe>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.StringNullEmptyValidator(value, "name");
                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                Validator.StringNullEmptyValidator(value, "location");
                this.location = value;
            }
        }

        public IList<IRecipe> Recipes { get; private set; }

        public void AddRecipe(IRecipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.Recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            //////~~~~~ DRINKS ~~~~~
            //////~~~~~ SALADS ~~~~~
            //////~~~~~ MAIN COURSES ~~~~~
            //////~~~~~ DESSERTS ~~~~~
            var sb = new StringBuilder();
            sb.AppendFormat("***** {0} - {1} *****", this.Name, this.Location).AppendLine();
            if (this.Recipes.Count == 0)
            {
                sb.AppendLine("No recipes... yet");
                return sb.ToString();
            }

            sb.AppendFormat(this.GetMenuGroup("Drink", "DRINKS"));
            sb.AppendFormat(this.GetMenuGroup("Salad", "SALADS"));
            sb.AppendFormat(this.GetMenuGroup("MainCourse", "MAIN COURSES"));
            sb.AppendFormat(this.GetMenuGroup("Dessert", "DESSERTS"));
            return sb.ToString().TrimEnd();
        }

        private string GetMenuGroup(string gropuName, string heading)
        {
            var menuGropu = this.Recipes.Where(r => r.GetType().Name == gropuName).OrderBy(r => r.Name);
            if (menuGropu.Any())
            {
                var sb = new StringBuilder();
                sb.AppendFormat("~~~~~ {0} ~~~~~", heading).AppendLine();
                sb.Append(string.Join(String.Empty, menuGropu.Select(r => r.ToString())));
                return sb.ToString();
            }

            return string.Empty;
        }
    }
}