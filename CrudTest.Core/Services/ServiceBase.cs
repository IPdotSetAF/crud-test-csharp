using AutoMapper;
using CrudTest.Core.Domain.RepositoryInterfaces;

namespace CrudTest.Core.Services
{
    public abstract class ServiceBase
    {
        private protected readonly IRepositoryManager RepositoryManager;
        private protected readonly IMapper Mapper;

        public ServiceBase(IRepositoryManager repositoryManager)
        {
            RepositoryManager = repositoryManager;
            Mapper = GetMapper();
        }

        private IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }
    }
}
