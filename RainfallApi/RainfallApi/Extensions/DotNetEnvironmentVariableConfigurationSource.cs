namespace RainfallApi.Extensions
{
    public class DotNetEnvironmentVariableConfigurationSource : IConfigurationSource
    {
        private readonly string _environmentVariablePrefix;

        public DotNetEnvironmentVariableConfigurationSource(string prefix = "WebApi")
        {
            _environmentVariablePrefix = prefix;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new DotNetEnvironmentVariableConfigurationProvider(_environmentVariablePrefix);
        }
    }
}
