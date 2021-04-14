using EgyptExcavation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Controllers
{
    // Only logged in individuals can use this controller

    [Authorize]
    public class AccountController : Controller
    {
        // Add user manager role manager and db context in the constructor

        private UserManager<User> UserMgr { get; }
        private RoleManager<Role> RoleMgr { get; }
        private SignInManager<User> SignInMgr { get; }
        private ExcavationDbContext _context;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ExcavationDbContext cxt, RoleManager<Role> roleMgr)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
            _context = cxt;
            RoleMgr = roleMgr;
        }

        // Return the Manage users page

        public IActionResult ManageUsers()
        {

            return View(_context.Users);

        }

        // Anyone can Login

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username != null && password != null)
            { 
                var result = await SignInMgr.PasswordSignInAsync(username, password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Fail = "Username or Password was Incorrectly Entered";
                    return View();
                }
            }
            else
            {
                ViewBag.Fail = "Please Enter a Username and Password";
                return View();
            }
        }

        // Take them to the login page

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // Logout the user

        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();

            return RedirectToAction("Index", "Home");


        }
        // Only an administrator can register new Users and they are registered as Researchers

        [Authorize(Roles = "Administration")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Administration")]
        public async Task<IActionResult> Register(User user, string password)
        {
            if(ModelState.IsValid)
            {
                
                try
                {
                    user.FullName = $"{user.FirstName} {user.LastName}";
                    IdentityResult result = await UserMgr.CreateAsync(user, password);

                    await UserMgr.AddToRoleAsync(user, "Researcher");
                }
                catch
                {
                    ViewBag.Message = "Please Input a Password";
                    return View();
                }
                

                return RedirectToAction("ManageUsers", "Account");
            }

            else
            {
                return View();
            }

            
        }
        // Delete an account

        [HttpPost]
        [Authorize(Roles = "Administration")]
        public async Task<IActionResult> DeleteAccount(string ID)
        {
            User user = await UserMgr.FindByIdAsync(ID);
            await UserMgr.DeleteAsync(user);
            

            return RedirectToAction("ManageUsers", "Account");
        }

        //Edit an account

        [HttpPost]
        [Authorize(Roles = "Administration")]
        public async Task<IActionResult> EditAccount(string ID)
        {
            User user = await UserMgr.FindByIdAsync(ID);

            return View(user);
        }

        //Change password. Only Admins can do this

        [HttpPost]
        [Authorize(Roles = "Administration")]
        public async Task<IActionResult> ChangePassword(string ID)
        {
            User user = await UserMgr.FindByIdAsync(ID);

            return View(user);
        }


        [HttpPost]
        [Authorize(Roles = "Administration")]
        public async Task<IActionResult> UpdatePassword(string password, string confirmPassword, string ID)
        {
            User user = await UserMgr.FindByIdAsync(ID);
            if (password == confirmPassword)
            {
                if (password != null)
                {
                    await UserMgr.RemovePasswordAsync(user);
                    await UserMgr.AddPasswordAsync(user, password);

                    return RedirectToAction("ManageUsers", "Account");
                }
                else
                {
                    ViewBag.Message = "Please Input a Password";
                    return View("ChangePassword", user);
                }
            }
            else
            {
                ViewBag.Message = "Passwords must match!";
                return View("ChangePassword", user);
            }
        }

        // update an account

        [HttpPost]
        [Authorize(Roles = "Administration")]
        public async Task<IActionResult> UpdateAccount(User updatedUser, string ID)
        {
            if(ModelState.IsValid)
            {
                User user = await UserMgr.FindByIdAsync(ID);
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
                user.UserName = updatedUser.UserName;
                user.FullName = $"{updatedUser.FirstName} {updatedUser.LastName}";
                await UserMgr.UpdateAsync(user);

                return RedirectToAction("ManageUsers", "Account");
            }
            else
            {
                User user = await UserMgr.FindByIdAsync(ID);
                return View("EditAccount", user);
            }

        }

        // Take anyone to the Access Denied Page

        [AllowAnonymous]
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

        // Call this once when deploying the app to Initially seed the database with users

        [AllowAnonymous]
        public async Task<IActionResult> SeedUsers()
        {
            if (!_context.Roles.Any())
            {
                Role role1 = new Role();
                role1.Name = "Administration";



                IdentityResult result1 = await RoleMgr.CreateAsync(role1);
                Role role2 = new Role();



                role2.Name = "Researcher";



                IdentityResult result2 = await RoleMgr.CreateAsync(role2);
            }



            if (!_context.Users.Any())
            {
                User user1 = new User();
                user1.UserName = "GeorgePierce";
                user1.Email = "georgepierce@gmail.com";
                user1.LastName = "Pierce";
                user1.FirstName = "George";
                user1.FullName = "George Pierce";
                IdentityResult result = await UserMgr.CreateAsync(user1, "Ilove2Excavate!");
                await UserMgr.AddToRoleAsync(user1, "Administration");



                User user2 = new User();
                user2.UserName = "PaulEvans";
                user2.Email = "paulevans@gmail.com";
                user2.FirstName = "Paul";
                user2.LastName = "Evans";
                user2.FullName = "Paul Evans";
                IdentityResult result2 = await UserMgr.CreateAsync(user2, "IAlsoLove2Excavate!");
                await UserMgr.AddToRoleAsync(user2, "Administration");



                User user3 = new User();
                user3.UserName = "KerryMuhlestein";
                user3.Email = "kerrymuhlestein@gmail.com";
                user3.FirstName = "Kerry";
                user3.LastName = "Muhlestein";
                user3.FullName = "Kerry Muhlestein";
                IdentityResult result3 = await UserMgr.CreateAsync(user3, "Me3ILove2Excavate!");
                await UserMgr.AddToRoleAsync(user3, "Administration");





            }

            return RedirectToAction("Index", "Home");
        }
    }
}
