﻿using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using Reprository.EF.Reprositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.EF.Repositories
{
    public class ShoppingCartRepository: BaseRepository<ShoppingCart>,IShoppingCartRepository
    {
        ApplicationDBContext context;
        public ShoppingCartRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public int GetCustomerID(string id)
        {
            int castomerid = context.shoppingCarts
                .Where(s => s.CustomerId == id)
                .Select(c => c.Id).FirstOrDefault();

            return castomerid;
        }
    }
}
