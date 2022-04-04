using BLL.Abstract;
using Dal.Repository;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Concrete
{
    public class BinaBLL : IBinaBLL
    {
        private readonly IBinaRepository _binaRepository;

        public BinaBLL(IBinaRepository binaRepository)
        {
            _binaRepository = binaRepository;
        }

        public void Add(Bina entity)
        {
            entity.CreateDate = DateTime.Now;
            _binaRepository.Add(entity);
        }

        public void Delete(Bina entity)
        {
            _binaRepository.Delete(entity);
        }

        public List<Bina> GetALL()
        {
            //return _binaRepository.GetAll().ToList();
            return _binaRepository.GetEx(x => x.SilindiMi == false).ToList();
        }

        public Bina GetById(int Id)
        {
            return _binaRepository.GetById(Id);
        }

        public List<Bina> Search(string arananKelime)
        {
            return _binaRepository.GetEx(x => x.Ad.ToUpper().Contains(arananKelime.ToUpper())).ToList();
        }

        public void Update(Bina entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _binaRepository.Update(entity);
        }
    }
}
