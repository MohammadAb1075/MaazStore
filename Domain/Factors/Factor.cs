using Domain.FactorRows;
using Domain.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Factors;

public class Factor
{
    private double _TotalPrice;
    private double _TotalDiscount;
    private double _Payable;

    public Factor()
    {
        Id = System.Guid.NewGuid();
        UpdateDateTime = InsertDateTime;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public System.Guid Id { get; private set; }

    [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است!")]
    [Display(Name = "شماره فاکتور")]
    public int FactorNo { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "تاریخ ثبت")]
    public System.DateTime InsertDateTime { get; private set; }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "تاریخ آخرین ویرایش")]
    public DateTime UpdateDateTime { get; private set; }

    [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است!")]
    [Display(Name = "نام خریدار")]
    [MaxLength(length: 128,
        ErrorMessage = "حداکثر طول فیلد {0} می‌تواند {1} حرف باشد!")]
    public string CustomerName { get; set; }

    [Display(Name = "توضیحات")]
    [MaxLength(length: 2000,
        ErrorMessage = "حداکثر طول فیلد {0} می‌تواند {1} حرف باشد!")]
    public string? Description { get; set; }
    public virtual List<FactorRow> FactorRows { get; set; } = new List<FactorRow>();

    [NotMapped]
    [Display(Name = "جمع کل")]
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

    [NotMapped]
    [Display(Name = "جمع تخفیف")]
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

    [NotMapped]
    [Display(Name = "قابل پرداخت")]
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

    public void SetUpdateDateTime()
    {
        UpdateDateTime = DateTime.Now;
    }


}