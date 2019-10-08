
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebAPI.Models
{
    public class PaymentDetailContext:DbContext
    {
        public PaymentDetailContext()
        {

        }

        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options):base(options)
        {

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
           optionsBuilder.UseSqlServer(@"Server=XIPL9382\SQLEXPRESS;Database=FinalWEBApiDataBase;Trusted_Connection=True;");
      

        public DbSet<Product> Products { get; set; }

      

        public DbSet<user>  users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart> carts { get; set; }

        public DbSet<Address > Addresses { get; set; }


    }
}
