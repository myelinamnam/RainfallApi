namespace RainfallApi.Extensions
{
    public class DotNetEnvironmentVariableConfigurationSource : IConfigurationSource
    {
        private readonly string _environmentVariablePrefix;

        public DotNetEnvironmentVariableConfigurationSource(string prefix = "Randem")
        {
            _environmentVariablePrefix = prefix;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new DotNetEnvironmentVariableConfigurationProvider(_environmentVariablePrefix);
        }
    }
}
