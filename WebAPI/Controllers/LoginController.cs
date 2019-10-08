using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Controllers.LocalModels;
using WebAPI.Models;
 
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IConfiguration _config;
        Login l = new Login();

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
      

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        public IEnumerable<string> GetD() 
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("{id}")]
        public string GetD(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public string PostD([FromBody] user model)
        {
            Login login = new Login();
            if (ModelState.IsValid)
            {
                if (login.login(model)!=0 && login.login(model)!=2  )    //if  BLL return 1 it means it is an user then store id, to be used in browser local storage.
                { 

                    var tokenn = GenerateJSONWebToken();
                    //IN THIS case users login is successfull.
                    LoginSuccess obj = new LoginSuccess()
                    {
                        UserId = login.login(model),    // store the userid in loginsuccess class.
                        A = "user",
                        token = tokenn,
                       
                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);



                }
                else if (login.login(model) == 2)
                {
                    var tokenn = GenerateJSONWebToken();
                    LoginSuccess obj = new LoginSuccess()
                    {
                        A = "admin",
                        token = tokenn
                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);



                    // return Ok("Admin Login Successfull");
                }
                else
                {
                  
                    LoginSuccess obj = new LoginSuccess()
                    {
                        A = "Email or password Invalid"
                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                }
            }
            else
            {
               
                LoginSuccess obj = new LoginSuccess()
                {
                    A = "Email or password Invalid"
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
        }



        //PUT:api/Login/1
        [HttpPut("{id}")]  
        public IActionResult Put(int id,[FromBody] user model)
        {
            if (ModelState.IsValid)
            {
                if (l.updateUserDetails(id, model) == true)
                {
                    return Ok("data updated");
                }
                else
                {
                    return BadRequest("invalid id");
                }
                
            }
            else
            {
                return BadRequest("login model is not valid");
            }

        } 

        [HttpPost("social")]
        public IActionResult socialLogin([FromBody]user user)
        {
            Login login = new Login();

            var isUser = login.socialLogin(user);
            if (isUser) 
            {
                
                var Id = login.getUserId(user); 
                var tokenn = GenerateJSONWebToken(); 
                LoginSuccess obj = new LoginSuccess()
                {
                    A = "user",
                    token = tokenn,
   

                };
                return Ok(obj);
            }
            else
            {
                return BadRequest();
            }

        }




    }
}
