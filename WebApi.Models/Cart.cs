
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebAPI.Models;

namespace WebApi.Models
{
  public class Cart
    {

        [Key]
        public int Cart_Id { get; set; }



        [ForeignKey("user")]
        public int userId { get; set; }
        public virtual user user { get; set; }



        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public Product Product { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double Total { get; set; }

        public string Product_Image { get; set; }  





  }
}
