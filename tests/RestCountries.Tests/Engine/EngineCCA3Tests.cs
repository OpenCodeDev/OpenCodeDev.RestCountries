namespace OpenCodeDev.RestCountries.Tests.Engine
{
    public class EngineCCA3Tests : EngineTests
    {

        [Theory]
        [InlineData("caN", "countriesV3.1")]
        [InlineData("brA", "countriesV3")]
        public void CheckGetByCCA3_Success(string countryCode, string version)
        {
            var country = GetOrCache(version).GetByCCA3Code(countryCode);
            Assert.True(country != default);
        }

        [Theory]
        [InlineData("AU", "countriesV3.1")]
        [InlineData("GeRmAnY", "countriesV3")]
        public void CheckGetByCCA3_Failure(string countryCode, string version)
        {
            var country = GetOrCache(version).GetByCCA3Code(countryCode);
            Assert.True(country == default);
        }


        [Theory]
        [InlineData("caN", "countriesV3.1")]
        [InlineData("brA", "countriesV3")]
        public void CheckIsValidCCA3_Success(string countryCode, string version)
        {
            Assert.True(GetOrCache(version).IsValidCCA3Code(countryCode));
        }


        [Theory]
        [InlineData("AU", "countriesV3.1")]
        [InlineData("GeRmAnY", "countriesV3")]
        public void CheckIsValidCCA3_Failures(string countryCode, string version)
        {
            Assert.False(GetOrCache(version).IsValidCCA3Code(countryCode));
        }
    }
}
