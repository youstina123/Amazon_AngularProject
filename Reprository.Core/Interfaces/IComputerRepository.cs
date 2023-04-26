using Reprository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Interfaces
{
    public interface IComputerRepository:IBaseRepository<Computer>
    {
        List<Computer> GetByName(string Name);
        List<Computer> GetByBrandName(string brandName);

        public void DeleteComp(int id);
    }
}
