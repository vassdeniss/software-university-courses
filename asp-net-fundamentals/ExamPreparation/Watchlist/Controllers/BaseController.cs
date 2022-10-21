using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Watchlist.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
