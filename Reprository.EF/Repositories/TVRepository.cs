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
    public class TVRepository:BaseRepository<TV>,ITVRepository
    {
        ApplicationDBContext context;
        public TVRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public void DeleteMobile(int id)
        {
            TV tv = Find(m => m.MainProductId == id, new[] { "MainProduct" });
            tv.MainProduct.IsDeleted = true;
            tv.IsDeleted = true;
            Update(tv);
        }
    }
}
