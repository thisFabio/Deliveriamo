using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deliveriamo.Controllers
{
    /// <summary>
    /// TODO: Inserire authorize per generare autorizzazione per tutte le actions dei controllers.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class BaseApiController : ControllerBase
    {
    }
}
