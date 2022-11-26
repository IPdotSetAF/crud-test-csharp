using CrudTest.Bussiness.Domain.Exceptions;
using PhoneNumbers;

namespace CrudTest.Bussiness.Domain.Entities.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public ulong Value { get; private set; }

        private static readonly PhoneNumberUtil _phoneNumberUtil = PhoneNumberUtil.GetInstance();

        private PhoneNumber() { }

        public PhoneNumber(string value)
        {
            Value = Validate(value);
        }

        private ulong Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Phone number can not be null.");

            string withPrefix = value;

            if (withPrefix[0] != '+')
                withPrefix = withPrefix.Insert(0, "+");

            try
            {
                //TODO: only accept mobile numbers
                var pn = _phoneNumberUtil.Parse(withPrefix, "");
                if (_phoneNumberUtil.IsValidNumber(pn))
                    return UInt64.Parse(withPrefix.Substring(1));
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
