using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Core.Domain.Entities.ValueObjects
{
    public class Email
    {
        public string EmailText { get; private set; }

        public Email(string emailText)
        {
            //TODO: validate email
            EmailText = emailText;
        }
    }
}
