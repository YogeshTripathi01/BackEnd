using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.BLL;
using WebApi.Models;
using WebAPI.Controllers.LocalModels;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        PaymentDetailContext db = new PaymentDetailContext();
        CartBLL c = new CartBLL();

        //Calculate the Total of Cart...
        [HttpPost("getTotal")]
        public double Total([FromBody] Cart model)
        {
            return c.Total(model);     
        }




        [HttpPost("getCart")]

        public IEnumerable<Cart> Get([FromBody] Cart model)
        {
            var result = c.GetCartValue(model);
            return result;
        }


        [HttpGet] 

        public async Task<ActionResult<IEnumerable<Cart>>> Get()  //The task result contains a List<T> that contains elements from the input sequence.
        {
            return await db.carts.ToListAsync();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Cart model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("data invalid");
            }
            else
            {
                if (c.AddCart(model) == true)
                    return Ok();
                else
                    return NotFound();
            }
        }

        //[HttpPost("delete")]
        //public string  PostD([FromBody]Cart model)
        //{
        //    if (c.deleteCart(model))
        //    {
        //        Success _true = new Success();
        //        {
        //            _true.Succeed = true;
        //        } return Newtonsoft.Json.JsonConvert.SerializeObject(_true);
                
        //    } 
        //    else
        //    {
        //        Success _false = new Success();
        //        {
        //            _false.Succeed = false;
        //        }
        //        return Newtonsoft.Json.JsonConvert.SerializeObject(_false); 
        //    } 
        //}
          
         

        [HttpPost("remove")]
        public string PostC([FromBody]Cart model)
        {
            if (c.RemoveFromCart(model))
            {
                Success _success = new Success();
                {
                    _success.Succeed = true;  
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(_success);
            }
            else
            {
                Success _success = new Success();
                {
                    _success.Succeed = false;
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(_success);
            }



        }


    }
}