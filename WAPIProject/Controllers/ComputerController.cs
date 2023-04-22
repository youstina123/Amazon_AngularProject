using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public ComputerController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        [HttpGet]
        public IActionResult GetComputers()
        {
            return Ok(unitOfWorkRepository.Computer.FindAll(new[] { "MainProduct" }));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetComputerbyID(int id)
        {

            return Ok(await unitOfWorkRepository.Computer.FindAsync(m => m.MainProductId == id, new[] { "MainProduct" }));
        }
        [HttpPut]
        public IActionResult UpdateComputer(Computer NewComputer)
        {
            if (ModelState.IsValid)
            {
                unitOfWorkRepository.Computer.Update(NewComputer);
                return Ok("Updated");
            }
            return BadRequest(ModelState);

        }
        [HttpPost]
        public async Task<IActionResult> AddComputer(Computer computer)
        {

            if (ModelState.IsValid)
            {
                await unitOfWorkRepository.Computer.AddAsync(computer);

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);


        }
    }
}
