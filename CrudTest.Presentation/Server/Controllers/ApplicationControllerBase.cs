using CrudTest.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CrudTest.Presentation.Server.Controllers
{
    public abstract class ApplicationControllerBase : ControllerBase
    {
        private protected readonly IServiceManager ServiceManager;
        private protected readonly IConfiguration? Configuration;

        protected ApplicationControllerBase(IServiceManager serviceManager, IConfiguration configuration)
        {
            ServiceManager = serviceManager;
            Configuration = configuration;
        }

        protected ApplicationControllerBase(IServiceManager serviceManager) : this(serviceManager, null) { }
    }
}
