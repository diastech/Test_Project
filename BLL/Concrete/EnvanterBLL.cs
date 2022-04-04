using BLL.Abstract;
using Dal.Repository;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Concrete
{
    public class EnvanterBLL : IEnvanterBLL
    {
        private readonly IEnvanterRepository _envanterRepository;

        public EnvanterBLL(IEnvanterRepository envanterRepository)
        {
            _envanterRepository = envanterRepository;
        }

        public void Add(Envanter entity)
        {
            entity.CreateDate = DateTime.Now;
            _envanterRepository.Add(entity);
        }

        public void Delete(Envanter entity)
        {
            _envanterRepository.Delete(entity);
        }

        public List<Envanter> GetALL()
        {
            //return _envanterRepository.GetAll().ToList();
            return _envanterRepository.GetEx(x => x.SilindiMi == false && x.Durum==0).ToList();
        }

        public List<Envanter> GetByDurum()
        {
            return _envanterRepository.GetEx(x => x.SilindiMi == false && x.Durum==1).ToList();
        }

        public Envanter GetById(int Id)
        {
            return _envanterRepository.GetById(Id);
        }

        public List<Envanter> Search(string arananKelime)
        {
            return _envanterRepository.GetEx(x => x.Ad.ToUpper().Contains(arananKelime.ToUpper())).ToList();
        }

        public void Update(Envanter entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _envanterRepository.Update(entity);
        }
    }
}
