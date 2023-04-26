using Reprository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Interfaces
{
    public interface IBookReprository:IBaseRepository<Book>
    {
        public void DeleteMobile(int id);

    }
}
