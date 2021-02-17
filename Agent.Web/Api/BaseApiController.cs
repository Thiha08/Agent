using Microsoft.AspNetCore.Mvc;

namespace Agent.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
