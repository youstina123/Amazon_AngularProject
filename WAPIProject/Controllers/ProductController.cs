using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using Reprository.EF.Repositories;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public ProductController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpGet("FilterByCategory")]
        public async Task<IActionResult> FilterByCategory(int categoryid)
        {
            List<MainProduct> products = (List<MainProduct>)await unitOfWorkRepository
                .Product
                .FindAllAsync(m => m.CategoryId == categoryid,null);

            return Ok(products);
        }

        [HttpGet("FilterByBrandName")]
        public async Task<IActionResult> FilterByBrandName(string brandname)
        {

            List<MainProduct> products = (List<MainProduct>)await unitOfWorkRepository
                 .Product
                 .FindAllAsync(b => b.BrandName == brandname, null);
            return Ok(products);
        }
    }
}
