namespace OpenCodeDev.RestCountries.Tests.Engine
{
    public class EngineCurrencyCCA2Tests : EngineTests
    {

        [Theory]
        [InlineData("AU", "AUD", "countriesV3.1")]
        [InlineData("ca", "CAD", "countriesV3")]
        public void IsValidCCA2Currency_Success(string countryCode, string currencyCode, string version)
        {
            Assert.True(GetOrCache(version).IsValidCCA2Currency(countryCode, currencyCode));
        }


        [Theory]
        [InlineData("AU", "CAD", "countriesV3.1")]
        [InlineData("ca", "USD", "countriesV3")]
        public void IsValidCCA2Currency_Failures(string countryCode, string currencyCode, string version)
        {
            Assert.False(GetOrCache(version).IsValidCCA2Currency(countryCode, currencyCode));
        }


    }
}
