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
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public BookController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        [HttpGet("GetBooks")]
        public IActionResult GetBooks()
        {
            return Ok(unitOfWorkRepository.Book.FindAll(new[] { "MainProduct" }));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookbyID(int id)
        {

            return Ok(await unitOfWorkRepository.Book.FindAsync(m => m.MainProductId == id, new[] { "MainProduct" }));
        }
        [HttpPut("UpdateBookAsync")]
        public async Task<IActionResult> UpdateBookAsync(BookDTO NewBook)
        {
            if (ModelState.IsValid)
            {
                Book book = await unitOfWorkRepository
                    .Book
                    .FindAsync(m => m.MainProductId == NewBook.Id, new[] { "MainProduct" });
                book.MainProduct.Name = NewBook.Name;
                book.MainProduct.BrandName = NewBook.BrandName;
                book.MainProduct.Description = NewBook.Description;
                book.MainProduct.Price = NewBook.Price;
                book.MainProduct.PriceAfterDiscount = NewBook.PriceAfterDiscount;
                book.MainProduct.Quantity = NewBook.Quantity;
                book.MainProduct.RateValue = NewBook.RateValue;
                book.MainProduct.BrandId = NewBook.BrandId;
                book.MainProduct.CategoryId = NewBook.CategoryId;
                book.MainProduct.StoreId = NewBook.StoreId;

                book.Weight = NewBook.Weight;
                book.PublicationYear = NewBook.PublicationYear;
                book.PageCount = NewBook.PageCount;
                book.AuthorName = NewBook.AuthorName;
                book.BookDescription = NewBook.BookDescription;
                book.Publisher = NewBook.Publisher;
                book.Language = NewBook.Language;
                book.Edition = NewBook.Edition;
                book.Type = NewBook.Type;
                book.Awards = NewBook.Awards;
                
                unitOfWorkRepository.Book.Update(book);
                return Ok("Updated");
            }
            return BadRequest(ModelState);

        }
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(BookDTO NewBook)
        {

            if (ModelState.IsValid)
            {
                MainProduct product = new MainProduct();
                product.Name = NewBook.Name;
                product.BrandName = NewBook.BrandName;
                product.Description = NewBook.Description;
                product.Price = NewBook.Price;
                product.Quantity = NewBook.Quantity;
                product.RateValue = NewBook.RateValue;
                product.BrandId = NewBook.BrandId;
                product.CategoryId = NewBook.CategoryId;
                product.StoreId = NewBook.StoreId;

                await unitOfWorkRepository.Product.AddAsync(product);

                Book book = new Book();
                book.MainProductId = product.Id;
                book.Weight = NewBook.Weight;
                book.PublicationYear = NewBook.PublicationYear;
                book.PageCount = NewBook.PageCount;
                book.AuthorName = NewBook.AuthorName;
                book.BookDescription = NewBook.BookDescription;
                book.Publisher = NewBook.Publisher;
                book.Language = NewBook.Language;
                book.Edition = NewBook.Edition;
                book.Type = NewBook.Type;
                book.Awards = NewBook.Awards;

                await unitOfWorkRepository.Book.AddAsync(book);

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

        [HttpGet("FilterByPrice")]
        public async Task<IActionResult> FilterByPriceAsync(int min, int max)
        {
            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                     .Book
                     .FindAllAsync(m => m.MainProduct.Price >= min && m.MainProduct.Price <= max, new[] { "MainProduct" });
            
            return Ok(booksfilter);
        }

        [HttpGet("FilterByRate")]
        public async Task<IActionResult> FilterByRate(int rate)
        {

            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                     .Book
                     .FindAllAsync(m => m.MainProduct.RateValue == (Stars)rate, new[] { "MainProduct" });
            return Ok(booksfilter);
        }

        [HttpGet("FilterByPageCount")]
        public async Task<IActionResult> FilterByPageCount(int min,int max)
        {

            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                     .Book
                     .FindAllAsync(m => m.PageCount >= min && m.PageCount <= max, new[] { "MainProduct" });
            return Ok(booksfilter);
        }

        [HttpGet("FilterByAuthName")]
        public async Task<IActionResult> FilterByAuthName(string name)
        {

            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                     .Book
                     .FindAllAsync(m => m.AuthorName==name, new[] { "MainProduct" });
            return Ok(booksfilter);
        }

        [HttpGet("FilterByType")]
        public async Task<IActionResult> FilterByType(string type)
        {

            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                     .Book
                     .FindAllAsync(m => m.Type == type, new[] { "MainProduct" });
            return Ok(booksfilter);
        }

        [HttpGet("FilterByPublisher")]
        public async Task<IActionResult> FilterByPublisher(string puplisher)
        {

            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                     .Book
                     .FindAllAsync(m => m.Publisher == puplisher, new[] { "MainProduct" });
            return Ok(booksfilter);
        }

        [HttpGet("FilterByLanguage")]
        public async Task<IActionResult> FilterByLanguage(string language)
        {

            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                     .Book
                     .FindAllAsync(m => m.Language == language, new[] { "MainProduct" });
            return Ok(booksfilter);
        }

        [HttpGet("FilterByAwards")]
        public async Task<IActionResult> FilterByAwards(string awards)
        {

            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                     .Book
                     .FindAllAsync(m => m.Awards == awards, new[] { "MainProduct" });
            return Ok(booksfilter);
        }

        [HttpGet("FilterByEdition")]
        public async Task<IActionResult> FilterByEdition(string edition)
        {

            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                     .Book
                     .FindAllAsync(m => m.Edition == edition, new[] { "MainProduct" });
            return Ok(booksfilter);
        }

        [HttpGet("FilterAllBookDicount")]
        public async Task<IActionResult> FilterAllBookDicount()
        {

            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                 .Book
                 .FindAllAsync(b => b.MainProduct.PriceAfterDiscount < b.MainProduct.Price, new[] { "MainProduct" });
            return Ok(booksfilter);
        }


        [HttpGet("FilterByBrandName")]
        public async Task<IActionResult> FilterByBrandName(string brandname)
        {

            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                 .Book
                 .FindAllAsync(b => b.MainProduct.BrandName == brandname, new[] { "MainProduct" });
            return Ok(booksfilter);
        }

        [HttpGet("FilterByStore")]
        public async Task<IActionResult> FilterByStore(string storename)
        {
            int id = unitOfWorkRepository.Store.getbyname(storename);
            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                .Book
                .FindAllAsync(m => m.MainProduct.StoreId == id, new[] { "MainProduct" });

            return Ok(booksfilter);
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

            List<Book> booksfilter = (List<Book>)await unitOfWorkRepository
                .Book
                .FindAllAsync(m => m.MainProduct.Discount.PercentageOff==dicount, new[] { "MainProduct" });

            return Ok(booksfilter);
        }

        [HttpGet("RelatedBooksOfStor")]
        public async Task<IActionResult> RelatedBooksOfStor(int id)
        {
            List<Book> topBooks = (List<Book>)await unitOfWorkRepository
                .Book
                .FindAllAsync(m => m.MainProduct.StoreId == id, 10, null, m => m.MainProduct.RateValue, OrderBy.Descending);
            return Ok(topBooks);
        }

        [HttpGet("RelatedBooksOfBrand")]
        public async Task<IActionResult> RelatedBooksOfBrand(string brandname)
        {
            List<Book> topBooks = (List<Book>)await unitOfWorkRepository
                .Book
                .FindAllAsync(m => m.MainProduct.BrandName == brandname, 10, null, m => m.MainProduct.RateValue, OrderBy.Descending);


            return Ok(topBooks);
        }

        


    }
}
