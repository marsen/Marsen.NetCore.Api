using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marsen.NetCore.Api.Application;
using Marsen.NetCore.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Marsen.NetCore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        readonly PlaceCartService service = new PlaceCartService();

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public JsonResult Get(CartDto cart)
        {
            service.PutIn(cart);
            /// TODO: which One is Better
            /// 1.
            /// service.PutIn(cart);
            /// return service.GetCart();
            /// 2.
            /// return service.PutIn(cart);
            ///  
            throw new NotImplementedException("No result");
        }
    }
}