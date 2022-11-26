using CrudTest.Bussiness.Contracts.DTOs.Customer;
using System.Threading.Tasks;

namespace CrudTest.Bussiness.Services.Abstractions
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerGetDTO>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CustomerGetDTO> GetByIdAsync(Guid customerId, CancellationToken cancellationToken = default);
        Task<CustomerGetDTO> CreateAsync(CustomerCreateDTO customerCreateDTO, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid customerId, CustomerUpdateDTO customerUpdateDTO, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid customerId, CancellationToken cancellationToken = default);
    }
}
