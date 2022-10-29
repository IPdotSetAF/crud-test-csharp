using CrudTest.Core.Domain.Exceptions;

namespace CrudTest.Core.Domain.Entities.ValueObjects
{
    public class BankAccountNumber : ValueObject
    {
        public ulong Value { get; private set; }

        public BankAccountNumber() { }

        public BankAccountNumber(ulong? value)
        {
            if(!value.HasValue)
                throw new NullReferenceException("BankAccountNumber can not be null.");

            if (value < 1000000000000000 || value > 9999999999999999) 
                throw new InvalidBankAccountNumberException(value.Value); 

            Value = value.Value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value; 
        }
    }
}
