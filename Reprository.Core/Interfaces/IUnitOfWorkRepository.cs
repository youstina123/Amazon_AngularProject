using Reprository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IBaseRepository<ApplicationUser> ApplicationUser { get; }
        IBaseRepository<Customer> Customer { get; }
        IBaseRepository<Category> Category { get; }
        IBaseRepository<Payment> Payment { get; }
        IBaseRepository<Discount> Discount { get; }
        IBaseRepository<Rate> Rate { get; }
        IBaseRepository<Order> Order { get;}
        IProfitRepository Profit { get; }
        IBaseRepository<Review> Review { get; } 
        IBaseRepository<Brand> Brand { get; }
        IAdminRepository Admin { get; }
        IStoreRepository Store { get; }
        IVendorRepository Vendor { get; }
        IProductRepository Product { get; }
        IMobileRepository Mobile { get; }
        IBookReprository Book { get; }
        IClothingRepository Clothing { get; }
        IComputerRepository Computer { get; }
        ITVRepository TV { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IWishlistRepository Wishlist { get; }
        ICardItemReposatory CardItem { get; }
    }
}
