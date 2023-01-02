using Domain.Products;

namespace Domain.FactorRows;

public class FactorRow
{
    //public long UnitPrice { get => _UnitPrice; set => _UnitPrice = value; }
    //public int Tedad { get => _Tedad; set => _Tedad = value; }
    //public int Radif { get => _Radif; set => _Radif = value; }
    //public long RowPrice
    //{
    //    get
    //    {
    //        _RowPrice = this.Tedad * this.UnitPrice;
    //        return _RowPrice;
    //    }
    //}

    //public FactorRows()
    //{

    //}

    //public FactorRows(int radif, Products product, long unitprice, int teded)
    //{
    //    this.Radif = radif;
    //    this.Product = product;
    //    this.UnitPrice = unitprice;
    //    this.Tedad = teded;
    //}


    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Row { get; set; }
    public int Quantity { get; set; }
    public float Discount { get; set; }
   //public double UnitPrice { get; set; }
    public virtual Product Product { get; private set; } = new Product();   
    public double DiscountedUnitPrice
    {
        get => this.Product.UnitPrice * (100 - Discount) / 100;
    }
    public double RowPriceTotal {
        get => this.Quantity * this.Product.UnitPrice;
    }
    public double DiscountedRowPriceTotal {
        get => this.Quantity * this.Product.UnitPrice * (100 - Discount) / 100;
    }
    public double CustomerProfitUnitDiscount
    {
        get => this.Product.UnitPrice * (Discount) / 100;
    }
    public double CustomerProfitTotalDiscount
    {
        get => this.Quantity * this.Product.UnitPrice * (Discount) / 100;
    }
}
