using Microsoft.AspNetCore.Identity;

namespace GalleryList.DAL.Entities
{
    public class DbRole : IdentityRole<long>
    {
        public ICollection<DbUserRole> UserRoles { get; set; }
    }
}
