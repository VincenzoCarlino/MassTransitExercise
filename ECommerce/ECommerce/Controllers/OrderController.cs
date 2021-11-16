using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.DTO;
using ECommerce.Models;
using ECommerce.Persistence;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderController(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] NewOrderInput input)
        {
            var products = new List<(Product, int)>();

            foreach (var productInput in input.Products)
            {
                var p = await _dbContext.Products
                    .FirstOrDefaultAsync(x => x.Id == productInput.Id)
                    .ConfigureAwait(false);

                if (p is null)
                {
                    return new JsonResult(
                        new Dictionary<string, string>()
                        {
                            {"Invalid Product", $"Id {productInput.Id} is invalid"}
                        }
                    )
                    {
                        StatusCode = 400
                    };
                }
                else if (p.AvailableQuantity < productInput.Quantity)
                {
                    return new JsonResult(
                        new Dictionary<string, string>()
                        {
                            {"Invalid Quantity", $"There are only: {p.AvailableQuantity} stock of {p.Name}"}
                        }
                    )
                    {
                        StatusCode = 400
                    };
                }

                products.Add(new(p, productInput.Quantity));
            }

            var order = new Order(
                Guid.NewGuid(),
                input.User,
                input.Address,
                "pending",
                products.Sum(p => p.Item1.Price * p.Item1.AvailableQuantity)
            );
            order.SetProducts(products);

            await _dbContext.Orders
                .AddAsync(order)
                .ConfigureAwait(false);
            await _dbContext.SaveChangesAsync()
                .ConfigureAwait(false);

            // TODO PUBLISH AN EVENT FOR NEW ORDER

            return StatusCode(201);
        }
    }
}