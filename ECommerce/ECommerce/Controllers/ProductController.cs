using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
            => new JsonResult(
                await _dbContext.Products
                    .ToListAsync()
                    .ConfigureAwait(false)
            )
            {
                StatusCode = 200
            };
    }
}