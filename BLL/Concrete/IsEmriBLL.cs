using BLL.Abstract;
using Dal.Repository;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Concrete
{
    public class IsEmriBLL : IIsEmriBLL
    {
        private readonly IIsEmriRepository _isEmriRepository;

        public IsEmriBLL(IIsEmriRepository isEmriRepository)
        {
            _isEmriRepository = isEmriRepository;
        }

        public void Add(IsEmri entity)
        {
            entity.CreateDate = DateTime.Now;
            _isEmriRepository.Add(entity);
        }

        public void Delete(IsEmri entity)
        {
            _isEmriRepository.Delete(entity);
        }

        public List<IsEmri> GetALL()
        {
            //return _isEmriRepository.GetAll().ToList();
            //return _isEmriRepository.GetEx(x => x.SilindiMi == false).ToList();
            return _isEmriRepository.IncludeMany(x => x.Envanter,y=>y.Oda).Where(x=>x.SilindiMi==false).ToList();
        }

        public IsEmri GetById(int Id)
        {
            return _isEmriRepository.GetById(Id);
        }

        public List<IsEmri> Search(string arananKelime)
        {
            return _isEmriRepository.GetEx(x => x.Ad.ToUpper().Contains(arananKelime.ToUpper())).ToList();
        }

        public void Update(IsEmri entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _isEmriRepository.Update(entity);
        }
    }
}
