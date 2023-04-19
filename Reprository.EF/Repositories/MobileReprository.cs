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
    public class MobileReprository : BaseRepository<Mobile>,IMobileRepository
    {
        ApplicationDBContext context;
        public MobileReprository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }


    }
}
