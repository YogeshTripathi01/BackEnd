using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebApi.BLL;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


        public ProductsController( PaymentDetailContext  context)
        {

        }

        ProductBS p = new ProductBS();
        PaymentDetailContext db = new PaymentDetailContext();

        //get:api/products
        [HttpGet]

    
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await db.Products.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await db.Products.FindAsync(id);



            if (product == null)
            {
                return NotFound();
            }



            return product;
        }

      

        //POST:api/Products
        [HttpPost]

        public IActionResult Post([FromBody]Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("data is invalid");

            }
            else
            {
                if (p.AddProduct(model) == true)
                    return Ok();
                else
                    return NotFound();
            }

        }


        //PUT:api/Products/1
        [HttpPut("{id}")]
         
        public IActionResult Put(int id,[FromBody]Product model)
        {
            if (ModelState.IsValid)
            {
                if (p.updateProduct(id, model) == true)
                {
                    return Ok("data updated");
                }
                else
                {
                    return BadRequest("invalid Id");
                }
            }
            else
            {
                return BadRequest("model is not valid");
            }
        }

        //Delete:api/ProductDelete/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (p.deleteProduct(id))
                {
                    return Ok("record deleted");
                }
                else
                {
                    return BadRequest("invalid id");
                }
            }
            else
            {
                return BadRequest("model is invalid");
            }
        }  
    }
}