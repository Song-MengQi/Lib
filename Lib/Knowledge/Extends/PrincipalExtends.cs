using System.Security.Principal;

namespace Lib
{
    public static class PrincipalExtends
    {
        public static bool InAdministrator()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}