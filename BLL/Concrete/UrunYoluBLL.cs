using BLL.Abstract;
using Dal.Repository;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Concrete
{
    public class UrunYoluBLL : IUrunYoluBLL
    {
        private readonly IUrunYoluRepository _urunYoluRepository;

        public UrunYoluBLL(IUrunYoluRepository urunYoluRepository)
        {
            _urunYoluRepository = urunYoluRepository;
        }

        public void Add(UrunYolu entity)
        {
            entity.CreateDate = DateTime.Now;
            _urunYoluRepository.Add(entity);
        }

        public void Delete(UrunYolu entity)
        {
            _urunYoluRepository.Delete(entity);
        }

        public List<UrunYolu> GetALL()
        {
            //return _urunYoluRepository.GetEx(x => x.SilindiMi == false).ToList();
            return _urunYoluRepository.IncludeMany(x => x.Oda, y=>y.Envanter).Where(x=>x.SilindiMi==false).ToList();
        }

        public UrunYolu GetById(int Id)
        {
            return _urunYoluRepository.GetById(Id);
        }

        public List<UrunYolu> Search(string arananKelime)
        {
            throw new NotImplementedException();
        }

        public void Update(UrunYolu entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _urunYoluRepository.Update(entity);
        }
    }
}
