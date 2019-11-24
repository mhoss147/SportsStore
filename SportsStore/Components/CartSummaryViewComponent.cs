using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        // constructor
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        // method
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }

    }
}
