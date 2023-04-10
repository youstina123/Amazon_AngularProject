using Reprository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Interfaces
{
    public interface IVendorRepository : IBaseRepository<Vendor>
    {
         string FindVendorId(int storeid);
         Vendor FindVendorDetailes(string userid);
    }
}
