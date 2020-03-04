using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mmu.IdentityProvider.TestApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var tra = User.Claims.Select(
                f => new
                {
                    f.Type,
                    f.Value
                }).ToList();

            return new JsonResult(tra);
        }

        [HttpGet("write")]
        [Authorize(Policy = "WritePolicy")]
        public IActionResult GetNeedsWriteAccess()
        {
            var tra = User.Claims.Select(
                f => new
                {
                    f.Type,
                    f.Value
                }).ToList();

            return new JsonResult(tra);
        }
    }
}