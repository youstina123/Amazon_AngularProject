using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;

using Reprository.EF.Criteria;

using System.Reflection;
using WAPIProject.DTO;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TVController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public TVController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        [HttpGet]
        public IActionResult GetTVs()
        {
            return Ok(unitOfWorkRepository.TV.FindAll(new[] { "MainProduct" }));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTVbyID(int id)
        {

            return Ok(await unitOfWorkRepository.TV.FindAsync(m => m.MainProductId == id, new[] { "MainProduct" }));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTVAsync(TVDTO NewTV)
        {
            if (ModelState.IsValid)
            {
                TV tv = await unitOfWorkRepository
                    .TV
                    .FindAsync(m => m.MainProductId == NewTV.Id, new[] { "MainProduct" });

                tv.MainProduct.Name = NewTV.Name;
                tv.MainProduct.BrandName = NewTV.BrandName;
                tv.MainProduct.Description = NewTV.Description;
                tv.MainProduct.Price = NewTV.Price;
                tv.MainProduct.PriceAfterDiscount = NewTV.PriceAfterDiscount;
                tv.MainProduct.Quantity = NewTV.Quantity;
                tv.MainProduct.RateValue = NewTV.RateValue;
                tv.MainProduct.BrandId = NewTV.BrandId;
                tv.MainProduct.CategoryId= NewTV.CategoryId;
                tv.MainProduct.StoreId= NewTV.StoreId;


                tv.ScreenSize = NewTV.ScreenSize;
                tv.NumHDMIInputs = NewTV.NumHDMIInputs;
                tv.NumUSBPorts= NewTV.NumUSBPorts;
                tv.Resolution = NewTV.Resolution;
                tv.RefreshRate = NewTV.RefreshRate;
                tv.IsSmartTV = NewTV.IsSmartTV;
                tv.Is3D = NewTV.Is3D;
                tv.HasHDR= NewTV.HasHDR;
                tv.HasEthernet= NewTV.HasEthernet;
                tv.IsCurved= NewTV.IsCurved;
                tv.HasBluetooth= NewTV.HasBluetooth;
                tv.HasWIFI= NewTV.HasWIFI;



                unitOfWorkRepository.TV.Update(tv);
                return Ok("Updated");

            }
            return BadRequest(ModelState);

        }
        [HttpPost]
        public async Task<IActionResult> AddTV(TVDTO Tv)
        {

            if (ModelState.IsValid)
            {
                MainProduct product = new MainProduct();
                product.Name = Tv.Name;
                product.BrandName = Tv.BrandName;
                product.Description = Tv.Description;
                product.Price = Tv.Price;
                product.Quantity = Tv.Quantity;
                product.RateValue = Tv.RateValue;
                product.BrandId = Tv.BrandId;
                product.CategoryId = Tv.CategoryId;
                product.StoreId = Tv.StoreId;

                await unitOfWorkRepository.Product.AddAsync(product);
                TV tv = new TV();
                tv.MainProductId = product.Id;
                tv.ScreenSize = Tv.ScreenSize;
                tv.ScreenSize = Tv.ScreenSize;
                tv.NumHDMIInputs = Tv.NumHDMIInputs;
                tv.NumUSBPorts = Tv.NumUSBPorts;
                tv.Resolution = Tv.Resolution;
                tv.RefreshRate = Tv.RefreshRate;
                tv.IsSmartTV = Tv.IsSmartTV;
                tv.Is3D = Tv.Is3D;
                tv.HasHDR = Tv.HasHDR;
                tv.HasEthernet = Tv.HasEthernet;
                tv.IsCurved = Tv.IsCurved;
                tv.HasBluetooth = Tv.HasBluetooth;
                tv.HasWIFI = Tv.HasWIFI;

                await unitOfWorkRepository.TV.AddAsync(tv);

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteMobile")]
        public IActionResult DeleteMobile(int id)
        {
            try
            {
                unitOfWorkRepository.TV.DeleteMobile(id);

                return new StatusCodeResult(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("FilterByBrandName")]
        public async Task<IActionResult> FilterByBrandName(string brandname)
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                 .TV
                 .FindAllAsync(b => b.MainProduct.BrandName == brandname, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }
        [HttpGet("FilterByPrice")]
        public async Task<IActionResult> FilterByPriceAsync(int min, int max)
        {
            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.MainProduct.Price >= min && m.MainProduct.Price <= max, new[] { "MainProduct" });
            
            return Ok(tvsfilter);
        }

        [HttpGet("FilterByRate")]
        public async Task<IActionResult> FilterByRate(int rate)
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.MainProduct.RateValue == (Stars)rate, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }

        [HttpGet("FilterByScreenSize")]
        public async Task<IActionResult> FilterByScreenSize(int min, int max)
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                 .TV
                 .FindAllAsync(b => b.ScreenSize >= min && b.ScreenSize <= max, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }
        [HttpGet("FilterByNumHDMIInputs")]
        public async Task<IActionResult> FilterByNumHDMIInputs(int inputes)
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.NumHDMIInputs == inputes, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }

        [HttpGet("FilterByNumUSBPorts")]
        public async Task<IActionResult> FilterByNumUSBPorts(int ports)
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.NumUSBPorts == ports, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }

        [HttpGet("FilterByResolution")]
        public async Task<IActionResult> FilterByResolution(int resolution)
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.Resolution == resolution, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }

        [HttpGet("FilterByRefreshRate")]
        public async Task<IActionResult> FilterByRefreshRate(int rate)
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.RefreshRate == rate, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }

        [HttpGet("FilterByIsSmartTV")]
        public async Task<IActionResult> FilterByIsSmartTV()
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.IsSmartTV == true, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }

        [HttpGet("FilterByIs3D")]
        public async Task<IActionResult> FilterByIs3D()
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.Is3D == true, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }

        [HttpGet("FilterByHasHDR")]
        public async Task<IActionResult> FilterByHasHDR()
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.HasHDR == true, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }

        [HttpGet("FilterByHasEthernet")]
        public async Task<IActionResult> FilterByHasEthernet()
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.HasEthernet == true, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }

        [HttpGet("FilterByIsCurved")]
        public async Task<IActionResult> FilterByIsCurved()
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.IsCurved == true, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }
        [HttpGet("FilterByHasBluetooth")]
        public async Task<IActionResult> FilterByHasBluetooth()
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.HasBluetooth == true, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }

        [HttpGet("FilterByHasWIFI")]
        public async Task<IActionResult> FilterByHasWIFI()
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                     .TV
                     .FindAllAsync(m => m.HasWIFI == true, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }

        [HttpGet("FilterAllTVDicount")]
        public async Task<IActionResult> FilterAllTVDicount()
        {

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                 .TV
                 .FindAllAsync(b => b.MainProduct.PriceAfterDiscount < b.MainProduct.Price, new[] { "MainProduct" });
            return Ok(tvsfilter);
        }


        [HttpGet("FilterByStore")]
        public async Task<IActionResult> FilterByStore(string storename)
        {
            int id = unitOfWorkRepository.Store.getbyname(storename);
            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                .TV
                .FindAllAsync(m => m.MainProduct.StoreId == id, new[] { "MainProduct" });

            return Ok(tvsfilter);
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

            List<TV> tvsfilter = (List<TV>)await unitOfWorkRepository
                .TV
                .FindAllAsync(m => m.MainProduct.Discount.PercentageOff == dicount, new[] { "MainProduct" });

            return Ok(tvsfilter);
        }

        [HttpGet("RelatedTvsOfStor")]
        public async Task<IActionResult> RelatedTvsOfStor(int id)
        {
            List<TV> topTVs = (List<TV>)await unitOfWorkRepository
                .TV
                .FindAllAsync(m => m.MainProduct.StoreId == id, 10, null, m => m.MainProduct.RateValue, OrderBy.Descending);
            return Ok(topTVs);
        }

        [HttpGet("RelatedTvsOfBrand")]
        public async Task<IActionResult> RelatedTvsOfBrand(string brandname)
        {
            List<TV> topTVs = (List<TV>)await unitOfWorkRepository
                .TV
                .FindAllAsync(m => m.MainProduct.BrandName == brandname, 10, null, m => m.MainProduct.RateValue, OrderBy.Descending);


            return Ok(topTVs);
        }
    }
}
