﻿using Marsen.NetCore.Api.Application;
using Marsen.NetCore.Api.Model;
using Marsen.NetCore.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Marsen.NetCore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        readonly PlaceCartService _service;

        public CartController(ILogger<CartController> logger, ICartDao cartDao)
        {
            _logger = logger;
            _service = new PlaceCartService(cartDao);
        }

        [HttpGet]
        public JsonResult Get(CartDto cart)
        {
            return new(cart);
        }
        
        [HttpPut]
        public ActionResult PutIn(CartDto cart)
        {
            _service.PutIn(cart);
            return Ok();
        }
    }
}