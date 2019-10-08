using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebAPI.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

        public string Product_Name { get; set; }

        public Double Product_Price { get; set; }

        public int Product_Quantity { get; set; }

        public string Product_Description { get; set; }


        public string Product_Image { get; set; }



        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }

        public static implicit operator Product(int v)
        {
            throw new NotImplementedException();
        }
    }
}
