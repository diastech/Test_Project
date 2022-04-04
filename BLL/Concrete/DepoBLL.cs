using BLL.Abstract;
using Dal.Repository;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Concrete
{
    public class DepoBLL : IDepoBLL
    {
        private readonly IDepoRepository _depoRepository;

        public DepoBLL(IDepoRepository depoRepository)
        {
            _depoRepository = depoRepository;
        }

        public void Add(Depo entity)
        {
            entity.CreateDate = DateTime.Now;
            _depoRepository.Add(entity);
        }

        public void Delete(Depo entity)
        {
            _depoRepository.Delete(entity);
        }

        public List<Depo> GetALL()
        {
            //return _depoRepository.GetAll().ToList();
            //return _depoRepository.GetEx(x => x.SilindiMi == false).ToList();
            return _depoRepository.IncludeMany(x => x.Envanter).Where(x=>x.SilindiMi==false).ToList();
        }

        public Depo GetById(int Id)
        {
            return _depoRepository.GetById(Id);
        }

        public List<Depo> Search(string arananKelime)
        {
            return _depoRepository.GetEx(x => x.Ad.ToUpper().Contains(arananKelime.ToUpper())).ToList();
        }

        public void Update(Depo entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _depoRepository.Update(entity);
        }
    }
}
