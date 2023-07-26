using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIdemo.Data;
using APIdemo.Models;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace APIdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ProductsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProduct()
        {
            return Ok(await _context.products.ToListAsync());
        }
        [HttpGet("id")]
        public ActionResult<Products> GetId(int id)
        {
            var product = _context.products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        [HttpPost]
        public async Task<ActionResult<Products>> Create(Products products)
        {
            _context.Add(products);
            await _context.SaveChangesAsync();
            return Ok(products);
        }
        [HttpPut("id")]
        public async Task<ActionResult> Update(int id, Products products)
        {
            if (id != products.Id)
            {
                return BadRequest();
            }
            _context.Entry(products).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(products);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
    } 
}