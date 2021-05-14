using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicApi.NetCore5.Data;
using BasicApi.NetCore5.Models;

namespace BasicApi.NetCore5.Controllers
{
    [Route("v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: v1/products
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromServices] DataContext context)
        {
            return await context.Products.Include(i => i.Category).ToListAsync();
        }

        // GET: v1/products/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById([FromServices] DataContext context, int id)
        {
            var product = await context.Products
                                            .Include(i => i.Category)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(o => o.Id == id);

            if (product == null)
                return NotFound();

            return product;
        }

        // GET: v1/products/categories/5
        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory([FromServices] DataContext context, int id)
        {
            var products = await context.Products
                                            .Include(i => i.Category)
                                            .AsNoTracking()
                                            .Where(o => o.CategoryId == id)
                                            .ToListAsync();

            if (products == null)
                return NotFound();

            return products;
        }

        // POST: v1/products
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> PostProduct(
            [FromServices] DataContext context,
            [FromBody] Product model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Products.Add(model);
            await context.SaveChangesAsync();
            return model;
        }
    }
}
