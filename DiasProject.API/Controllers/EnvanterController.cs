using BLL.Abstract;
using Data.Entities;
using DiasProject.Enum;
using Dto.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiasProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EnvanterController : ControllerBase
    {
        private readonly IEnvanterBLL _envanterBLL;

        public EnvanterController(IEnvanterBLL envanterBLL)
        {
            _envanterBLL = envanterBLL;
        }


        [HttpGet("Get")]
        public async Task<IActionResult> Index()
        {
            var model = _envanterBLL.GetALL();
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Index(EnvanterDTO model)
        {

            var envanter = new Envanter
            {
                Durum = (int)EnvanterDurumEnum.depo,
                Ad = model.Ad,
                Numara = model.Numara
            };
            var envanterler = _envanterBLL.GetALL();
            foreach (var b in envanterler)
            {
                if (b.Ad.ToUpper() == model.Ad.ToUpper())
                {
                    return BadRequest("Aynı Bina isminden birkez girebilirsiniz");
                }
            }

            _envanterBLL.Add(envanter);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Envanter>> GetAll()
        {

            var model = _envanterBLL.GetALL().Where(x=>x.Durum==0);
            return model;

        }

        [HttpGet("GetById/{id}")]
        public async Task<Envanter> GetById(int id)
        {

            var model = _envanterBLL.GetById(id);
            return model;
        }


        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var model = _envanterBLL.GetById(id);
            model.SilindiMi = true;
            _envanterBLL.Update(model);
            return Ok();
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(EnvanterDTO model)
        {

            var envanter = new Envanter
            {
                ID = model.ID,
                Ad = model.Ad,
                Numara = model.Numara
            };
            //var envanterler = _envanterBLL.GetALL();
            //foreach (var b in envanterler)
            //{
            //    if (b.ID == model.ID)
            //    {
            //        if (b.Ad.ToUpper() == model.Ad.ToUpper())
            //        {

            //            return RedirectToAction("List");
            //        }
            //        else
            //        {
            //            if (b.Ad.ToUpper() == model.Ad.ToUpper())
            //            {
            //                return BadRequest("Aynı Bina isminden birkez girebilirsiniz");
            //            }
            //        }

            //    }
            //}
            _envanterBLL.Update(envanter);
            return Ok();
        }

        [HttpPost("cikis/{id}")]
        public IActionResult Cikis(int id)
         {
            var model = _envanterBLL.GetById(id);
            var envanter = new Envanter
            {
                ID = model.ID,
                Durum = (int)EnvanterDurumEnum.oda,
                Ad = model.Ad,
                Numara = model.Numara,
            };
            _envanterBLL.Update(envanter);
            return Ok();
        }
    }
}
