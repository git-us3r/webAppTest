namespace webAppTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using webAppTest.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<webAppTest.Models.webAppTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(webAppTest.Models.webAppTestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            var roasted = new Style
            {
                Name = "Roasted",
                Category = Models.Category.Delicious
            };

            var fried = new Style
            {
                Name = "Deep Fried",
                Category = Models.Category.Delicious
            };

            var boiled = new Style
            {
                Name = "Boiled",
                Category = Models.Category.Healthy
            };


            context.Styles_dbs.AddOrUpdate(
                style => style.Name,
                roasted,
                fried,
                boiled
                );

            context.Recipes_dbs.AddOrUpdate(
                recipe => recipe.Name,
                new Recipe
                {
                    Name = "Roasted Chicken",
                    Style = roasted,
                    MainIngredients = "Chicken",
                    Category = Models.Category.Delicious,
                    Status = "available"                    
                },
                new Recipe
                {
                    Name = "Fried Chicken",
                    Style = fried,
                    MainIngredients = "Chicken",
                    Category = Models.Category.Delicious,
                    Status = "available"                    
                },
                new Recipe
                {
                    Name = "Boiled Veggies",
                    Style = boiled,
                    MainIngredients = "Brocolli, Mushrooms, Cabage",
                    Category = Models.Category.Healthy,
                    Status = "available"                    
                }
            );

        }
    }
}
