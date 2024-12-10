namespace OpenCodeDev.RestCountries.Tests.Engine
{
    public class EnginePostalCCA3Tests : EngineTests
    {
        [Theory]
        [InlineData("AUS", "2000", "countriesV3.1")]
        public void IsValidCCA3PostalCode_Success(string countryCode, string postalCode, string version)
        {
            Assert.True(GetOrCache(version).IsValidCCA3PostalCode(countryCode, postalCode));
        }


        [Theory]
        [InlineData("AUS", "M5A1A1", "countriesV3.1")]
        public void IsValidCCA3PostalCode_Failures(string countryCode, string postalCode, string version)
        {
            Assert.False(GetOrCache(version).IsValidCCA3PostalCode(countryCode, postalCode));
        }
    }
}
