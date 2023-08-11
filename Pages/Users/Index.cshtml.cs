using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic; //kullanıcı inputlarını listeeye eklemek için
using WebApplication5.models;

namespace WebApplication5.Pages.Users
{
    public class IndexModel : PageModel
    {
        public List<Usermodel> Users { get; set; }

        [BindProperty]        
        public Usermodel NewUser { get; set; }
        public void OnGet()
        {
            Users= new List<Usermodel>();

            Usermodel user1 = new Usermodel
            {
                Id = 1,
                Password = "password",
                FirstName = "mehlika",
                LastName = "köse",
                UserAddress = "suryapı",
                City = "çekmeköy",
                Country = "Türkiye",
                PhoneNo = "5301001010",
                Mail = "19soft1040@isik.edu.tr"
            };

            Usermodel user2 = new Usermodel
            {
                Id = 2,
                Password = "1234567",
                FirstName = "asya",
                LastName = "demir",
                UserAddress = "exen",
                City = "çengelköy",
                Country = "Türkiye",
                PhoneNo = "5301001013",
                Mail = "asyademir@gmaill.com"
            };

            Users.Add(user1);
            Users.Add(user2);
           


        }
        [BindProperty]
        public int UserIdToDelete { get; set; }

        [BindProperty]
        public string UserPassword { get; set; }
        [BindProperty]
        public Usermodel UpdatedUser { get; set; }

        [BindProperty]
        public int UserIdToUpdate { get; set; }

        [BindProperty]
        public string UserPasswordToUpdate { get; set; }
        public IActionResult OnPost()
        {
            
            Users = new List<Usermodel>();
            Usermodel user1 = new Usermodel
            {
                Id = 1,
                Password = "password",
                FirstName = "mehlika",
                LastName = "köse",
                UserAddress = "suryapı",
                City = "çekmeköy",
                Country = "Türkiye",
                PhoneNo = "5301001010",
                Mail = "19soft1040@isik.edu.tr"
            };

            Usermodel user2 = new Usermodel
            {
                Id = 2,
                Password = "1234567",
                FirstName = "asya",
                LastName = "demir",
                UserAddress = "exen",
                City = "çengelköy",
                Country = "Türkiye",
                PhoneNo = "5301001013",
                Mail = "asyademir@gmaill.com"
            };

            Users.Add(user1);
            Users.Add(user2);

            if (ModelState.IsValid)
            {

                Users.Add(NewUser);
                
            }

            return Page();
        }
        public IActionResult OnPostDelete()
        {
            if (UserIdToDelete > 0 && !string.IsNullOrEmpty(UserPassword))
            {

                Users = new List<Usermodel>();
                Usermodel user1 = new Usermodel
                {
                    Id = 1,
                    Password = "password",
                    FirstName = "mehlika",
                    LastName = "köse",
                    UserAddress = "suryapı",
                    City = "çekmeköy",
                    Country = "Türkiye",
                    PhoneNo = "5301001010",
                    Mail = "19soft1040@isik.edu.tr"
                };

                Usermodel user2 = new Usermodel
                {
                    Id = 2,
                    Password = "1234567",
                    FirstName = "asya",
                    LastName = "demir",
                    UserAddress = "exen",
                    City = "çengelköy",
                    Country = "Türkiye",
                    PhoneNo = "5301001013",
                    Mail = "asyademir@gmaill.com"
                };

                Users.Add(user1);
                Users.Add(user2);
                var userToDelete = Users.FirstOrDefault(u => u.Id == UserIdToDelete && u.Password == UserPassword);
                if (userToDelete != null)
                {
                    Users.Remove(userToDelete);
                }
            }

            return Page();
        }

        public IActionResult OnPostUpdateUser()
        {
            if (UserIdToUpdate > 0 && !string.IsNullOrEmpty(UserPasswordToUpdate))
            {
                Users = new List<Usermodel>();
                Usermodel user1 = new Usermodel
                {
                    Id = 1,
                    Password = "password",
                    FirstName = "mehlika",
                    LastName = "köse",
                    UserAddress = "suryapı",
                    City = "çekmeköy",
                    Country = "Türkiye",
                    PhoneNo = "5301001010",
                    Mail = "19soft1040@isik.edu.tr"
                };

                Usermodel user2 = new Usermodel
                {
                    Id = 2,
                    Password = "1234567",
                    FirstName = "asya",
                    LastName = "demir",
                    UserAddress = "exen",
                    City = "çengelköy",
                    Country = "Türkiye",
                    PhoneNo = "5301001013",
                    Mail = "asyademir@gmaill.com"
                };

                Users.Add(user1);
                Users.Add(user2);
                var userToUpdate = Users.FirstOrDefault(u => u.Id == UserIdToUpdate && u.Password == UserPasswordToUpdate);
                if (userToUpdate != null)
                {
                    userToUpdate.FirstName = UpdatedUser.FirstName;
                    userToUpdate.LastName = UpdatedUser.LastName;
                    userToUpdate.UserAddress = UpdatedUser.UserAddress;
                    userToUpdate.City = UpdatedUser.City;
                    userToUpdate.Country = UpdatedUser.Country;
                    userToUpdate.PhoneNo = UpdatedUser.PhoneNo;
                    userToUpdate.Mail = UpdatedUser.Mail;
                }
            }

            return Page();
        }

    }



    


}
