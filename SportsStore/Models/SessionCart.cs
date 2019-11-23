using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SportsStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class SessionCart : Cart
    {
        // this method will produce the Cart object for our cart session
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
            ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore] // session property will be ignored when serializing
        public ISession Session { get; set; }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this); // saving the current session after adding
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this); // saving the current session after removing

        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart"); // saving the current session after clearing
        }
    }
}
