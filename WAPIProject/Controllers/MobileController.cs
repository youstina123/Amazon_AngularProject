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
    public class MobileController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public MobileController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        [HttpGet("GetMobiles")]
        public IActionResult GetMobiles() {
           
            return Ok(unitOfWorkRepository.Mobile.FindAll(new[] {"MainProduct"}));
        }
        [HttpGet("GetMobilebyID")]
        public async Task<IActionResult> GetMobilebyID(int id)
        {
          
            return Ok(await unitOfWorkRepository.Mobile.FindAsync(m=>m.MainProductId==id, new[] { "MainProduct" }));
        }
        [HttpPut("UpdateMobile")]
        public async Task<IActionResult> UpdateMobile( MobileDTO NewMobile)
        {
            if (ModelState.IsValid)
            {
                Mobile mobile = await unitOfWorkRepository
                    .Mobile
                    .FindAsync(m => m.MainProductId == NewMobile.Id, new[] { "MainProduct" });
                mobile.MainProduct.Name = NewMobile.Name;
                mobile.MainProduct.BrandName= NewMobile.BrandName;
                mobile.MainProduct.Description = NewMobile.Description;
                mobile.MainProduct.Price= NewMobile.Price;
                mobile.MainProduct.PriceAfterDiscount= NewMobile.PriceAfterDiscount;
                mobile.MainProduct.Quantity= NewMobile.Quantity;
                mobile.MainProduct.RateValue= NewMobile.RateValue;
                mobile.MainProduct.BrandId = NewMobile.BrandId;
                mobile.MainProduct.CategoryId = NewMobile.CategoryId;
                mobile.MainProduct.StoreId = NewMobile.StoreId;

                mobile.RAM = NewMobile.RAM;
                mobile.ScreenSize = NewMobile.ScreenSize;
                mobile.NumSIMCards= NewMobile.NumSIMCards;
                mobile.NumberOfCamera= NewMobile.NumberOfCamera;
                mobile.BatteryLife= NewMobile.BatteryLife;
                mobile.StorageCapacity= NewMobile.StorageCapacity;
                mobile.Weight= NewMobile.Weight;
                mobile.HasFingerprintScanner= NewMobile.HasFingerprintScanner;
                mobile.HasBackCamera= NewMobile.HasBackCamera;
                mobile.HasFrontCamera= NewMobile.HasFrontCamera;
                mobile.HasNFC= NewMobile.HasNFC;
                mobile.HasBluetooth= NewMobile.HasBluetooth;
                mobile.IsWaterproof= NewMobile.IsWaterproof;
                mobile.OperatingSystem=NewMobile.OperatingSystem;
                mobile.Screentype= NewMobile.Screentype;
                unitOfWorkRepository.Mobile.Update(mobile);
                return Ok("Updated");
            }
            return BadRequest(ModelState);

        }
        [HttpPost("AddMobile")]
        public async Task<IActionResult> AddMobile(MobileDTO mobile)
        {

            if (ModelState.IsValid)
            {
                MainProduct product = new MainProduct();
                product.Name = mobile.Name;
                product.BrandName= mobile.BrandName;
                product.Description = mobile.Description;
                product.Price = mobile.Price;
                product.Quantity = mobile.Quantity;
                product.RateValue = mobile.RateValue;
                product.BrandId = mobile.BrandId;
                product.CategoryId = mobile.CategoryId;
                product.StoreId = mobile.StoreId;

                await unitOfWorkRepository.Product.AddAsync(product);

                Mobile mobile1 = new Mobile();
                mobile1.MainProductId = product.Id;
                mobile1.ScreenSize = mobile.ScreenSize;
                mobile1.RAM = mobile.RAM;
                mobile1.NumSIMCards = mobile.NumSIMCards;
                mobile1.BatteryLife = mobile.BatteryLife;
                mobile1.StorageCapacity = mobile.StorageCapacity;
                mobile1.Weight = mobile.Weight;
                mobile1.HasFingerprintScanner = mobile.HasFingerprintScanner;
                mobile1.NumberOfCamera= mobile.NumberOfCamera;
                mobile1.HasFrontCamera= mobile.HasFrontCamera;
                mobile1.HasBackCamera= mobile.HasBackCamera;
                mobile1.HasNFC= mobile.HasNFC;
                mobile1.HasBluetooth= mobile.HasBluetooth;
                mobile1.IsWaterproof= mobile.IsWaterproof;
                mobile1.OperatingSystem= mobile.OperatingSystem;
                mobile1.Screentype= mobile.Screentype;

                for (int index = 0; index < mobile.Images.Count(); index++)
                {
                    using var imageStream = new MemoryStream();
                    mobile.Images[index].CopyTo(imageStream);
                    Image image = new Image();
                    image.ImageSource = imageStream.ToArray();
                    image.ProductId = product.Id;
                    unitOfWorkRepository.Image.Add(image);
                }

                await unitOfWorkRepository.Mobile.AddAsync(mobile1);

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteMobile")]
        public IActionResult DeleteMobile(int id)
        {
            try
            {
                unitOfWorkRepository.Mobile.DeleteMobile(id);

                return new StatusCodeResult(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("FilterByBattaryLife")]
        public async Task<IActionResult> FilterByBattaryLife(int min,int max )
        {
            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                    .Mobile
                    .FindAllAsync(m => m.BatteryLife >= min && m.BatteryLife <= max);
            
            return Ok(mobilesfilter);
        }

        [HttpGet("FilterByStorageCapacity")]
        public async Task<IActionResult> FilterByStorageCapacity(int storage)
        {
           List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                    .Mobile
                    .FindAllAsync(m => m.StorageCapacity==storage, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }
        [HttpGet("FilterByWeight")]
        public async Task<IActionResult> FilterByWeight(int min, int max)
        {
            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                     .Mobile
                     .FindAllAsync(m => m.Weight >= min && m.Weight <= max, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }

        [HttpGet("FilterByRAM")]
        public async Task<IActionResult> FilterByRAM(int ram)
        {
            //List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
            //         .Mobile
            //         .FindAllAsync(m => m.RAM >= min && m.RAM <= max, new[] { "MainProduct" });
            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                     .Mobile
                     .FindAllAsync(m => m.RAM ==ram, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }

        [HttpGet("FilterByPrice")]
        public async Task<IActionResult> FilterByPriceAsync(int min, int max)
        {
            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                     .Mobile
                     .FindAllAsync(m => m.MainProduct.Price >= min && m.MainProduct.Price <= max, new[] { "MainProduct" });
            //List<Mobile> mobilesfilter = (List<Mobile>) unitOfWorkRepository
            //         .Mobile
            //         .FindAll(new[] { "MainProduct" });
            //foreach(Mobile mobile in mobilesfilter)
            //{
            //    if(mobile.MainProduct.p)
            //}
            return Ok(mobilesfilter);
        }
        [HttpGet("FilterByRate")]
        public async Task<IActionResult> FilterByRate(int rate)
        {
            
            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                     .Mobile
                     .FindAllAsync(m => m.MainProduct.RateValue == (Stars)rate, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }

        [HttpGet("FilterByNumberOfCamera")]
        public async Task<IActionResult> FilterByNumberOfCamera(int number)
        {
            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(b => b.NumberOfCamera ==number, new[] { "MainProduct" });

            return Ok(mobilesfilter);
        }

        [HttpGet("FilterByNumSIMCards")]
        public async Task<IActionResult> FilterByNumSIMCards(int min, int max)
        {

            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                 .Mobile
                 .FindAllAsync(b => b.NumSIMCards >= min && b.NumSIMCards <= max, new[] { "MainProduct" });

            return Ok(mobilesfilter);
        }



        [HttpGet("FilterByOperatingSystem")]
        public async Task<IActionResult> FilterByOperatingSystem(string type)
        {

            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                 .Mobile
                 .FindAllAsync(b => b.OperatingSystem == type, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }



        [HttpGet("FilterByScreenSize")]
        public async Task<IActionResult> FilterByScreenSize(int min, int max)
        {

            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                 .Mobile
                 .FindAllAsync(b => b.ScreenSize >= min && b.ScreenSize <= max, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }


        [HttpGet("FilterByScreenType")]
        public async Task<IActionResult> FilterByScreenType(string Type)
        {
            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(b => b.Screentype.ToString() == Type, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }



        [HttpGet("FilterByHasbackCamera")]
        public async Task<IActionResult> FilterByHasbackCamera()
        {


            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(b => b.HasBackCamera == true, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }



        [HttpGet("FilterByHasFrontCamera")]
        public async Task<IActionResult> FilterByHasFrontCamera()
        {

            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(b => b.HasFrontCamera == true, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }



        [HttpGet("FilterByHasBluetooth")]
        public async Task<IActionResult> FilterByHasBluetooth()
        {
            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(b => b.HasBluetooth == true, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }



        [HttpGet("FilterByHasFingerprint")]
        public async Task<IActionResult> FilterByHasFingerprint()
        {
            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(b => b.HasFingerprintScanner == true, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }


        [HttpGet("FilterByHasNFC")]
        public async Task<IActionResult> FilterByHasNFC()
        {

            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(b => b.HasNFC == true, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }


        [HttpGet("FilterByIsWaterproof")]
        public async Task<IActionResult> FilterByIsWaterproof()
        {

            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(b => b.IsWaterproof == true, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }

        [HttpGet("FilterByBrandName")]
        public async Task<IActionResult> FilterByBrandName(string brandname)
        {

            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                 .Mobile
                 .FindAllAsync(b => b.MainProduct.BrandName==brandname, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }

        [HttpGet("FilterByStore")]
        public async Task<IActionResult> FilterByStore(string storename)
        {
            int id = unitOfWorkRepository.Store.getbyname(storename);
            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(m => m.MainProduct.StoreId == id, new[] { "MainProduct" });
            
            return Ok(mobilesfilter);
        }

        [HttpGet("FilterAllMobileDicount")]
        public async Task<IActionResult> FilterAllMobileDicount()
        {

            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                 .Mobile
                 .FindAllAsync(b => b.MainProduct.PriceAfterDiscount < b.MainProduct.Price, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }
        [HttpGet("FilterWithSpecificDiscount")]
        public async Task<IActionResult> FilterWithSpecificDiscount(int dicount)
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

           // Discount discount=unitOfWorkRepository.Discount.Find(d=>d.PercentageOff == dicount);

            List<Mobile> mobilesfilter = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(m => m.MainProduct.Discount.PercentageOff == dicount, new[] { "MainProduct" });
            return Ok(mobilesfilter);
        }

        [HttpGet("RelatedMobilesOfStor")]
        public async Task<IActionResult> RelatedMobilesOfStor(int id)
        {
            List<Mobile> topMobiles = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(m => m.MainProduct.StoreId == id, 10, null, m => m.MainProduct.RateValue, OrderBy.Descending);//, new[] { "MainProduct" });


            return Ok(topMobiles);
        }

        [HttpGet("RelatedMobilesOfBrand")]
        public async Task<IActionResult> RelatedMobilesOfBrand(string brandname)
        {
            List<Mobile> topMobiles = (List<Mobile>)await unitOfWorkRepository
                .Mobile
                .FindAllAsync(m => m.MainProduct.BrandName == brandname, 10, null, m => m.MainProduct.RateValue, OrderBy.Descending);//, new[] { "MainProduct" });


            return Ok(topMobiles);
        }

        //[HttpGet("RelatedMobilesOfCategory")]
        //public async Task<IActionResult> RelatedMobilesOfCategory()
        //{
            
        //    List<Mobile> topMobiles = (List<Mobile>)await unitOfWorkRepository
        //        .Mobile
        //        .FindAllAsync(2, null, m => m.MainProduct.RateValue, OrderBy.Descending, new[] { "MainProduct" });
        //    //List<Computer> topComputer= (List<Computer>)await unitOfWorkRepository
        //    //    .Mobile
        //    //    .FindAllAsync(2, null, m => m.MainProduct.RateValue, OrderBy.Descending, new[] { "MainProduct" });


        //    return Ok(topMobiles);
        //}

    }
}
