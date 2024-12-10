namespace OpenCodeDev.RestCountries.Tests.Engine
{
    public class EnginePostalCCN3Tests : EngineTests
    {
        [Theory]
        [InlineData("036", "2000", "countriesV3.1")]
        public void IsValidCCN3PostalCode_Success(string countryCode, string postalCode, string version)
        {
            Assert.True(GetOrCache(version).IsValidCCN3PostalCode(countryCode, postalCode));
        }


        [Theory]
        [InlineData("036", "M5A1A1", "countriesV3.1")]
        public void IsValidCCN3PostalCode_Failures(string countryCode, string postalCode, string version)
        {
            Assert.False(GetOrCache(version).IsValidCCN3PostalCode(countryCode, postalCode));
        }
    }
}
