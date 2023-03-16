using Microsoft.AspNetCore.DataProtection;

namespace ClassLibrary1.Manager
{
    public class SecurityManager
    {
        private readonly IDataProtector hashProtector;

        public SecurityManager(IDataProtectionProvider dataProtector) 
        {
            hashProtector = dataProtector.CreateProtector("Hash");
        }

        public string EncryptPassword(string? password)
        {
            string hash = hashProtector.Protect(password);

            return hash;
        }

        public string DecryptPassword(string? password)
        {
            string hash = hashProtector.Unprotect(password);
            return hash;
        }
    }
}
