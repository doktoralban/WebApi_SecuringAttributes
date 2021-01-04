using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_SecuringAttributes.Attributes;
using WebApi_SecuringAttributes.Data;

namespace WebApi_SecuringAttributes.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    [ApiKey]
    public class ProductsController : ControllerBase
    {

        private readonly dbContextNW _context;

        public ProductsController(dbContextNW context)
        {
            _context = context;
        }

        [HttpGet]
      
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

         
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }






    }
}
