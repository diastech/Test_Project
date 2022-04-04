using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IEnvanterBLL
    {
        List<Envanter> GetALL();
        List<Envanter> GetByDurum();
        Envanter GetById(int Id);
        List<Envanter> Search(string arananKelime);
        //List<Envanter> GetByCategoryId(int Id);
        void Add(Envanter entity);
        void Update(Envanter entity);
        void Delete(Envanter entity);
    }
}
