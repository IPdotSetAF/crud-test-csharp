using CrudTest.Core.Domain.Exceptions;
using PhoneNumbers;

namespace CrudTest.Core.Domain.Entities.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public ulong Value { get; private set; }

        public PhoneNumber() { }

        public PhoneNumber(string? value)
        {
            if(value == null) 
                throw new ArgumentNullException("Phone number can not be null.");

            string withPrefix = value;

            if (withPrefix[0] != '+')
                withPrefix = withPrefix.Insert(0, "+");

            try
            {
                PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
                var pn = phoneNumberUtil.Parse(withPrefix, "");
                if (phoneNumberUtil.IsValidNumber(pn))
                    Value = UInt64.Parse(withPrefix.Substring(1));
                else throw new InvalidPhoneNumberException(value);
            }
            catch (Exception)
            {
                throw new InvalidPhoneNumberException(value);
            }
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
