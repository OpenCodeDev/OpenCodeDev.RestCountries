namespace OpenCodeDev.RestCountries.Tests.Engine
{
    public class EnginePostalCCA2Tests : EngineTests
    {

        [Theory]
        [InlineData("AU", "2000", "countriesV3.1")]
        public void IsValidCCA2PostalCode_Success(string countryCode, string postalCode, string version)
        {
            Assert.True(GetOrCache(version).IsValidCCA2PostalCode(countryCode, postalCode));
        }


        [Theory]
        [InlineData("AU", "M5A1A1", "countriesV3.1")]
        public void IsValidCCA2PostalCode_Failures(string countryCode, string postalCode, string version)
        {
            Assert.False(GetOrCache(version).IsValidCCA2PostalCode(countryCode, postalCode));
        }


    }
}
