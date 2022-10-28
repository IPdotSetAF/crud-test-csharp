using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Core.Domain.Entities.ValueObjects
{
    public class BanckAccountNumber
    {
        public ulong Number { get; private set; }

        public BanckAccountNumber(ulong number)
        {
            //TODO validate number
            Number = number;
        }
    }
}
