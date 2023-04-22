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
    public class ComputerRepository:BaseRepository<Computer>,IComputerRepository
    {
        ApplicationDBContext context;
        public ComputerRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public void DeleteComp(int id)
        {

            Computer computer = Find(m => m.MainProductId == id, new[] { "MainProduct" });
            computer.MainProduct.IsDeleted = true;
            computer.IsDeleted = true;
            Update(computer);
        }
        public List<Computer> GetByBrandName(string brandName)
        {
            var Computer = context.Computers
              .Include(e => e.MainProduct)
              .Where(d => d.MainProduct.BrandName == brandName)
              .ToList();
            return Computer;
        }

        public List<Computer> GetByName(string Name)
        {
            var Computer = context.Computers
               .Include(e => e.MainProduct)
               .Where(d => d.MainProduct.Name == Name)
               .ToList();
            return Computer;
        }
    }
}
