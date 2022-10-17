using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Customer
{
    public class CustomerGetDTO : CustomerCreateDTO
    {
        public Guid Id { get; set; }
    }
}
