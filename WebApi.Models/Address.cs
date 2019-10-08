
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebAPI.Models;

namespace WebApi.Models
{
   public class Address
   {


        [Key]
        public int AddressId { get; set; }
        public user userId { get; set; }

        public string City { get; set; }

        public string PinCode { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string HouseNumber { get; set; }

        public string Contact_Number { get; set; }


   }
}
