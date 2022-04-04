using BLL.Abstract;
using Data.Entities;
using Dto.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiasProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly IUserBLL _userBLL;

        public LoginController(IConfiguration configuration, IUserBLL userBLL)
        {
            _configuration = configuration;
            _userBLL = userBLL;
        }
        [HttpPost]
        public IActionResult Register(UserDTO user)
        {

            var userExists = _userBLL.GetALL();
            foreach (var item in userExists)
            {
                if(user.KullaniciAdi.ToUpper() == item.KullaniciAdi.ToUpper())
                {
                    return BadRequest("kullanıcı mevcut");
                }
            }
            var userU = new User
            {
                KullaniciAdi = user.KullaniciAdi,
                Password = user.Password,
            };
            _userBLL.Register(userU);

            return BadRequest("Invalid user");
        }

        [HttpPost("login")]
        public ActionResult Login(UserDTO user)
        {
            var userU = new User
            {
                KullaniciAdi = user.KullaniciAdi,
                Password = user.Password,
            };
            _userBLL.Login(userU);
            
            var result = _userBLL.CreateAccessToken(userU);
            

            return BadRequest("token oluşturuldu");
        }


    }
}
