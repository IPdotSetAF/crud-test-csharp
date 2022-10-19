using AutoMapper;
using DTOs.Customer;
using Mc2.CrudTest.AcceptanceTests.Mocks;
using Mc2.CrudTest.Presentation.Server;
using Mc2.CrudTest.Presentation.Server.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedUtils;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class CustomerControllerTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void WhenGettingAllCustomers_ThenAllCustomersReturns()
        {
            var repositoryManagerMock = MockRepositoryManager.GetMock();
            var mapper = GetMapper();
            var customerController = new CustomerController(repositoryManagerMock.Object, mapper);

            var result = customerController.GetAllCustomers().Result as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<CustomerGetDTO>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<CustomerGetDTO>);
        }

        [Fact]
        public void GivenAnIdOfAnExistingCustomer_WhenGettingCustomerById_ThenCustomerReturns()
        {
            var repositoryManagerMock = MockRepositoryManager.GetMock();
            var mapper = GetMapper();
            var customerController = new CustomerController(repositoryManagerMock.Object, mapper);

            var id = GuidUtils.SeededGuid(1);

            var result = customerController.GetCustomer(id).Result as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal((result.Value as CustomerGetDTO).Id, id);
            Assert.IsAssignableFrom<CustomerGetDTO>(result.Value);
        }


    }
}
