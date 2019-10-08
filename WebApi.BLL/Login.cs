using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebAPI.Models;


namespace BLL
{
    public class Login
    {
        PaymentDetailContext Db = new PaymentDetailContext();
        public Boolean EmailValid(user model) 
        {
            var query = Db.users.Where(x => x.Email == model.Email).FirstOrDefault();
            if (query != null)
                return true;
            else
                return false;
        }  
        public int login(user model)
        {
            if (EmailValid(model))
            {
                var query = Db.users.Where(x => x.Email == model.Email).FirstOrDefault();
                if (query == null)
                {
                    return 0;
                }
                else
                {
                    if (query.Role.ToUpper() == "USER")
                    {
                        var pass = query.Password;
                        var userId = query.userId;
                        if (model.Password != pass)
                            return 0;
                        else
                            return userId;
                    }
                     
                    else
                    {
                        var pass = query.Password;
                        if (model.Password != pass)
                            return 0;
                        else
                            return 2;
                    }
                }
            }
            else
            {
                return 0;
            }
        }


        public bool updateUserDetails(int id,user model)
        {
            if (datavalid(id))
            {
                var query = Db.users.Where(u => u.userId == id).FirstOrDefault();
                query.FirstName = model.FirstName;
                query.LastName = model.LastName;
                query.Password = model.Password;
                query.Email = model.Email;
                Db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        } 
        public Boolean datavalid(int id)
        {
            var query = Db.users.Where(u => u.userId == id).FirstOrDefault();
            if (query == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        } 
        public bool socialLogin(user user) 
        {
            var query = Db.users.Where(x => x.Email == user.Email).FirstOrDefault();
            if (query != null)
                return true;
            else
                return false; 
        } 
        public int getUserId(user model)
        {
            var query = Db.users.Where(x => x.Email == model.Email).FirstOrDefault();
            return query.userId;
        }

    } 
}
