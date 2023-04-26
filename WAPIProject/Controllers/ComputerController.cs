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
    public class ComputerController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public ComputerController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        [HttpPost("AddComputer")]
        public async Task<IActionResult> AddComputer(ComputerDTO NewComputer)
        {

            if (ModelState.IsValid)
            {
                MainProduct product = new MainProduct();
                product.Name = NewComputer.Name;
                product.BrandName = NewComputer.BrandName;
                product.Description = NewComputer.Description;
                product.Price = NewComputer.Price;
                product.Quantity = NewComputer.Quantity;
                product.RateValue = NewComputer.RateValue;
                product.StoreId = NewComputer.StoreId;
                product.BrandId = NewComputer.BrandId;
                product.CategoryId = NewComputer.CategoryId;

                await unitOfWorkRepository.Product.AddAsync(product);

                Computer computer = new Computer();
                computer.RAM = NewComputer.RAM;
                computer.USBPorts = NewComputer.USBPorts;
                computer.Processor = NewComputer.Processor;
                computer.WarrantyPeriod = NewComputer.WarrantyPeriod;
                computer.GraphicsCard = NewComputer.GraphicsCard;
                computer.StorageCapacity = NewComputer.StorageCapacity;
                computer.CountryOfOrigin = NewComputer.CountryOfOrigin;
                computer.HasKeyboard = NewComputer.HasKeyboard;
                computer.HasMouse = NewComputer.HasMouse;
                computer.HasTouchscreen = NewComputer.HasTouchscreen;
                computer.HDMIOutputs = NewComputer.HDMIOutputs;
                computer.Material = NewComputer.Material;
                computer.Weight = NewComputer.Weight;
                computer.Model = NewComputer.Model;
                computer.OperatingSystem = NewComputer.OperatingSystem;

                await unitOfWorkRepository.Computer.AddAsync(computer);

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("UpdateComputer")]
        public async Task<IActionResult> UpdateComputer(ComputerDTO NewComputer)
        {
            if (ModelState.IsValid)
            {
                Computer computer = await unitOfWorkRepository
                     .Computer
                     .FindAsync(m => m.MainProductId == NewComputer.MainProductId, new[] { "MainProduct" });
                computer.MainProduct.Name = NewComputer.Name;
                computer.MainProduct.BrandName = NewComputer.BrandName;
                computer.MainProduct.Description = NewComputer.Description;
                computer.MainProduct.Price = NewComputer.Price;
                computer.MainProduct.PriceAfterDiscount = NewComputer.PriceAfterDiscount;
                computer.MainProduct.Quantity = NewComputer.Quantity;
                computer.MainProduct.RateValue = NewComputer.RateValue;
                computer.MainProduct.BrandId = NewComputer.BrandId;
                computer.MainProduct.CategoryId = NewComputer.CategoryId;
                computer.MainProduct.StoreId = NewComputer.StoreId;

                computer.RAM = NewComputer.RAM;
                computer.USBPorts = NewComputer.USBPorts;
                computer.Processor = NewComputer.Processor;
                computer.WarrantyPeriod = NewComputer.WarrantyPeriod;
                computer.GraphicsCard = NewComputer.GraphicsCard;
                computer.StorageCapacity = NewComputer.StorageCapacity;
                computer.CountryOfOrigin = NewComputer.CountryOfOrigin;
                computer.HasKeyboard = NewComputer.HasKeyboard;
                computer.HasMouse = NewComputer.HasMouse;
                computer.HasTouchscreen = NewComputer.HasTouchscreen;
                computer.HDMIOutputs = NewComputer.HDMIOutputs;
                computer.Material = NewComputer.Material;
                computer.Weight = NewComputer.Weight;
                computer.Model = NewComputer.Model;
                computer.OperatingSystem = NewComputer.OperatingSystem;


                return Ok("Updated");
            }
            return BadRequest(ModelState);

        }

        [HttpDelete("DeleteComputer")]
        public IActionResult DeleteMobile(int id)
        {
            try
            {
                unitOfWorkRepository.Computer.DeleteComp(id);

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
            var Computer = await unitOfWorkRepository.Computer.GetByIdAsync(id);

            return Ok(Computer);
        }

        [HttpGet("FilterByName")]
        public IActionResult GetByName(string Name)
        {
            var Computer = unitOfWorkRepository.Computer.GetByName(Name);
            return Ok(Computer);
        }


        [HttpGet("FilterByBrandName")]
        public IActionResult GetByBrandName(string BrandName)
        {
            var Computer = unitOfWorkRepository.Computer.GetByBrandName(BrandName);
            return Ok(Computer);
        }


        [HttpGet("FilterByWeight")]
        public async Task<IActionResult> FilterByWeight(Double wieght)
        {

            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.Weight == wieght, new[] { "MainProduct" });

            return Ok(computerFilter);
        }



        [HttpGet("FilterByRAM")]
        public async Task<IActionResult> FilterByRAM(int ram)
        {

            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.RAM == ram, new[] { "MainProduct" });

            return Ok(computerFilter);
        }


        [HttpGet("FilterByStorageCapacity")]
        public async Task<IActionResult> FilterByStorageCapacity(int Capacity)
        {

            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.StorageCapacity == Capacity, new[] { "MainProduct" });

            return Ok(computerFilter);
        }

        [HttpGet("FilterByUSBPorts")]
        public async Task<IActionResult> FilterByUSBPorts(int usb)
        {

            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.USBPorts == usb, new[] { "MainProduct" });

            return Ok(computerFilter);
        }



        [HttpGet("FilterByHDMIOutputs")]
        public async Task<IActionResult> FilterByHDMIOutputs(int HDM)
        {

            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.HDMIOutputs == HDM, new[] { "MainProduct" });

            return Ok(computerFilter);
        }


        [HttpGet("FilterByWarrantyPeriod")]
        public async Task<IActionResult> FilterByWarrantyPeriod(int Period)
        {
            //var computers = unitOfWorkRepository.Computer.FindAll(new[] { "MainProduct" });
            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.WarrantyPeriod == Period, new[] { "MainProduct" });

            return Ok(computerFilter);
        }


        [HttpGet("FilterByModel")]
        public async Task<IActionResult> FilterByModel(string Model)
        {
            //var computers = unitOfWorkRepository.Computer.FindAll(new[] { "MainProduct" });
            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.Model == Model, new[] { "MainProduct" });

            return Ok(computerFilter);
        }

        [HttpGet("FilterByProcessor")]
        public async Task<IActionResult> FilterByProcessor(string Processor)
        {
            //var computers = unitOfWorkRepository.Computer.FindAll(new[] { "MainProduct" });
            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.Processor == Processor, new[] { "MainProduct" });

            return Ok(computerFilter);
        }


        [HttpGet("FilterByGraphicsCard")]
        public async Task<IActionResult> FilterByGraphicsCard(string GraphicsCard)
        {
            //var computers = unitOfWorkRepository.Computer.FindAll(new[] { "MainProduct" });
            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.GraphicsCard == GraphicsCard, new[] { "MainProduct" });

            return Ok(computerFilter);
        }

        [HttpGet("FilterByOperatingSystem")]
        public async Task<IActionResult> FilterByOperatingSystem(string OperatingSystem)
        {
            //var computers = unitOfWorkRepository.Computer.FindAll(new[] { "MainProduct" });
            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.OperatingSystem == OperatingSystem, new[] { "MainProduct" });

            return Ok(computerFilter);
        }

        [HttpGet("FilterByMaterial")]
        public async Task<IActionResult> FilterByMaterial(string Material)
        {
            //var computers = unitOfWorkRepository.Computer.FindAll(new[] { "MainProduct" });
            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.Material == Material, new[] { "MainProduct" });

            return Ok(computerFilter);

        }

        [HttpGet("FilterByCountryOfOrigin")]
        public async Task<IActionResult> FilterByCountryOfOrigin(string Country)
        {
            //var computers = unitOfWorkRepository.Computer.FindAll(new[] { "MainProduct" });
            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.CountryOfOrigin == Country, new[] { "MainProduct" });

            return Ok(computerFilter);
        }

        [HttpGet("FilterByHasTouchscreen")]
        public async Task<IActionResult> FilterByHasTouchscreen()
        {
            //var computers = unitOfWorkRepository.Computer.FindAll(new[] { "MainProduct" });
            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.HasTouchscreen == true, new[] { "MainProduct" });

            return Ok(computerFilter);
        }

        [HttpGet("FilterByHasKeyboard")]
        public async Task<IActionResult> FilterByHasKeyboardn()
        {
            //var computers = unitOfWorkRepository.Computer.FindAll(new[] { "MainProduct" });
            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.HasKeyboard == true, new[] { "MainProduct" });

            return Ok(computerFilter);
        }

        [HttpGet("FilterByHasMouse")]
        public async Task<IActionResult> FilterByHasMouse()
        {
            //var computers = unitOfWorkRepository.Computer.FindAll(new[] { "MainProduct" });
            List<Computer> computerFilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(b => b.HasMouse == true, new[] { "MainProduct" });

            return Ok(computerFilter);
        }

        [HttpGet("FilterByStore")]
        public async Task<IActionResult> FilterByStore(string storename)
        {
            int id = unitOfWorkRepository.Store.getbyname(storename);
            List<Computer> computersfilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(m => m.MainProduct.StoreId == id, new[] { "MainProduct" });

            return Ok(computersfilter);
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

            List<Computer> computersfilter = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(m => m.MainProduct.Discount.PercentageOff == dicount, new[] { "MainProduct" });

            return Ok(computersfilter);
        }

        [HttpGet("RelatedComputersOfStor")]
        public async Task<IActionResult> RelatedComputersOfStor(int id)
        {
            List<Computer> topComputer = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(m => m.MainProduct.StoreId == id, 10, null, m => m.MainProduct.RateValue, OrderBy.Descending);
            return Ok(topComputer);
        }

        [HttpGet("RelatedComputersOfBrand")]
        public async Task<IActionResult> RelatedComputersOfBrand(string brandname)
        {
            List<Computer> topComputer = (List<Computer>)await unitOfWorkRepository
                .Computer
                .FindAllAsync(m => m.MainProduct.BrandName == brandname, 10, null, m => m.MainProduct.RateValue, OrderBy.Descending);


            return Ok(topComputer);
        }
    }
}
