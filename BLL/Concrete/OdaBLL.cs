using BLL.Abstract;
using Dal.Repository;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Concrete
{
    public class OdaBLL : IOdaBLL
    {
        private readonly IOdaRepository _odaRepository;

        public OdaBLL(IOdaRepository odaRepository)
        {
            _odaRepository = odaRepository;
        }

        public void Add(Oda entity)
        {
            entity.CreateDate = DateTime.Now;
            _odaRepository.Add(entity);
        }

        public void Delete(Oda entity)
        {
            _odaRepository.Delete(entity);
        }

        public List<Oda> GetALL()
        {
            //return _odaRepository.GetAll().ToList();
            return _odaRepository.IncludeMany(x => x.Bina).Where(x => x.SilindiMi == false).ToList();
            //return _odaRepository.GetEx(x => x.SilindiMi == false).ToList();
        }

        public Oda GetById(int Id)
        {
            return _odaRepository.GetById(Id);
        }

        public List<Oda> Search(string arananKelime)
        {
            return null;
        }

        public void Update(Oda entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _odaRepository.Update(entity);
        }
    }
}
