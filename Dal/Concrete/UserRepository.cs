using Dal.Repository;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DiasContext diasContext) : base(diasContext)
        {

        }
    }
}
