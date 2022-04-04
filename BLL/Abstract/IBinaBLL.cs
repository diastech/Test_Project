using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IBinaBLL
    {
        List<Bina> GetALL();
        Bina GetById(int Id);
        List<Bina> Search(string arananKelime);
        //List<Bina> GetByCategoryId(int Id);
        void Add(Bina entity);
        void Update(Bina entity);
        void Delete(Bina entity);
    }
}
