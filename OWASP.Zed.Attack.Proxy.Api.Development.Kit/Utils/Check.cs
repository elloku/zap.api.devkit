namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.Utils
{
    public class Check
    {
        public static void NotNull(string param)
        {
            if(param == null)
            {
                throw new NullReferenceException();
            }
        }

    }
}
