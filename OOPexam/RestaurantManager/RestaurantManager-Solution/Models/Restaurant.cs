using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManager.Models
{
    public class Restaurant : IRestaurant
    {
        private string name;
        private string location;

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
                Validation.ForRequiredString(value);
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
                Validation.ForRequiredString(value);
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
            string result = string.Format("{0} {1} - {2} {0}{3}", new string('*', 5), this.Name, this.Location, Environment.NewLine);
            if (this.Recipes.Any())
            {
                string menu = string.Empty;
                menu += this.GetMenuGroup("Drink", "drinks");
                menu += this.GetMenuGroup("Salad", "salads");
                menu += this.GetMenuGroup("MainCourse", "main courses");
                menu += this.GetMenuGroup("Dessert", "desserts");
                result += menu;
            }
            else
            {
                result += "No recipes... yet";
            }

            return result.TrimEnd();
        }

        private string GetMenuGroup(string type, string heading)
        {
            var matchedRecipes = this.Recipes
                 .Where(r => r.GetType().Name == type)
                 .OrderBy(r => r.Name)
                 .ToList();
            if (matchedRecipes.Any())
            {
                string group = string.Format("{0} {1} {0}", new string('~', 5), heading.ToUpper()) + Environment.NewLine;
                group += string.Join(Environment.NewLine, matchedRecipes);
                return group + Environment.NewLine;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
