namespace AuthenticationModule.Providers
{
    public class SecuritySettings
    {
        public string Secret { get; set; }

        public int Expiration { get; set; }
    }
}
