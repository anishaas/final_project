using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//DONE: Change the namespace here to match your project's name
namespace Final_Project_V2.Models
{
    // You can add profile data for the user by adding more properties to your AppUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /* @PF
     * I've edited the AppUser class to account for employees, customers, and managers to make our
     * usage of identity easier.
     **/
    public class AppUser : IdentityUser
    {
        //LATER: Put any additional fields that you need for your users here
        //For example:
        //[Key]
        //public string UserID { get; set; }
        
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MI { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string CCNumber1 { get; set; }
        public string CCType1 { get; set; }
        public string CCNumber2 { get; set; }
        public string CCType2 { get; set; }
        public string SSN { get; set; }
        public string EmpType { get; set; }
        public bool ActiveCustomer { get; set; }
        //Navigational Properties
        //public virtual List<Event> Events { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    //NOTE: Here is your dbContext for the entire project.  There should only be ONE DbContext per project
    //Your dbContext (AppDbContext) inherits from IdentityDbContext, which inherits from the "regular" DbContext
    //DONE: If you have an existing dbContext (it may be in your DAL folder), DELETE THE EXISTING dbContext

    public class AppDbContext : IdentityDbContext<AppUser>
    {
        //LATER: Add your dbSets here.  As an example, I've included one for products
        //Remember - the IdentityDbContext already contains a db set for Users.  If you add another one, your code will break
        //public DbSet<Product> Products { get; set; }
                
        public AppDbContext()
            : base("MyDbConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<UserActivityInput> UserActivityInputs { get; set; }
        public DbSet<UserActivityClassification> UserActivityClassification { get; set; }


        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
        
        //Add dbSet for roles
         public DbSet<AppRole> AppRoles { get; set; }

        //public System.Data.Entity.DbSet<Final_Project_V2.Models.AppUser> AppUsers { get; set; }

        // public System.Data.Entity.DbSet<Final_Project_V2.Models.AppUser> AppUsers { get; set; }
    }
}
