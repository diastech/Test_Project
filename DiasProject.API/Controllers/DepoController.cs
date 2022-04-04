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
    public class DepoController : ControllerBase
    {
        private readonly IDepoBLL _depoBLL;
        private readonly IEnvanterBLL _envanterBLL;

        public DepoController(IDepoBLL depoBLL, IEnvanterBLL envanterBLL)
        {
            _depoBLL = depoBLL;
            _envanterBLL = envanterBLL;
        }
        [HttpGet("GetEnvanterler")]
        public async Task<IEnumerable<Envanter>> GetBinalar()
        {
            var model = _envanterBLL.GetALL();
            return model;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Index(DepoDTO model)
        {


            var depo = new Depo
            {
                Ad = model.Ad,
                EnvanterID = model.EnvanterID
            };
            var depolar = _depoBLL.GetALL();
            foreach (var b in depolar)
            {
                if (b.Ad.ToUpper() == model.Ad.ToUpper())
                {
                    if (b.EnvanterID == model.EnvanterID)
                    {
                        return BadRequest("Aynı Depo numarasından birkez girebilirsiniz");
                    }
                }
            }
            
            _depoBLL.Add(depo);

            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var model = _depoBLL.GetALL().ToList();
            List<Depo> depo = new List<Depo>();
            depo = model;
            for (int i = 0; i < depo.Count; i++)
            {
                depo[i].Envanter = _envanterBLL.GetById(depo[i].EnvanterID);
            }
            return Ok(depo);
        }

        [HttpGet("GetById/{id}")]
        public async Task<Depo> GetById(int id)
        {

            var model = _depoBLL.GetById(id);
            return model;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(DepoDTO model)
        {

            var depo = new Depo
            {
                ID = model.ID,
                Ad = model.Ad,
            };
            var envanter = _envanterBLL.GetById(model.EnvanterID);
            depo.Envanter = envanter;
            _depoBLL.Update(depo);
            return Ok();
        }


        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var model = _depoBLL.GetById(id);
            model.SilindiMi = true;
            _depoBLL.Update(model);
            return Ok();
        }        
    }
}
