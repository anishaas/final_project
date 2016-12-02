using Final_Project_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Final_Project_V2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        private AppSignInManager _signInManager;
        private AppUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(AppUserManager userManager, AppSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public AppSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<AppSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public AppUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: /Account/AccountSettings
        public ActionResult AccountSettings()
        {
            if (User.IsInRole("Customer"))
            {
                AppUser @customer = db.Users.Find(User.Identity.GetUserId());
                //Redirect to Customers/Edit
                return RedirectToAction("Edit", "Customers");
            }
            if (User.IsInRole("Employee"))
            {
                AppUser @employee = db.Users.Find(User.Identity.GetUserId());
                //Redirect to Employees/Edit
                return RedirectToAction("Edit", "Employees");
            }
            if (User.IsInRole("Admin"))
            {
                AppUser @admin = db.Users.Find(User.Identity.GetUserId());
                //Redirect to Employees/Edit
                return RedirectToAction("Edit", "Admins");
            }
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)//NOTE: User has been re-directed here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            AuthenticationManager.SignOut();  //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // 
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //find user to check if account is disabled

            /*CHECK THIS CODE
            AppUser user = db.Users.FirstOrDefault(x => x.Email == model.Email);          
            if (user.DisabledCustomer == true || user.DisabledEmployee == true)
            {
                //user should not be able to login
                return View("Error", new string[] { "Sorry, your account has been disabled" });
            }
            */

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Add fields to customer user here so they will be saved to the database 
                //Create a new user with all the properties you need for the class
                var user = new AppUser { Email = model.Email, LastName = model.LastName, FirstName = model.FirstName, MI = model.MI, Address = model.Address, CCNumber1 = model.CCNumber1, CCType1 = model. CCType1, CCNumber2 = model.CCNumber2, CCType2 = model.CCType2};

                //Add the new user to the database
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded) //user was created successfully
                {
                    //TODO: Once you get roles working, you may want to add users to roles upon creation
                    await UserManager.AddToRoleAsync(user.Id, "Member"); //adds user to role called "User"
                                                                         // --OR--
                                                                         //await UserManager.AddToRoleAsync(user.Id, "Employee"); //adds user to role called "Employee"

                    //sign the user in
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    //send them to the home page
                    return RedirectToAction("Index", "Home");
                }

                //if there was a problem, add the error messages to what we will display
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/RegisterCustomer
        [AllowAnonymous]
        public ActionResult RegisterCustomer()
        {
            return View();
        }

        // POST: /Account/RegisterCustomer
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterCustomer(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //DONE: Add fields to user here so they will be saved to the database 
                //Create a new user with all the properties you need for the class
                var user = new AppUser { UserName = model.Email, Email = model.Email, LastName = model.LastName, FirstName = model.FirstName, Password = model.Password, Address = model.Address, PhoneNumber = model.Phone};
                user.EmpType = "ActiveCustomerAccount";

                //Add the new user to the database
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded) //user was created successfully
                {
                    await UserManager.AddToRoleAsync(user.Id, "Customer"); //adds user to role called "Customer"
                    
                    //sign the user in
                    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    //send them to the home page
                    return View("~/Views/Home/Index.cshtml");
                }

                //if there was a problem, add the error messages to what we will display
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

       // GET: /Account/RegisterAdmin
        [Authorize(Roles = "admin")]
        public ActionResult RegisterAdmin()
        {
            return View();
        }

        // POST: /Account/RegisterAdmin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterAdmin(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //LATER: Add fields to user here so they will be saved to the database 
                //Create a new user with all the properties you need for the class
                var user = new AppUser { UserName = model.Email, Email = model.Email, LastName = model.LastName, FirstName = model.FirstName};
                user.EmpType = "Admin";
                //Add the new user to the database
                var result = await UserManager.CreateAsync(user, model.Password);



                if (result.Succeeded) //user was created successfully
                {
                    //TODO: Once you get roles working, you may want to add users to roles upon creation
                    await UserManager.AddToRoleAsync(user.Id, "Admin"); //adds user to role called "User"
                    // --OR--
                    //await UserManager.AddToRoleAsync(user.Id, "Employee"); //adds user to role called "Employee"

                    //sign the user in
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    //send them to the home page
                    return RedirectToAction("Index", "Home");
                }

                //if there was a problem, add the error messages to what we will display
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/RegisterEmployee
        [Authorize(Roles = "Admin")]
        public ActionResult RegisterEmployee()
        {
            return View();
        }

        // POST: /Account/RegisterEmployee
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterEmployee(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //LATER: Add fields to user here so they will be saved to the database 
                //Create a new user with all the properties you need for the class
                var user = new AppUser { UserName = model.Email, Email = model.Email, LastName = model.LastName, FirstName = model.FirstName};
                user.EmpType = "Employee";

                //Add the new user to the database
                var result = await UserManager.CreateAsync(user, model.Password);



                if (result.Succeeded) //user was created successfully
                {
                    //TODO: Once you get roles working, you may want to add users to roles upon creation
                    await UserManager.AddToRoleAsync(user.Id, "Employee"); //adds user to role called "User"

                    //sign the user in
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    //send them to the home page
                    return RedirectToAction("Index", "Home");
                }

                //if there was a problem, add the error messages to what we will display
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }


        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }


        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        // GET: /Account/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

       
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
