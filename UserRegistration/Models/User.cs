using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace UserRegistration.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
    }

    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}