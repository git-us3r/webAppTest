using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace webAppTest.Models
{
    public class webAppTestContext : DbContext
    {
        public DbSet<Recipe> Recipes_dbs { get; set; }
        public DbSet<Review> Reviews_dbs { get; set; }
        public DbSet<Style> Styles_dbs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // Modifications ...
            // Add a foreign key to Recipe from Review 
            // to account for the new relationship.
            modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Reviews)
            .WithRequired()
            .Map(m => m.MapKey("RecipeId"));


            // Adjust the relationship between Style 
            // and Recipe to fix the key name.
            modelBuilder.Entity<Recipe>()
            .HasRequired(s => s.Style)
            .WithMany(s => s.Recipes)
            .Map(m => m.MapKey("StyleId"));


            base.OnModelCreating(modelBuilder);
        }

    }


}