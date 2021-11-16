using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Store.DTO;
using ECommerce.Store.Persistence;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Store.Controllers
{
    [ApiController]
    [Route("product-quantity")]
    public class ProductQuantityController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductQuantityController(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult> SetProductQuantity(string productId, [FromBody] ProductQuantityInput input)
        {
            var productQuantity = await _dbContext
                .ProductQuantities
                .FirstOrDefaultAsync(x => x.Id == productId)
                .ConfigureAwait(false);

            if (productQuantity is null)
            {
                return new JsonResult(
                    new Dictionary<string, string>()
                    {
                        {"Error", "Product doesn't exist"}
                    }
                )
                {
                    StatusCode = 404
                };
            }

            productQuantity.Quantity += input.Quantity;
            _dbContext.ProductQuantities.Update(productQuantity);
            await _dbContext.SaveChangesAsync()
                .ConfigureAwait(false);
            
            // TODO PUBLISH AN UPDATE FOR PRODUCT QUANTITY

            return StatusCode(204);
        }
    }
}