using System;
using System.Collections.Generic;

namespace OrdersService.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Amount { get; set; }

    public DateTime? OrderTimeStamp { get; set; }
}
