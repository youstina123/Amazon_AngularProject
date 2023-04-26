using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using WAPIProject.DTO;

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

        [HttpGet("GetVendorProfit")]
        public IActionResult GetVendorProfit(string vendorid)
        {
            List<Profit> profitList = unitOfWorkRepository.Profit.GetVendorProfits(vendorid);
            VendorTotalProfitDTO vendorTotalProfit = new VendorTotalProfitDTO();
            foreach (Profit profit in profitList)
            {
                VendeorProfitDTO vendeorProfitDTO = new VendeorProfitDTO();
                vendeorProfitDTO.Profit = profit.VendorProfitValue;
                vendeorProfitDTO.ProfitDate = profit.ProfitDate;
                vendeorProfitDTO.Price = profit.MainProduct.Price;
                vendeorProfitDTO.PriceAfterDiscount = profit.MainProduct.PriceAfterDiscount;
                vendeorProfitDTO.ProductName = profit.MainProduct.Name;
                if(profit.MainProduct.Discount != null)
                {
                    vendeorProfitDTO.Discount = profit.MainProduct.Discount.PercentageOff;
                }
                else
                {
                    vendeorProfitDTO.Discount = 0;

                }
                vendorTotalProfit.profitList.Add(vendeorProfitDTO);
            }
            Vendor vendor = unitOfWorkRepository.Vendor.GetVendor(vendorid);
            vendorTotalProfit.TotalProfit = vendor.TotalProfit;
            return Ok(vendorTotalProfit.profitList);
        }

        [HttpPost("AddDiscount")]
        public IActionResult AddDiscount(DiscountDTO newDescount)
        {
            if (ModelState.IsValid) { 

            Discount discount = new Discount();
            discount.StartDate = newDescount.StartDate;
            discount.EndDate = newDescount.EndDate;
            discount.PercentageOff = newDescount.PercentageOff;
            discount.VendorId = newDescount.VendorId;
            discount.MainProductId = newDescount.MainProductId;

            unitOfWorkRepository.Discount.Add(discount);

            MainProduct mainProduct = unitOfWorkRepository.Product.GetById(newDescount.MainProductId);
            mainProduct.PriceAfterDiscount = mainProduct.Price - (mainProduct.Price * (newDescount.PercentageOff/100));
            mainProduct.DiscountId = discount.Id;

            unitOfWorkRepository.Product.Update(mainProduct);
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }
    }
}
