using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Models
{
    public class WatchlistUser : IdentityUser<Guid>
    {
        public WatchlistUser()
        {
            UsersMovies = new HashSet<UserMovie>();
        }

        public virtual ICollection<UserMovie> UsersMovies { get; set; }
    }
}
