using BLL.Abstract;
using Data.Entities;
using Dto.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiasProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrunYoluController : ControllerBase
    {
        private readonly IEnvanterBLL _envanterBLL;
        private readonly IUrunYoluBLL _urunYoluBLL;
        private readonly IOdaBLL _odaBLL;

        public UrunYoluController(IEnvanterBLL envanterBLL, IUrunYoluBLL urunYoluBLL, IOdaBLL odaBLL)
        {
            _envanterBLL = envanterBLL;
            _urunYoluBLL = urunYoluBLL;
            _odaBLL = odaBLL;
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
            var model = _envanterBLL.GetByDurum();
            return model;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Index(UrunYoluDTO model)
        {
            
            var envanter = _envanterBLL.GetById(model.EnvanterId);
            var urunYolu = new UrunYolu
            {
                Envanteradi = envanter.Ad,
                EnvanterId = model.EnvanterId,
                OdaId = model.OdaId
            };
            var envanterler = _envanterBLL.GetALL();

            _urunYoluBLL.Add(urunYolu);

            return RedirectToAction("List");
        }



        [HttpGet("GetAll")]
        public IActionResult GetAll()
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

        [HttpGet("GetById/{id}")]
        public async Task<UrunYolu> GetById(int id)
        {

            var model = _urunYoluBLL.GetById(id);
            return model;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UrunYoluDTO model)
        {
            var urunYolu = new UrunYolu
            {
                ID = model.ID,
                EnvanterId = model.EnvanterId,
                OdaId = model.OdaId,
                Envanteradi = model.Envanteradi
            };

            _urunYoluBLL.Update(urunYolu);

            return Ok();
        }


        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var model = _urunYoluBLL.GetById(id);
            model.SilindiMi = true;
            _urunYoluBLL.Update(model);
            return Ok();
        }

    }
}
