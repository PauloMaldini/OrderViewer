using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace OrderViewer.API.Base
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly string _allowedMethods;

        protected ApiControllerBase(string allowedMethods = "GET,POST")
        {
            _allowedMethods = allowedMethods;
            if (!_allowedMethods.Split(',').Contains("OPTIONS"))
            {
                _allowedMethods = $"{_allowedMethods},OPTIONS";
            }
        }
        
        [ProducesResponseType(typeof(void), 200)]
        [HttpOptions]
        public ActionResult Options()
        {
            Response.Headers["Allow"] = _allowedMethods;
            return Ok();
        }
    }
}