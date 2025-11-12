using System;
using System.Collections.Generic;

namespace ProductsService.Models;

public partial class Product
{
    public int ProdId { get; set; }

    public string? ProdName { get; set; }

    public decimal? ProdPrice { get; set; }
}
