using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    public abstract class ApplicationControllerBase : ControllerBase
    {
        private protected readonly IRepositoryManager Repository;
        private protected readonly IConfiguration? Configuration;
        private protected readonly IMapper? Mapper;

        protected ApplicationControllerBase(IRepositoryManager repository, IConfiguration configuration, IMapper mapper)
        {
            Repository = repository;
            Configuration = configuration;
            Mapper = mapper;
        }

        protected ApplicationControllerBase(IRepositoryManager repository, IMapper mapper) : this(repository ,null, mapper) { }
        protected ApplicationControllerBase(IRepositoryManager repository, IConfiguration configuration) : this(repository, configuration, null) { }
    }
}
