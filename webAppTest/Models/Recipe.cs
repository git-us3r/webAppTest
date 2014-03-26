using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAppTest.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string MainIngredients { get; set; }
        public Category Category { get; set; }
        public string Status { get; set; }
        public Style Style { get; set; }
        
        // Other properties: think about recipe.
        
        // A list of reviews is associated with each recipe.
        public virtual ICollection<Review> Reviews { get; set; }
    }

    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }

    public class Style
    {
        public int StyleId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }

        // a collection of Recipes is associated with this style.
        public virtual ICollection<Recipe> Recipes {get; set;}
    }

    public enum Category
    {
        Healthy,
        Delicious
    }
}