namespace NetLibraryExample.Models.DTOs.ProductOperations;

public class CreateProductDto
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockAmount { get; set; }
    public int CategoryId { get; set; }
}
