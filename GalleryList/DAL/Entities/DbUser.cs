using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GalleryList.DAL.Entities
{
    public class DbUser : IdentityUser<long>
    {
       
        public ICollection<DbUserRole> UserRoles { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 250)]
        public string MiddleName { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime SignUpTime { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string AvatarUrl { get; set; }
        
        public virtual RefreshToken RefreshToken { get; set; }
    }
}
