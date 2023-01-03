using Domain.Factors;
using Domain.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.FactorRows;

public class FactorRow
{
    public FactorRow()
    {
        Id = System.Guid.NewGuid();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public System.Guid Id { get; private set; }

    [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است!")]
    [Display(Name = "تعداد")]
    [Range(1, 1000, ErrorMessage = "مقدار فیلد {0} باید بزرگ‌تر یا مساوی {1} و کوچک‌تر یا مساوی {2} باشد.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است!")]
    [Display(Name = "درصد تخفیف")]
    [Range(0, 100, ErrorMessage = "مقدار فیلد {0} باید بزرگ‌تر یا مساوی {1} و کوچک‌تر یا مساوی {2} باشد.")]
    public float Discount { get; set; }

    [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است!")]
    [Display(Name = "فاکتور")]
    public System.Guid FactorId { get; set; }

    [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است!")]
    [Display(Name = "فاکتور")]
    public virtual Factor Factor { get; private set; }

    [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است!")]
    [Display(Name = "محصول")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است!")]
    [Display(Name = "محصول")]
    public virtual Product Product { get; private set; } = new Product();

    [NotMapped]
    [Display(Name = "قیمت واحد (با تخفیف)")]
    public double DiscountedUnitPrice
    {
        get => this.Product.UnitPrice * (100 - Discount) / 100;
    }

    [NotMapped]
    [Display(Name = "سر جمع (بدون تخفیف)")]
    public double RowPriceTotal {
        get => this.Quantity * this.Product.UnitPrice;
    }
    
    [NotMapped]
    [Display(Name = "سر جمع (با تخفیف)")]
    public double DiscountedRowPriceTotal {
        get => this.Quantity * this.Product.UnitPrice * (100 - Convert.ToDouble(Discount)) / 100;
    }
    
    [NotMapped]
    [Display(Name = "سود مشتری از تخفیف واحد")]
    public double CustomerProfitUnitDiscount
    {
        get => this.Product.UnitPrice * (Convert.ToDouble(Discount)) / 100;
    }
    
    [NotMapped]
    [Display(Name = "سود مشتری از تخفیف کل")]
    public double CustomerProfitTotalDiscount
    {
        get => this.Quantity * this.Product.UnitPrice * (Convert.ToDouble(Discount)) / 100;
    }
    
    [NotMapped]
    public bool IsDeleted { get; set; } = false;
}
