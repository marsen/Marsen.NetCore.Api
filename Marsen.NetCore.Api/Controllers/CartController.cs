using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marsen.NetCore.Api.Application;
using Marsen.NetCore.Api.Model;
using Marsen.NetCore.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Marsen.NetCore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public CartView Get()
        {
            var service = new CartService();
            service.PutIn(new CartProduct(new Product {Name = "Milk", Price = new Money{Value = 10, Symbol = "NTD"}}, 1));
            service.PutIn(new CartProduct(new Product {Name = "Oil", Price = new Money{Value = 7, Symbol = "NTD"}}, 2));
            service.PutIn(new CartProduct(new Product {Name = "Bun", Price = new Money{Value = 6, Symbol = "NTD"}}, 3));
            return service.GetCart();
        }
    }
}