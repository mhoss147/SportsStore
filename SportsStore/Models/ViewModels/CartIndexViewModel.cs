using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class CartIndexViewModel
    {
        // properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
