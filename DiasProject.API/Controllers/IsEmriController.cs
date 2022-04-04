using BLL.Abstract;
using Data.Entities;
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
    public class IsEmriController : ControllerBase
    {
        private readonly IIsEmriBLL _isEmriBLL;
        private readonly IOdaBLL _odaBLL;
        private readonly IBinaBLL _binaBLL;
        private readonly IEnvanterBLL _envanterBLL;

        public IsEmriController(IIsEmriBLL isEmriBLL,IOdaBLL odaBLL, IBinaBLL binaBLL, IEnvanterBLL envanterBLL)
        {
            _isEmriBLL = isEmriBLL;
            _odaBLL = odaBLL;
            _binaBLL = binaBLL;
            _envanterBLL = envanterBLL;
        }

        [HttpGet("GetOdalar")]
        public async Task<IEnumerable<Oda>> GetOdalar()
        {
            var model = _odaBLL.GetALL();
            return model;
        }
        [HttpGet("GetEnvanterler")]
        public async Task<IEnumerable<Envanter>> GetEnvanterler()
        {
            var model = _envanterBLL.GetALL();
            return model;
        }
        

        [HttpPost("add")]
        public async Task<IActionResult> Index(IsEmriDTO model)
        {
            

            var isEmri = new IsEmri
            {
                Ad = model.Ad,
                EnvanterId = model.EnvanterId,
                OdaId = model.OdaId
            };
            _isEmriBLL.Add(isEmri);

            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<IsEmri>> GetAll()
        {

            var model = _isEmriBLL.GetALL();
            return model;

        }

        [HttpGet("GetById/{id}")]
        public async Task<IsEmri> GetById(int id)
        {

            var model = _isEmriBLL.GetById(id);
            return model;
        }


        [HttpPost("update")]
        public async Task<IActionResult> Update(IsEmriDTO model)
        {

            var isEmri = new IsEmri
            {
                ID = model.ID,
                Ad = model.Ad,
            };
            var isEmirleri = _isEmriBLL.GetALL();
            foreach (var b in isEmirleri)
            {

                if (b.Ad.ToUpper() == model.Ad.ToUpper())
                {
                    return BadRequest("Aynı isimli iş emrini birkez girebilirsiniz");
                }

            }

            var envanter = _envanterBLL.GetById(model.EnvanterId);
            var oda = _odaBLL.GetById(model.OdaId);
            isEmri.Oda = oda;
            isEmri.Envanter = envanter;
            _isEmriBLL.Update(isEmri);

            return Ok();
        }


        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var model = _isEmriBLL.GetById(id);
            model.SilindiMi = true;
            _isEmriBLL.Update(model);
            return Ok();
        }


        //[HttpGet]
        //public IActionResult List()
        //{
        //    ViewBag.IsEmirleri = _isEmriBLL.GetALL();
        //    return View(new IsEmriDTO());
        //}

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    var model = _isEmriBLL.GetById(id);
        //    model.SilindiMi = true;
        //    _isEmriBLL.Update(model);
        //    return RedirectToAction("List");
        //}

        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    var model = _isEmriBLL.GetById(id);
        //    return View(new IsEmriDTO()
        //    {
        //        ID = model.ID,
        //        Ad = model.Ad,
        //    });
        //}


    }
}
