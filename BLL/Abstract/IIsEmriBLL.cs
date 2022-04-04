using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IIsEmriBLL
    {
        List<IsEmri> GetALL();
        IsEmri GetById(int Id);
        List<IsEmri> Search(string arananKelime);
        //List<IsEmri> GetByCategoryId(int Id);
        void Add(IsEmri entity);
        void Update(IsEmri entity);
        void Delete(IsEmri entity);
    }
}
