using System.Collections.Generic;
using System.Linq;
using Marsen.NetCore.Api.Models;

namespace Marsen.NetCore.Api.Services
{
    public class CartService
    {
        readonly CartDTO _dto = new() {LineItems = new List<LineItemDTO>()};

        public void PutIn(LineItemDTO lineItemDto, int qty = 1)
        {
            var list = _dto.LineItems.ToList();
            if (list.Contains(lineItemDto))
            {
                var item = list.FirstOrDefault(x => x.Id == lineItemDto.Id);
                item.Qty++;
            }
            else
            {
                lineItemDto.Qty = qty;
                list.Add(lineItemDto);
            }

            list.ForEach(x => x.Subtotal = x.Qty * x.Price);
            _dto.LineItems = list;
        }

        public CartDTO GetCart()
        {
            _dto.Total = _dto.LineItems.Sum(x => x.Subtotal);
            return _dto;
        }
    }
}