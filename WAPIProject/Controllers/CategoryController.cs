using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.EF.Repositories;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public CategoryController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            return Ok(unitOfWorkRepository.Category.GetAll());
        }
    }
}
