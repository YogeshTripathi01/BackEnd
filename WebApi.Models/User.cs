using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApi.Models;

namespace WebAPI.Models
{
    public class user
    {
        [Key]
        public int userId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Password { get; set; }
        public string ProfilePic { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }





    }
}
