using BLL.Abstract;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiasProject.Controllers
{

    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUrunYoluBLL _urunYoluBLL;
        private readonly IOdaBLL _odaBLL;
        private readonly IEnvanterBLL _envanterBLL;

        public HomeController(ILogger<HomeController> logger, IUrunYoluBLL urunYoluBLL, IOdaBLL odaBLL, IEnvanterBLL envanterBLL)
        {
            _urunYoluBLL = urunYoluBLL;
            _logger = logger;
            _odaBLL = odaBLL;
            _envanterBLL = envanterBLL;
        }


        //[HttpPost]
        //public IActionResult CultureManagement(string culture)
        //{
        //    Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
        //        new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

        //        return RedirectToAction("Index");
        //}
        [HttpGet("Odalar")]
        public async Task<IEnumerable<Oda>> Odalar()
        {

            var model = _odaBLL.GetALL();
            return model;

        }

        [HttpGet("urunyollari")]
        public IActionResult Urunyollari()
        {

            var model = _urunYoluBLL.GetALL().ToList();
            List<UrunYolu> urunYolu = new List<UrunYolu>();
            urunYolu = model;
            for (int i = 0; i < urunYolu.Count; i++)
            {
                urunYolu[i].Envanter = _envanterBLL.GetById(urunYolu[i].EnvanterId);
                urunYolu[i].Oda = _odaBLL.GetById(urunYolu[i].OdaId);
            }
            //var model = JsonConvert.DeserializeObject<List<MatrixModel.RootObject>>(json);
            //var json = JsonSerializer.Serialize(urunYolu);
            return Ok(urunYolu);

        }
    }
}
