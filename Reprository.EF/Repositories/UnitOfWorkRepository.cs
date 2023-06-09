﻿using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using Reprository.EF.Reprositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.EF.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public ApplicationDBContext context;

        public IBaseRepository<ApplicationUser> ApplicationUser { get; private set; }
        public IBaseRepository<Customer> Customer { get; private set; }
        public IBaseRepository<Category> Category { get; private set; }
        public IBaseRepository<Image> Image { get; private set; }
        public IProductRepository Product { get; private set; }   
        public IProfitRepository Profit { get; private set; }
        public IStoreRepository Store { get; private set; }
        public IVendorRepository Vendor { get; private set; }
        public IBaseRepository<Payment> Payment { get; private set; }
        public IBaseRepository<Rate> Rate { get; private set; }

        public IMobileRepository Mobile { get; private set; }
        public IBookReprository Book { get; private set; }
        public IClothingRepository Clothing { get; private set; }

        public IComputerRepository Computer { get; private set; }
        public ITVRepository TV { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IWishlistRepository Wishlist { get; private set; }
        public ICardItemReposatory CardItem { get; private set; }
        public IBaseRepository<Order> Order { get; private set; }
        public IBaseRepository<Review> Review { get; private set; }
        public IAdminRepository Admin { get; private set; }

        public IBaseRepository<Discount> Discount { get; private set; }

        public IBaseRepository<Brand> Brand { get; private set; }

        public UnitOfWorkRepository(ApplicationDBContext context)
        {
            this.context = context;

            ApplicationUser = new BaseRepository<ApplicationUser>(this.context);
            Customer = new BaseRepository<Customer>(this.context);
            Category = new BaseRepository<Category>(this.context);
            Payment = new BaseRepository<Payment>(this.context);
            Store = new StoreRepository(this.context);    
            Vendor = new VendorRepository(this.context);    
            Product = new ProductRepository(this.context);
            Mobile = new MobileReprository(this.context);
            Book = new BookRepository(this.context);
            Clothing = new ClothingReprository(this.context);
            Computer=new ComputerRepository(this.context);
            TV=new TVRepository(this.context);
            ShoppingCart = new ShoppingCartRepository(this.context);
            Wishlist = new WishlistRepository(this.context);
            CardItem= new CardItemReposatory(this.context);
            Rate=new BaseRepository<Rate>(this.context);
            Order=new BaseRepository<Order>(this.context);
            Admin=new AdminRepository(this.context);
            Profit=new ProfitRepository(this.context);
            Review= new BaseRepository<Review>(this.context);
            Discount=new BaseRepository<Discount>(this.context);
            Image=new BaseRepository<Image>(this.context);
            Brand=new BaseRepository<Brand>(this.context);

        }
        public void Complete()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
