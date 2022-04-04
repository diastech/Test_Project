using BLL.Abstract;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Dal.Repository;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Concrete
{
    public class UserBLL : IUserBLL
    {

        private readonly IUserRepository _userRepository;
        private ITokenHelper _tokenHelper;

        public UserBLL(IUserRepository userRepository, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }
        public void Add(User entity)
        {
            entity.CreateDate = DateTime.Now;
            _userRepository.Add(entity);
        }

        public AccessToken CreateAccessToken(User user)
        {
            var accessToken = _tokenHelper.CreateToken(user);
            return accessToken;
        }

        public void Delete(User entity)
        {
            _userRepository.Delete(entity);
        }

        public List<User> GetALL()
        {
            return _userRepository.GetEx(x => x.SilindiMi == false).ToList();
        }

        public User GetById(int Id)
        {
            return _userRepository.GetById(Id);
        }

        public void Login(User entity)
        {
            var kullanici = _userRepository.GetEx(x => x.ID == entity.ID);
        }

        public void Register(User entity)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(entity.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                KullaniciAdi = entity.KullaniciAdi,
                Password = entity.KullaniciAdi
            };
            _userRepository.Add(user);
        }

        public List<User> Search(string arananKelime)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _userRepository.Update(entity);
        }
    }
}
