namespace OpenCodeDev.RestCountries.Tests.Engine
{
    public class EngineCurrencyCCN3Tests : EngineTests
    {

        [Theory]
        [InlineData("032", "ARS", "countriesV3.1")]
        [InlineData("380", "EUR", "countriesV3")]
        public void IsValidCCN3Currency_Success(string countryCode, string currencyCode, string version)
        {
            Assert.True(GetOrCache(version).IsValidCCN3Currency(countryCode, currencyCode));
        }


        [Theory]
        [InlineData("032", "USD", "countriesV3.1")]
        [InlineData("380", "USD", "countriesV3")]
        public void IsValidCCN3Currency_Failures(string countryCode, string currencyCode, string version)
        {
            Assert.False(GetOrCache(version).IsValidCCN3Currency(countryCode, currencyCode));
        }
    }
}
