using System.Security.Cryptography;

namespace SharedUtils
{
    public static class GuidUtils
    {
        public static Guid SeededGuid(int seed)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(seed).CopyTo(bytes, 0);
            return new Guid(MD5.HashData(bytes));
        }
    }
}