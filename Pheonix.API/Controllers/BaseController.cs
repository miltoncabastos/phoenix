using Microsoft.AspNetCore.Mvc;
using System;

namespace Pheonix.W.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
