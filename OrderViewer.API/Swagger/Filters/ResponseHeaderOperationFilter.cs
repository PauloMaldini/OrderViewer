using Microsoft.OpenApi.Models;
using OrderViewer.API.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OrderViewer.API.Swagger.Filters
{
    public class ResponseHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            foreach (var item in context.ApiDescription.CustomAttributes())
            {
                if (item is ResponseHeaderAttribute attribute)
                {
                    operation.Responses["200"].Headers.Add(attribute.Name, new OpenApiHeader
                    {
                        Schema = context.SchemaGenerator.GenerateSchema(attribute.Type, context.SchemaRepository)
                    });
                }
            }
        }
    }
}
