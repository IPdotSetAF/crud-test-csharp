namespace CrudTest.Core.Domain.Entities.ValueObjects
{
    public class BankAccountNumber : ValueObject
    {
        public ulong Value { get; private set; }

        public BankAccountNumber() { }

        public BankAccountNumber(ulong value)
        {
            //TODO validate number
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value; 
        }
    }
}
