using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface  IUrunYoluBLL
    {
        List<UrunYolu> GetALL();
        UrunYolu GetById(int Id);
        List<UrunYolu> Search(string arananKelime);
        //List<Bina> GetByCategoryId(int Id);
        void Add(UrunYolu entity);
        void Update(UrunYolu entity);
        void Delete(UrunYolu entity);
    }
}
