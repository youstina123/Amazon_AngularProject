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
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        UserManager<ApplicationUser> userManager;
        public AdminController(UserManager<ApplicationUser> userManager, IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.userManager = userManager;
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        //[HttpGet("Notifications")]
        //public IActionResult NewVendorNotifications()
        //{
        //    NotificationsDetailsDTO notifications;
        //    List<NotificationsDetailsDTO> notificationsList = new List<NotificationsDetailsDTO>();

        //    List<Store> store = (List<Store>)unitOfWorkRepository.Store.FindAll(h => h.IsConfermed == false);

        //    List<string> VendorIds = new List<string>();

        //    foreach (var item in store)
        //    {
        //        string appUserId = unitOfWorkRepository.Vendor.FindVendorId(item.Id);
        //        VendorIds.Add(appUserId);
        //    }
        //    List<ApplicationUser> vendorList = new List<ApplicationUser>();

        //    foreach (var item in VendorIds)
        //    {
        //        ApplicationUser vendor = unitOfWorkRepository.ApplicationUser.GetByIDString(item);
        //        vendorList.Add(vendor);
        //    }

        //    foreach (var item in vendorList)
        //    {
        //        notifications = new NotificationsDetailsDTO();
        //        notifications.VendorName = item.UserName;
        //        notifications.PhoneNumber = item.PhoneNumber;
        //        notifications.Email = item.Email;
        //        notifications.Gender = item.gender.ToString();
        //        notifications.Id = item.Id;
        //        notificationsList.Add(notifications);

        //    }
        //    int index = 0;
        //    foreach (var item in store)
        //    {
        //                     notifications = new NotificationsDetailsDTO();
        //       

        //        notificationsList[index].StoreName = item.Name;
        //        notificationsList[index].StoreCountry = item.Country;
        //        notificationsList[index].StoreCity = item.City;
        //        notificationsList[index].StoreStreet = item.Street;
        //        notificationsList[index].StoreDescription = item.Description.ToString();
        //        index++;
        //    }

        //    return Ok(notificationsList);
        //}

        [HttpGet("VendorDetails")]
        public IActionResult NewVendorNotifications()
        {
            NotificationsDetailsDTO notifications;
            List<NotificationsDetailsDTO> notificationsList = new List<NotificationsDetailsDTO>();
            List<Store> store = (List<Store>)unitOfWorkRepository.Store.FindAll(h => h.IsConfirmed == false);
            List<Vendor> vendorList = new List<Vendor>();
            foreach (var item in store)
            {
                Vendor vendor = unitOfWorkRepository.Vendor.FindVendorDetailes(item.VendorId);
                vendorList.Add(vendor);
            }
           
            foreach (var item in vendorList)
            {
                notifications = new NotificationsDetailsDTO();
                notifications.VendorName = item.ApplicationUser.UserName;
                notifications.PhoneNumber = item.ApplicationUser.PhoneNumber;
                notifications.Email = item.ApplicationUser.Email;
                notifications.Gender = item.ApplicationUser.gender.ToString();
                notifications.Id = item.ApplicationUser.Id;
                //notifications.StoreName = item.store.Name;
                //notifications.StoreCountry = item.store.Country;
                //notifications.StoreCity = item.store.City;
                //notifications.StoreStreet = item.store.Street;
                //notifications.StoreDescription = item.store.Description.ToString();
                //notificationsList.Add(notifications);

            }
         
            return Ok(notificationsList);
        }

        [HttpGet("Stores")]
        public IActionResult Stores()
        {
            var storeList = unitOfWorkRepository.Store.FindAll(h => h.IsDeleted == false); /*new[] { "Images" }*/
            return Ok(storeList);
        }

        [HttpGet("DeleteStore")]
        public IActionResult DeleteStore(int id)
        {
            Store store = unitOfWorkRepository.Store.GetById(id);
            store.IsDeleted = true;
            unitOfWorkRepository.Store.Update(store);
            return Ok("Removed Successfully");
        }

        [HttpGet("GetStoreForUpdate")]
        public IActionResult UpdateStore(int Id)
        {
            Store store =unitOfWorkRepository.Store.GetById(Id);
            return Ok(store);
        }

        [HttpPost("UpdateStore")]
        public IActionResult UpdateStore(Store newStore)
        {   
            unitOfWorkRepository.Store.Update(newStore);
            return Ok("Updated Successfully");
        }

        [HttpGet("ConfirmVendor")]
        public async Task<IActionResult> VendorRoleConfirmation(string id)
        {
            ApplicationUser vendor = unitOfWorkRepository.ApplicationUser.GetByIDString(id);
            Store store = await unitOfWorkRepository.Store.FindAsync(h => h.VendorId == id);
            store.IsConfirmed = true;

            unitOfWorkRepository.Store.Update(store);
            await userManager.AddToRoleAsync(vendor, "Vendor");
            return Ok("Confirmed Successfully");

        }

        [HttpGet("Profit")]
        public IActionResult AdminProfit()
        {
            TotalAdminProfitDTO totalAdminProfitDTO = new TotalAdminProfitDTO();    
            List<AdminProfitDTO> adminProfitList = new List<AdminProfitDTO>();
            var payment = unitOfWorkRepository.Payment.FindAll(new[] { "store" });

            foreach (var item in payment)
            {

                AdminProfitDTO adminProfit = new AdminProfitDTO();
                adminProfit.StoreName = item.store.Name;
                adminProfit.Profit = item.Amount * 0.1;

                adminProfitList.Add(adminProfit);

                ;
            }
            double TotalProfit = 0;
            foreach (var item in adminProfitList)
            {
                {
                    TotalProfit += item.Profit;
                }
            }
            totalAdminProfitDTO.adminProfitList = adminProfitList;
            totalAdminProfitDTO.totalAdminProfit= TotalProfit;  
            return Ok(totalAdminProfitDTO);
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Category category)
        {
            unitOfWorkRepository.Category.Add(category);
            return Ok("Added Successfully");
        }

    }
}
