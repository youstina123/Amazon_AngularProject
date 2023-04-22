using Microsoft.EntityFrameworkCore;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using Reprository.EF.Reprositories;
using System;
using System.IO;
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

        public void DeleteMobile(int id)
        {
            Mobile mobile= Find(m => m.MainProductId == id, new[] { "MainProduct" });
            mobile.MainProduct.IsDeleted = true;
            mobile.IsDeleted = true;
            Update(mobile);
        }

        //public List<Mobile> FindAllByStoreName(string storename)
        //{

        //    //List<Mobile> mobilesfilter = context.Mobiles
        //    //    .Include(m => m.MainProduct)
        //    //.ThenInclude(p => p.Store).Where(p => p.MainProduct.Store.Name == storename).ToList();


        //    List<Mobile> mobiles= (List<Mobile>)FindAll(new[] { "MainProduct" });
        //    foreach (Mobile mobile in mobiles)
        //    {

        //    }


        //    //foreach (Mobile mobile in mobilesfilter)
        //    //{
        //    //    if( mobile.MainProduct.Store != null)
        //    //    {
        //    //        if (mobile.MainProduct.Store.Name == storename)
        //    //        {
        //    //            mobiles.Add(mobile);
        //    //        }
        //    //    }
        //    //}
        //    //.ThenInclude(p => p.Store);

        //    return mobilesfilter;
        //}


    }
}
