namespace Domain.Products;

public class Product
{

    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
    (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public double UnitPrice { get; set; }

}
