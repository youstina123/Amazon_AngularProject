using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public ClothingController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        [HttpGet]
        public IActionResult GetClothies()
        {
            return Ok(unitOfWorkRepository.Clothing.FindAll(new[] { "MainProduct" }));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClothebyID(int id)
        {

            return Ok(await unitOfWorkRepository.Clothing.FindAsync(m => m.MainProductId == id, new[] { "MainProduct" }));
        }
        [HttpPut]
        public IActionResult UpdateCloth(Clothing NewCloth)
        {
            if (ModelState.IsValid)
            {
                unitOfWorkRepository.Clothing.Update(NewCloth);
                return Ok("Updated");
            }
            return BadRequest(ModelState);

        }
        [HttpPost]
        public async Task<IActionResult> AddCloth(Clothing Cloth)
        {

            if (ModelState.IsValid)
            {
                await unitOfWorkRepository.Clothing.AddAsync(Cloth);

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);


        }
    }
}
