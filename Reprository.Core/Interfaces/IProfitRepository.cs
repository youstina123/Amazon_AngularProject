using Reprository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Interfaces
{
    public interface IProfitRepository:IBaseRepository<Profit>
    {
        public List<Profit> GetAdminProfits();

        public List<Profit> GetVendorProfits(string id);
    }
}
