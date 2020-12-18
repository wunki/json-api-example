using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers
{
    public class TodoItemController : JsonApiController<TodoItem>
    {
        public TodoItemController(
                IJsonApiOptions options,
                ILoggerFactory loggerFactory,
                IResourceService<TodoItem> resourceService)
            : base(options, loggerFactory, resourceService)
        { }
    }
}