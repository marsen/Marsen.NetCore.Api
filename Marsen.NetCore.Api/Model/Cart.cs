﻿using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Api.Model
{
    public class Cart
    {
        private readonly List<CartProduct> _products = new();
        public int TotalPrice => _products.Sum(x => x.SubTotal);
        public IEnumerable<CartProduct> ProductList => _products;

        public void PutIn(CartProduct product)
        {
            _products.Add(product);
        }
    }
}