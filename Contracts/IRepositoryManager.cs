using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        public ICustomerRepository Customer { get; }


        public void Save();
        public Task SaveAsync();
    }
}
