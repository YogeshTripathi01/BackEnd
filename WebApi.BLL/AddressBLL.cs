using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Models;
using WebAPI.Models;

namespace WebApi.BLL
{
  public class AddressBLL
    {

        PaymentDetailContext db = new PaymentDetailContext();

        public Boolean AddAddress(Address model)
        {
            db.Addresses.Add(model);
            db.SaveChanges();
            return true;
        }


        public IEnumerable<Address> GetAddresses()
        {
            return db.Addresses;
        }


    }
}
