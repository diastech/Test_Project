﻿using Dal.Repository;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Concrete
{
    public class BinaRepository : BaseRepository<Bina>, IBinaRepository
    {
        public BinaRepository(DiasContext diasContext) : base(diasContext)
        {

        }
    }
}
