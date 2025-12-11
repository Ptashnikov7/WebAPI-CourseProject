using Microsoft.AspNetCore.Mvc;
using WebCourseProject.Data;
using WebCourseProject.Models;

namespace WebCourseProject.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProductsController(AppDbContext db)
    {
        _db = db;

        if (!_db.Products.Any())
        {
            _db.Products.AddRange(
                new Product { Id = 1, Name = "Phone", Price = 500 },
                new Product { Id = 2, Name = "TV", Price = 900 },
                new Product { Id = 3, Name = "Laptop", Price = 1200 }
            );
            _db.SaveChanges();
        }
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int? minPrice)
    {
        var items = _db.Products.AsQueryable();

        if (minPrice.HasValue)
            items = items.Where(i => i.Price >= minPrice.Value);

        return Ok(items.ToList());
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        _db.Products.Add(product);
        _db.SaveChanges();
        return Ok(product);
    }
}

