using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IDepoBLL
    {
        List<Depo> GetALL();
        Depo GetById(int Id);
        List<Depo> Search(string arananKelime);
        //List<Depo> GetByCategoryId(int Id);
        void Add(Depo entity);
        void Update(Depo entity);
        void Delete(Depo entity);
    }
}
