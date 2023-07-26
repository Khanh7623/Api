using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIdemo.Data;
using APIdemo.Models;

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
        [HttpPost]
        public JsonResult CreateEdit(Products products)
        {
            if(products.Id == 0)
            {
                _context.products.Add(products);
            }
            else
            {
                var ProductDb = _context.products.Find(products.Id);
                if(ProductDb == null)
                {
                    return new JsonResult(NotFound());
                }
                ProductDb = products;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(products));
        }
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.products.Find(id);
            if(result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.products.Find(id);
            if(result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.products.Remove(result);
            _context.SaveChanges();
            return new JsonResult("Done");
        }
        [HttpGet("/GetAll")]
        public JsonResult GetProductAll()
        {
            var result = _context.products.ToList();
            return new JsonResult(Ok(result));
        }
    }
}
