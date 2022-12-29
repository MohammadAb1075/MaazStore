using Common.Paginations;
using Domain.Products;

namespace Server.Models;

public class ProductListViewModel
{
    public PagedData<Product> Data { get; set; }
}
