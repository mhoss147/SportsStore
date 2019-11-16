using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent: ViewComponent 
    {
        private IProductRepository repository;
        // constructor
        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(repository.Products
            .Select(x => x.Category)
            // some product has same category but we weant distict
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
