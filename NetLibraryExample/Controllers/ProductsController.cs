using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetLibraryExample.Models.DTOs;
using NetLibraryExample.Models.DTOs.ProductOperations;
using NetLibraryExample.Models.ORM;

namespace NetLibraryExample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly NetLibraryContext _context;

    public ProductsController(NetLibraryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _context.Products.Include(c => c.Category).ToList();
        if (products is null)
        {
            return BadRequest("Page not found");
        }
        List<ProductDto> productList = new List<ProductDto>();
        products.ForEach(x =>
        {
            ProductDto product = new ProductDto();
            product.Name = x.Name;
            product.UnitPrice = x.UnitPrice;
            product.StockAmount = x.StockAmount;
            product.CategoryName = x.Category.Name;
            product.Id = x.Id;
            productList.Add(product);
        });
        return Ok(productList);
    }

    [HttpGet("getproduct")]
    public IActionResult GetProduct(int id)
    {
        var product = (from Product in _context.Products
                join Category in _context.Categories on Product.CategoryId equals Category.Id
                select new
                {
                    Id = Product.Id,
                    Name = Product.Name,
                    UnitPrice = Product.UnitPrice,
                    StockAmount = Product.StockAmount,
                    CategoryName = Category.Name
                }
            ).FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return BadRequest("Product not found");
        }
        ProductDto productDto = new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            UnitPrice = product.UnitPrice,
            StockAmount = product.StockAmount,
            CategoryName = product.CategoryName
        };
        return Ok(productDto);
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductDto productDto)
    {
        Product product = new Product();
        product.Name = productDto.Name;
        product.UnitPrice = productDto.UnitPrice;
        product.StockAmount = productDto.StockAmount;
        product.CategoryId = productDto.CategoryId;
        try
        {
           _context.Products.Add(product);
           _context.SaveChanges();
           return Ok("Product created success...");
        }
        catch (Exception e)
        {
            return BadRequest("Product created error...");
        }
    }
}
