using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

     namespace WebApi.BLL
     {
       public class Register
       {



        PaymentDetailContext db = new PaymentDetailContext();   
        public Boolean dataadd(user model)
        {
            if (EmailExists(model))
            {
                return false ;
            }
            else
            {
                model.Role = "user";
                db.users.Add(model);
                db.SaveChanges();
                return true; 
            }
           
        }


        public IEnumerable<user> getdata()
        {
            return db.users;
        }

        public IEnumerable<user> getdatabyid(int id)
        {
            var query = from r in db.users where r.userId == id select r;
            return query;
        }





        public bool updatedata(int id, user model)
        {
            if (datavalid(id))
            {
                var query = db.users.Where(z => z.userId == id).FirstOrDefault(); 
                query.FirstName = model.FirstName;  
                query.LastName = model.LastName;
                query.Email = model.Email;
                query.Password = model.Password;
                query.ProfilePic = model.ProfilePic;
                query.Phone = model.Phone;
                // db.users.attach(model);
                // db.entry(model).state = microsoft.entityframeworkcore.entitystate.modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool deletedata(int id)
        {
            if (datavalid(id))
            {
                var query = db.users.Where(z => z.userId == id).FirstOrDefault();
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
            var query = db.users.Where(z => z.userId == id).FirstOrDefault();
            if (query == null)
                return false;
            else
                return true;
        }

        public Boolean EmailExists(user model)
        {
            var query = db.users.Where(x => x.Email == model.Email).FirstOrDefault();
            if (query != null)
                return true;
            else
                return false; 
        }



       }
     }
