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
    public class ClothingReprository:BaseRepository<Clothing>,IClothingRepository
    {
        ApplicationDBContext context;
        public ClothingReprository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public void DeleteCloths(int id)
        {
            Clothing clothing = Find(m => m.MainProductId == id, new[] { "MainProduct" });
            clothing.MainProduct.IsDeleted = true;
            clothing.IsDeleted = true;
            Update(clothing);
        }

        public List<Clothing> GetByBradName(string BrandName)
        {
            var cloth = context.Cloths
                .Include(e => e.MainProduct)
                .Where(d => d.MainProduct.BrandName == BrandName)
                .ToList();
            return cloth;
        }

        public List<Clothing> GetByName(string Name)
        {
            var cloth = context.Cloths
               .Include(e => e.MainProduct)
               .Where(d => d.MainProduct.Name == Name)
               .ToList();
            return cloth;
        }
    }
}
