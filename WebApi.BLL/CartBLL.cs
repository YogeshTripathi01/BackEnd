using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Models;
using WebAPI.Models;

namespace WebApi.BLL
{
    public class CartBLL
    {

        PaymentDetailContext db = new PaymentDetailContext();

        Cart c1 = new Cart();

        public Boolean AddCart(Cart model)
        {

            var availableStock = db.Products.Where(x => x.Product_Id == model.Product_Id).FirstOrDefault(); 
            int StockInHand = availableStock.Product_Quantity;
            if (StockInHand > model.Quantity)
            {

                var Authorize = db.carts.Where(x => x.Product_Id == model.Product_Id && x.userId == model.userId).FirstOrDefault();
                if (Authorize == null)
                {
                    db.carts.Add(model);
                    db.SaveChanges();
                    var query = db.carts.Where(x => x.Cart_Id == model.Cart_Id).FirstOrDefault();
                    var query1 = db.Products.Where(p => p.Product_Id == model.Product_Id).FirstOrDefault();
                    double price = query1.Product_Price;
                    query.Price = price;
                    var query4 = from c in db.carts where c.userId == model.userId select c;
                    query.Product_Image = query1.Product_Image;    
                    query.Total = (query.Quantity * price);
                    db.SaveChanges();
                    return true;


                }
                else
                {
                    Authorize.Quantity = Authorize.Quantity + model.Quantity;
                    Authorize.Total = Authorize.Total + (model.Quantity * Authorize.Price);
                    db.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public double Total(Cart model)
        {
            double total = 0;
            var query = from q in db.carts where q.userId == model.userId select q;
            foreach(var u in query) 
            {
                total = total + u.Total;
            }
            return total;
        }


        //public bool deleteCart(Cart model)
        //{
        //    var delete = from a in db.carts where a.Product_Id == model.Product_Id select a;
        //    foreach(var t in delete)
        //    {
        //        db.Entry(delete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        //        db.SaveChanges();
        //        return true; 
        //    } 
           
             
        //        return false;
            
        //}




        public bool RemoveFromCart(Cart model)
        {
            var Authorize = db.carts.Where(x => x.Product_Id == model.Product_Id && x.userId == model.userId).FirstOrDefault();
            if (Authorize.Quantity == 1)
            {
                db.Entry(Authorize).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }

            else if (Authorize.Quantity > 1)
            {
                Authorize.Quantity = Authorize.Quantity - model.Quantity;
                Authorize.Total = Authorize.Total - (model.Quantity * Authorize.Price);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        


        public IEnumerable<Cart> GetCartValue(Cart model)
        {
            var query = from c in db.carts where c.userId == model.userId select c;
            return query;
        }


    }
}
