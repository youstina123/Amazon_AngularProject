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
    public class ComputerRepository:BaseRepository<Computer>,IComputerRepository
    {
        ApplicationDBContext context;
        public ComputerRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }
    }
}
