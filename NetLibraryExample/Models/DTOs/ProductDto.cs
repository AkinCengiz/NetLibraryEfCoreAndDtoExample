namespace NetLibraryExample.Models.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockAmount { get; set; }
    public string CategoryName { get; set; }
}
