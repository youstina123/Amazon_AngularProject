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
    public class ProfitRepository:BaseRepository<Profit>,IProfitRepository
    {
        ApplicationDBContext context;
        public ProfitRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public List<Profit> GetAdminProfits()
        {
            return context.Profits
                .Include(p => p.MainProduct)
                .ThenInclude(p => p.Store).ToList();
        }

        public List<Profit> GetVendorProfits(string id)
        {
            return context.Profits
                .Where(p=>p.VendorId == id)
                .Include(p=>p.MainProduct)
                .ThenInclude(p=>p.Discount)
                .ToList();
        }
    }
}
