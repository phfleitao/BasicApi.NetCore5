using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicApi.NetCore5.Data;
using BasicApi.NetCore5.Models;

namespace BasicApi.NetCore5.Controllers
{
    [Route("v1/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET: v1/categories
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories([FromServices] DataContext context)
        {
            return await context.Categories.ToListAsync();
        }

        // GET: v1/categories/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetCategoryById([FromServices] DataContext context, int id)
        {
            var category = await context.Categories.FirstOrDefaultAsync(o => o.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST: v1/categories
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> PostCategory(
            [FromServices] DataContext context,
            [FromBody] Category model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return model;
        }
    }
}
