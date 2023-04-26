using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;

using Reprository.EF.Criteria;

using WAPIProject.DTO;

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

        [HttpPost("Addclothing")]
        public async Task<IActionResult> Addclothing(ClothingDTO Newclothing)
        {

            if (ModelState.IsValid)
            {
                MainProduct product = new MainProduct();
                product.Name = Newclothing.Name;
                product.BrandName = Newclothing.BrandName;
                product.Description = Newclothing.Description;
                product.Price = Newclothing.Price;
                product.Quantity = Newclothing.Quantity;
                product.RateValue = Newclothing.RateValue;
                product.StoreId = Newclothing.StoreId;
                product.BrandId = Newclothing.BrandId;
                product.CategoryId = Newclothing.CategoryId;
                await unitOfWorkRepository.Product.AddAsync(product);

                Clothing clothing = new Clothing();
                clothing.SleeveStyle = Newclothing.SleeveStyle;
                clothing.Style = Newclothing.Style;
                clothing.ManufacturerCountry = Newclothing.ManufacturerCountry;
                clothing.Season = Newclothing.Season;
                clothing.Gender = Newclothing.Gender;
                clothing.Size = Newclothing.Size;
                await unitOfWorkRepository.Clothing.AddAsync(clothing);
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);


        }
        [HttpPut("UpdateClothing")]
        public async Task<IActionResult> UpdateClothing(ClothingDTO Newclothing)
        {
            if (ModelState.IsValid)
            {
                Clothing clothing = await unitOfWorkRepository
                       .Clothing
                       .FindAsync(m => m.MainProductId == Newclothing.MainProductId, new[] { "MainProduct" });
                clothing.MainProduct.Name = Newclothing.Name;
                clothing.MainProduct.BrandName = Newclothing.BrandName;
                clothing.MainProduct.Description = Newclothing.Description;
                clothing.MainProduct.Price = Newclothing.Price;
                clothing.MainProduct.PriceAfterDiscount = Newclothing.PriceAfterDiscount;
                clothing.MainProduct.Quantity = Newclothing.Quantity;
                clothing.MainProduct.RateValue = Newclothing.RateValue;
                clothing.MainProduct.BrandId = Newclothing.BrandId;
                clothing.MainProduct.CategoryId = Newclothing.CategoryId;
                clothing.MainProduct.StoreId = Newclothing.StoreId;

                clothing.SleeveStyle = Newclothing.SleeveStyle;
                clothing.Style = Newclothing.Style;
                clothing.ManufacturerCountry = Newclothing.ManufacturerCountry;
                clothing.Season = Newclothing.Season;
                clothing.Gender = Newclothing.Gender;
                clothing.Size = Newclothing.Size;


                return Ok("Updated");
            }
            return BadRequest(ModelState);

        }
        [HttpDelete("DeleteClothing")]
        public IActionResult DeleteClothing(int id)
        {
            try
            {
                unitOfWorkRepository.Clothing.DeleteCloths(id);

                return new StatusCodeResult(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var clothing = await unitOfWorkRepository.Clothing.GetByIdAsync(id);

            return Ok(clothing);
        }

        [HttpGet("FilterByName")]
        public IActionResult GetByName(string Name)
        {
            var clothing = unitOfWorkRepository.Clothing.GetByName(Name);

            return Ok(clothing);
        }


        [HttpGet("FilterBrandName")]
        public IActionResult GetByBrandName(string BrandName)
        {
            var clothing = unitOfWorkRepository.Clothing.GetByBradName(BrandName);
            return Ok(clothing);
        }

        [HttpGet("FilterBySize")]
        public async Task<IActionResult> FilterBySize(string size)
        {

            List<Clothing> Clothingfilter = (List<Clothing>)await unitOfWorkRepository
                .Clothing
                .FindAllAsync(b => b.Size == size, new[] { "MainProduct" });

            return Ok(Clothingfilter);
        }

        [HttpGet("FilterByGender")]
        public async Task<IActionResult> FilterByGender(string Gender)
        {

            List<Clothing> Clothingfilter = (List<Clothing>)await unitOfWorkRepository
                .Clothing
                .FindAllAsync(b => b.Gender.ToString() == Gender, new[] { "MainProduct" });
            return Ok(Clothingfilter);
        }



        [HttpGet("FilterByStyle")]
        public async Task<IActionResult> FilterByStyle(string style)
        {

            List<Clothing> Clothingfilter = (List<Clothing>)await unitOfWorkRepository
                .Clothing
                .FindAllAsync(b => b.Style == style, new[] { "MainProduct" });
            return Ok(Clothingfilter);
        }


        [HttpGet("FilterBySeason")]
        public async Task<IActionResult> FilterBySeason(string Season)
        {

            List<Clothing> Clothingfilter = (List<Clothing>)await unitOfWorkRepository
                .Clothing
                .FindAllAsync(b => b.Season == Season, new[] { "MainProduct" });
            return Ok(Clothingfilter);
        }



        [HttpGet("FilterByManufacturerCountry")]
        public async Task<IActionResult> FilterByManufacturerCountry(string Country)
        {
            List<Clothing> Clothingfilter = (List<Clothing>)await unitOfWorkRepository
                .Clothing
                .FindAllAsync(b => b.ManufacturerCountry == Country, new[] { "MainProduct" });
            return Ok(Clothingfilter);
        }


        [HttpGet("FilterBySleeveStyle")]
        public async Task<IActionResult> FilterBySleeveStyle(string style)
        {

            List<Clothing> Clothingfilter = (List<Clothing>)await unitOfWorkRepository
                .Clothing
                .FindAllAsync(b => b.SleeveStyle == style, new[] { "MainProduct" });
            return Ok(Clothingfilter);
        }


        [HttpGet("FilterByStore")]
        public async Task<IActionResult> FilterByStore(string storename)
        {
            int id = unitOfWorkRepository.Store.getbyname(storename);
            List<Clothing> clothsfilter = (List<Clothing>)await unitOfWorkRepository
                .Clothing
                .FindAllAsync(m => m.MainProduct.StoreId == id, new[] { "MainProduct" });

            return Ok(clothsfilter);
        }

        [HttpGet("FilterWithSpecificDiscount")]
        public async Task<IActionResult> FilterWithSpecificDiscountAsync(int dicount)
        {
            #region CalculatePersent
            //List<Mobile> listwithdiscount = new List<Mobile>();

            //List<Mobile> MobilesFilter = unitOfWorkRepository.Mobile.FindAll(new[] { "MainProduct" }).ToList();

            //foreach (Mobile mobile in MobilesFilter)
            //{
            //    double rest= (double)(mobile.MainProduct.Price-mobile.MainProduct.PriceAfterDiscount);
            //    double rate = (rest / mobile.MainProduct.Price * 100);
            //    int roundrate= (int)Math.Round(rate);
            //    if(roundrate == dicount)
            //    {
            //        listwithdiscount.Add(mobile);
            //    }
            //} 
            #endregion

            List<Clothing> clothsfilter = (List<Clothing>)await unitOfWorkRepository
                .Clothing
                .FindAllAsync(m => m.MainProduct.Discount.PercentageOff == dicount, new[] { "MainProduct" });

            return Ok(clothsfilter);
        }

        [HttpGet("RelatedBooksOfStor")]
        public async Task<IActionResult> RelatedBooksOfStor(int id)
        {
            List<Clothing> topClothing = (List<Clothing>)await unitOfWorkRepository
                .Clothing
                .FindAllAsync(m => m.MainProduct.StoreId == id, 10, null, m => m.MainProduct.RateValue, OrderBy.Descending);
            return Ok(topClothing);
        }

        [HttpGet("RelatedBooksOfBrand")]
        public async Task<IActionResult> RelatedBooksOfBrand(string brandname)
        {
            List<Clothing> topClothing = (List<Clothing>)await unitOfWorkRepository
                .Clothing
                .FindAllAsync(m => m.MainProduct.BrandName == brandname, 10, null, m => m.MainProduct.RateValue, OrderBy.Descending);


            return Ok(topClothing);
        }

    }
}
