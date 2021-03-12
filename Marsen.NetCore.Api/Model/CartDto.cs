using System.Collections.Generic;

namespace Marsen.NetCore.Api.Model
{
    public class CartDto
    {
        public List<LineItemDto> LineItemList { get; set; }
        public int Total { get; set; }
    }
}