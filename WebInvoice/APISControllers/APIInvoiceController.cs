using Domain.Models;
using Infarstructuer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebInvoice.APISControllers
{
    [Route("api/APIInvoice")]
    [ApiController]
    public class APIInvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public APIInvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<APIInvoiceController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.InvoiceTemps.Include(x=>x.Category).Include(x=>x.Product)
                        .Where(x=>x.BaranchId.Equals(2)).ToList());
        }
        [HttpGet("GetAllTotal")]
        public IActionResult GetAllTotal()
        {
            return Ok(_context.InvoiceTemps.Where(x=>x.BaranchId.Equals(2)).Sum(x=>x.Total));
        }
        // GET api/<APIInvoiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<APIInvoiceController>
        [HttpPost]
        public IActionResult Post([FromBody] InvoiceTemp model)
        {
            try
            {
                model.BaranchId = 2;
                var result = _context.InvoiceTemps.FirstOrDefault(x=>x.CategoryId.Equals(model.CategoryId) 
                && x.ProductId.Equals(model.ProductId));
                if(result == null)
                    _context.InvoiceTemps.Add(model);
                else
                {
                    result.Quntity += model.Quntity;
                    result.Total += model.Price * model.Quntity;
                    _context.InvoiceTemps.Update(result);
                }  
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
              return BadRequest(ex.Message); 
            }
            
        }

        // PUT api/<APIInvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIInvoiceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _context.InvoiceTemps.FirstOrDefault(x=>x.InvoiceId.Equals(id) &&
                x.BaranchId.Equals(2));
                if(result != null)
                {
                    _context.InvoiceTemps.Remove(result);
                    _context.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
