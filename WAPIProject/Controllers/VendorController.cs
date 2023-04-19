using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public VendorController( IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(MainProduct product)
        {
            unitOfWorkRepository.Product.AddAsync(product); 
            return Ok("Added Successfully");
        }
    }
}
