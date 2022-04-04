using Core.Utilities.Security.Jwt;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IUserBLL
    {
        List<User> GetALL();
        User GetById(int Id);
        List<User> Search(string arananKelime);
        //List<Depo> GetByCategoryId(int Id);
        void Add(User entity);
        void Update(User entity);
        void Delete(User entity);
        void Register(User entity);
        void Login(User entity);
        AccessToken CreateAccessToken(User user);
    }
}
