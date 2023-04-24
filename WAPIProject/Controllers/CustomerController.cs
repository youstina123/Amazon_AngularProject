using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using WAPIProject.DTO;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public CustomerController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpPost("MakeRate")]
        public async Task<IActionResult> MakeRate(RateDTO rateDTO)
        {
            if (ModelState.IsValid)
            {
                Rate rate = new Rate();
                rate.stars = (Stars)rateDTO.Ratevalue;
                rate.CustomerId = rateDTO.CustomerId;
                rate.MainProductId = rateDTO.MainProductId;

                unitOfWorkRepository.Rate.Add(rate);

                List<Rate> rates = (List<Rate>)await unitOfWorkRepository
                    .Rate
                    .FindAllAsync(r => r.MainProductId == rateDTO.MainProductId);
                int TotalRate = 0;
                foreach (var item in rates)
                {
                    TotalRate += Convert.ToInt32(item.stars);
                }
                MainProduct product = unitOfWorkRepository.Product.GetById(rateDTO.MainProductId);
                product.RateValue = (Stars)(TotalRate / (rates.Count()));

                unitOfWorkRepository.Product.Update(product);

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRate(RateDTO rateDTO)
        {
            if (ModelState.IsValid)
            {
                Rate rate=await unitOfWorkRepository
                    .Rate
                    .FindAsync(r=>r.CustomerId==rateDTO.CustomerId);

                rate.stars = (Stars)rateDTO.Ratevalue;

                unitOfWorkRepository.Rate.Update(rate);

                List<Rate> rates = (List<Rate>)await unitOfWorkRepository
                    .Rate
                    .FindAllAsync(r => r.MainProductId == rateDTO.MainProductId);
                int TotalRate = 0;
                foreach (var item in rates)
                {
                    TotalRate += Convert.ToInt32(item.stars);
                }
                MainProduct product = unitOfWorkRepository.Product.GetById(rateDTO.MainProductId);
                product.RateValue = (Stars)(TotalRate / (rates.Count()));

                unitOfWorkRepository.Product.Update(product);

                return Ok("Update");
            }
            return BadRequest(ModelState);

        }



    }
}
