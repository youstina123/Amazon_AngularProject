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
    public class VendorRepository : BaseRepository<Vendor>,IVendorRepository
    {
        ApplicationDBContext context;
        public VendorRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public string FindVendorId(int storeid)
        {
            string userid = context.Vendors.Where(m => m.StoreId == storeid).Select(m => m.ApplicationUserId).FirstOrDefault();
            return userid;
        }

        public Vendor FindVendorDetailes(string userid)
        {
            Vendor vendor = context.Vendors.Where(v => v.ApplicationUserId == userid).
                Include(h => h.Store).Include(a => a.ApplicationUser).FirstOrDefault();
            return vendor;
        }

        public Vendor GetVendor(string vendorid)
        {
            return context.Vendors
                .FirstOrDefault(v => v.ApplicationUserId == vendorid);
            
        }
    }
}


