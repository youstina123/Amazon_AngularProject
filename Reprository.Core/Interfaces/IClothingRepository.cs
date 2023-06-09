﻿using Reprository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Interfaces
{
    public interface IClothingRepository:IBaseRepository<Clothing>
    {
        List<Clothing> GetByName(string Name);
        List<Clothing> GetByBradName(string Name);
        public void DeleteCloths(int id);
    }
}
