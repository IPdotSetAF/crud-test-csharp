using PhoneNumbers;
using System.Diagnostics;

namespace Mc2.CrudTest.Presentation.Server.Core
{
    public class Utils
    {
        private static PhoneNumberUtil _phoneNumberUtil;
        public static bool IsPhoneNumberValid(ulong phonenumber)
        {
            if(_phoneNumberUtil == null) 
                _phoneNumberUtil=PhoneNumberUtil.GetInstance();

            try
            {
                PhoneNumber pn = _phoneNumberUtil.Parse($"+{phonenumber}", "");
                return _phoneNumberUtil.IsValidNumber(pn);
            }
            catch
            {
                return false;
            }
        }
    }
}
