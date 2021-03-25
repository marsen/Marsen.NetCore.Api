using System.Collections.Generic;

namespace Marsen.NetCore.Api.Models
{
    public class CartDTO
    {
        public IEnumerable<LineItemDTO> LineItems { get; set; }
        public int Total { get; set; }
    }
}