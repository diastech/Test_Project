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
    public class OdaController : ControllerBase
    {
        private readonly IOdaBLL _odaBLL;
        private readonly IBinaBLL _binaBLL;

        public OdaController(IOdaBLL odaBLL, IBinaBLL binaBLL)
        {
            _odaBLL = odaBLL;
            _binaBLL = binaBLL;
        }


        //[HttpGet]
        //public IActionResult Index()
        //{
        //    ViewBag.Binalar = _binaBLL.GetALL();
        //    return View(new OdaDTO());
        //}

        [HttpGet("GetBinalar")]
        public async Task<IEnumerable<Bina>> GetBinalar()
        {
            var model = _binaBLL.GetALL();
            return model;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Index(OdaDTO model)
        {
            
            
            var oda = new Oda
            {
                Numara = model.Numara,
                BinaID = model.BinaID,
            };
            var odalar = _odaBLL.GetALL();
            foreach (var b in odalar)
            {
                if (b.Numara == model.Numara)
                {
                    //ViewBag.Binalar = _binaBLL.GetALL();
                    return BadRequest("Aynı Oda numarasından birkez girebilirsiniz");
                }
            }

            _odaBLL.Add(oda);

            return Ok();
        }



        [HttpGet("GetAll")]
        public async Task<IEnumerable<Oda>> GetAll()
        {

            var model = _odaBLL.GetALL();
            return model;

        }

        [HttpGet("GetById/{id}")]
        public async Task<Oda> GetById(int id)
        {

            var model = _odaBLL.GetById(id);
            return model;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(OdaDTO model)
        {

            var oda = new Oda
            {
                ID = model.ID,
                Numara = model.Numara,
                BinaID = model.BinaID
            };
            var odalar = _odaBLL.GetALL();
            foreach (var b in odalar)
            {
                if (b.Numara == model.Numara)
                {
                    return BadRequest("Aynı Oda numarasından birkez girebilirsiniz");
                }
            }
            var bina = _binaBLL.GetById(model.BinaID);
            oda.Bina = bina;
            _odaBLL.Update(oda);

            return Ok();
        }


        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var model = _odaBLL.GetById(id);
            model.SilindiMi = true;
            _odaBLL.Update(model);
            return Ok();
        }
    }
}
