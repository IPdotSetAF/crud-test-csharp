using CrudTest.Bussiness.Domain.Exceptions;

namespace CrudTest.Bussiness.Domain.Entities.ValueObjects
{
    public class BankAccountNumber : ValueObject
    {
        public ulong Value { get; private set; }

        private BankAccountNumber() { }

        public BankAccountNumber(ulong value)
        {
            Value = Validate(value);
        }

        private ulong Validate(ulong value)
        {
            //TODO: use IBAN for validation

            if (value < 1000000000000000 || value > 9999999999999999)
                throw new InvalidBankAccountNumberException(value);

            return value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value; 
        }
    }
}
