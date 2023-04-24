using Microsoft.EntityFrameworkCore;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using Reprository.EF.Reprositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.EF.Repositories
{
    public class CardItemReposatory: BaseRepository<CartItem>,ICardItemReposatory
        {
        ApplicationDBContext context;
        public CardItemReposatory(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        

        public string GetVendorId(int cardId)
        {
            return context.CartItems
                .Where(c=>c.Id==cardId)
                .Include(c => c.MainProduct)
                .ThenInclude(p => p.Store)
                .ThenInclude(s => s.vendor)
                .Select(i=>i.MainProduct.Store.vendor.ApplicationUserId)
                .FirstOrDefault();


        }
    }
}
