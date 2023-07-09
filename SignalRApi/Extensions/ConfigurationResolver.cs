namespace SignalRApi.Extensions
{
    public  class ConfigurationResolver
    {
        private readonly IConfiguration _configuration;

        public ConfigurationResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetDbConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
