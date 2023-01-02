using Domain.FactorRows;
using Domain.Products;

namespace Domain.Factors;

public class Factor
{
    private double _TotalPrice;
    private double _TotalDiscount;
    private double _Payable;

    public int Id { get; set; } = 0;
    public int FactorNo { get; set; } = 0;
    public DateTime FactorDate { get; set; } = DateTime.Now;
    public string? CustomerName { get; set; } = string.Empty;
    public string? Description { get; set; } = null;
    public virtual List<FactorRow> FactorRows { get; set; } = new List<FactorRow>();
    public double TotalPrice
    {
        get
        {
            foreach (var item in this.FactorRows)
            {
                _TotalPrice += item.RowPriceTotal;
            }
            return _TotalPrice;
        }
    }
    public double TotalDiscount
    {
        get
        {
            foreach (var item in this.FactorRows)
            {
                _TotalDiscount += item.CustomerProfitTotalDiscount;
            }
            return _TotalDiscount;
        }
    }

    public double Payable
    {
        get
        {
            foreach (var item in this.FactorRows)
            {
                _Payable += item.DiscountedRowPriceTotal;
            }
            return _Payable;
        }
    }

}