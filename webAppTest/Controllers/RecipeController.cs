using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using webAppTest.Models;        // To have access to Recipe

namespace webAppTest.Controllers
{
    // My controller. Note the method returns an ActionResult.
    public class RecipeController : Controller
    {
        //
        // GET: /Default1/


        //
        // What is to return a view - the view associated with this controller (/Views/Recipe/Index.cshtml).
        //
        public ActionResult Index(int page = 0)
        {
            //var recipeListModel = new List<Recipe>
            //{
            //    new Recipe {Name = "Test Recipe 1", MainIngredients = "Chicken"},
            //    new Recipe {Name = "Test Recipe 2", MainIngredients = "Beef"},
            //    new Recipe {Name = "Test Recipe 3", MainIngredients = "Fish"},

            //};

            //    return View(recipeListMode);

            //-------------------------------------------------------------------------------
            // New approach that uses the DB context (what is Entity Framework 5.0? what is ORM?)

            //List<Recipe> recipes = null;


            ////create an alias for a namespace or a type. This is called a using alias directive.
            //using (var context = new webAppTestContext()) 
            //{
            //    // What is MS LINQ? : http://msdn.microsoft.com/en-us/library/bb383978.aspx
            //    recipes = (from recipe in context.Recipes_dbs select recipe).ToList();
            //}

            //// pass that list to View
            //return View(recipes);


            // Even newer approach
            PagedResult<Recipe> recipes = null;
            using (var context = new webAppTestContext())
            {
                recipes = new PagedResult<Recipe>(
                    context.Recipes_dbs.OrderBy(r => r.Name),
                    page);
            }
            return View(recipes);
        }
    }
}
