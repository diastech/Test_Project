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
    public class BinaController : ControllerBase
    {
        private readonly IBinaBLL _binaBLL;

        public BinaController(IBinaBLL binaBLL)
        {
            _binaBLL = binaBLL;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Index()
        {
            var model = _binaBLL.GetALL();
            return Ok();
        }


        [HttpPost("add")]
        public async Task<IActionResult> Index(BinaDTO model)
        {
           

            var bina = new Bina
            {
                Ad = model.Ad,
                Numara = model.Numara
            };
            var binalar = _binaBLL.GetALL();
            foreach (var b in binalar)
            {
                if (b.Ad.ToUpper() == model.Ad.ToUpper())
                {
                    return BadRequest("Aynı Bina isminden birkez girebilirsiniz");
                }
            }

            _binaBLL.Add(bina);

            return Ok();

        }


        [HttpGet("GetAll")]
        public async Task<IEnumerable<Bina>> GetAll()
        {

            var model = _binaBLL.GetALL();
            return model;
            
        }

        
        
        [HttpGet("GetById/{id}")]
        public async Task<Bina> GetById(int id)
        {

            var model = _binaBLL.GetById(id);
            return model;
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var model = _binaBLL.GetById(id);
            model.SilindiMi = true;
            _binaBLL.Update(model);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(BinaDTO model)
        {


            var bina = new Bina
            {
                ID = model.ID,
                Ad = model.Ad,
                Numara = model.Numara
            };
            var binalar = _binaBLL.GetALL();
            foreach (var b in binalar)
            {
                if (b.ID == model.ID)
                {
                    if (b.Ad.ToUpper() == model.Ad.ToUpper())
                    {
                        _binaBLL.Update(bina);
                    }
                    else
                    {
                        if (b.Ad.ToUpper() == model.Ad.ToUpper())
                        {
                            return BadRequest("Aynı Bina isminden birkez girebilirsiniz");
                        }
                    }

                }

            }
            return Ok();
        }
    }
}
