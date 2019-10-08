using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;
using System.Linq;

namespace WebApi.BLL
{
   public class ProductBS
    {
        PaymentDetailContext db = new PaymentDetailContext();

        public IEnumerable<Product> GetProducts()
        {
            return db.Products;
        }

        public Boolean AddProduct(Product model)
        {
            db.Products.Add(model);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Product> getproductbyid(int id)
        {
            var query = from p in db.Products where p.Product_Id == id select p;
            return query;
        }


        public bool updateProduct(int id, Product model)
        {
            if (datavalid(id))
            {
                var query = db.Products.Where(p => p.Product_Id == id).FirstOrDefault();
                query.Product_Name = model.Product_Name;
                query.Product_Price = model.Product_Price;
                query.Product_Quantity = model.Product_Quantity;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public bool deleteProduct(int id)
        {
            if (datavalid(id))
            {
                var query = db.Products.Where(p => p.Product_Id == id).FirstOrDefault();
                db.Entry(query).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }




        public Boolean datavalid(int id)
        {
            var query = db.Products.Where(p => p.Product_Id == id).FirstOrDefault();
            if (query == null)
            { 
                return false;
            }
            else
            {
                return true;
            }

        }


    }
}
