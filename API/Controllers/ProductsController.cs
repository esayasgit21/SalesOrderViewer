using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly DataContext _dataContext;

        public ProductsController(ILogger<ProductsController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){

            var products = await _dataContext.Products.ToListAsync();

            return Ok(products);

        }
        [HttpGet("{id}")]
        public async Task< ActionResult<Product>> GetProduct(int id){
            var product = await _dataContext.Products.FindAsync(id);
            return Ok(product);

        }
    }
}