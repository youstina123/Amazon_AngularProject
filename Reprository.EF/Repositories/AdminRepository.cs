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
    public class AdminRepository:BaseRepository<Admin>,IAdminRepository
    {
        ApplicationDBContext context;
        public AdminRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public string GetAdminId()
        {
            return context.Admins.Select(a=>a.ApplicationUserId).FirstOrDefault();
        }
    }
}
