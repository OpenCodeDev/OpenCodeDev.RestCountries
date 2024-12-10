namespace OpenCodeDev.RestCountries.Tests.Engine
{
    public class EngineCurrencyCCA3Tests : EngineTests
    {

        [Theory]
        [InlineData("AUs", "AUD", "countriesV3.1")]
        [InlineData("can", "CAD", "countriesV3")]
        public void IsValidCCA3Currency_Success(string countryCode, string currencyCode, string version)
        {
            Assert.True(GetOrCache(version).IsValidCCA3Currency(countryCode, currencyCode));
        }


        [Theory]
        [InlineData("AUS", "CAD", "countriesV3.1")]
        [InlineData("can", "USD", "countriesV3")]
        public void IsValidCCA3Currency_Failures(string countryCode, string currencyCode, string version)
        {
            Assert.False(GetOrCache(version).IsValidCCA3Currency(countryCode, currencyCode));
        }

    }
}
