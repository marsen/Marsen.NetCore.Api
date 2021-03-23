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
        readonly PlaceCartService service = new();

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public JsonResult Get(CartDto cart)
        {
            return new(cart);
        }
    }
}