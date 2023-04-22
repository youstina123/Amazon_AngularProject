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
    public class BookRepository:BaseRepository<Book>,IBookReprository
    {
        ApplicationDBContext context;
        public BookRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }
        public void DeleteMobile(int id)
        {
            Book book = Find(m => m.MainProductId == id, new[] { "MainProduct" });
            book.MainProduct.IsDeleted = true;
            book.IsDeleted = true;
            Update(book);
        }
    }
}
