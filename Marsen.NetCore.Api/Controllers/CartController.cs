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
        readonly PlaceCartService service;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
            service = new PlaceCartService(new CartDao());
        }

        [HttpGet]
        public JsonResult Get(CartDto cart)
        {
            return new(cart);
        }
    }

    public class CartDao : ICartDao
    {
        public void Save()
        {
            //// TODO
            throw new System.NotImplementedException();
        }
    }
}