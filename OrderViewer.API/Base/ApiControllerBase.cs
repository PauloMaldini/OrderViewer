using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OrderViewer.API.Base
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMapper Mapper;  
        
        protected ApiControllerBase(IMapper mapper)
        {
            Mapper = mapper;
        }
        
        public override ActionResult ValidationProblem(
            /*[ActionResultObjectValue]*/ ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}