using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebAPI.Models;

namespace WebApi.Models
{
   public class Category
    {
        [Key]
        public int Category_Id { get; set; }

        public string Category_Name { get; set; }

        public string Category_Description { get; set; }

        public virtual ICollection<Product> Product { get; set; } 

    }
}
