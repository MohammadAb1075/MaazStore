using Domain.FactorRows;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Products;

public class Product 
{

    //[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
    //(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است!")]
    [Display(Name = "نام محصول")]
    [MaxLength(length: 128,
        ErrorMessage = "حداکثر طول فیلد {0} می‌تواند {1} حرف باشد!")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است!")]
    [Display(Name = "قیمت واحد (بدون تخفیف)")]
    [Range(1, double.MaxValue, ErrorMessage = "مقدار {0} باید بزرگ‌تر یا مساوی {1} باشد!")]
    public double UnitPrice { get; set; } = 0;
    public virtual List<FactorRow> FactorRows { get; private set; } = new List<FactorRow>();

}
