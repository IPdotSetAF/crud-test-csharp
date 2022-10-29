using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Core.Domain.Entities.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; private set; }

        public Email() { }

        public Email(string value)
        {
            //TODO: validate email
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
