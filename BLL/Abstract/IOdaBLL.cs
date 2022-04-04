using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IOdaBLL
    {
        List<Oda> GetALL();
        Oda GetById(int Id);
        List<Oda> Search(string arananKelime);
        //List<Oda> GetByCategoryId(int Id);
        void Add(Oda entity);
        void Update(Oda entity);
        void Delete(Oda entity);
    }
}
