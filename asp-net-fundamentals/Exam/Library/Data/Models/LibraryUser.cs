using Microsoft.AspNetCore.Identity;

namespace Library.Data.Models
{
    public class LibraryUser : IdentityUser<Guid>
    {
        public LibraryUser()
        {
            this.LibraryUsersBooks = new HashSet<LibraryUserBook>();
        }

        public virtual ICollection<LibraryUserBook> LibraryUsersBooks { get; set; }
    }
}
