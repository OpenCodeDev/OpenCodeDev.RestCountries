namespace OpenCodeDev.RestCountries.Tests.Engine
{

    public class EngineCCA2Tests : EngineTests
    {
        [Theory]
        [InlineData("AU", "countriesV3.1")]
        [InlineData("aU", "countriesV3.1")]
        [InlineData("AU", "countriesV3")]
        [InlineData("aU", "countriesV3")]
        public void CheckGetByCCA2_Success(string countryCode, string version)
        {
            var country = GetOrCache(version).GetByCCA2Code(countryCode);
            Assert.True(country != default);
        }

        [Theory]
        [InlineData("caN", "countriesV3.1")]
        [InlineData("UnItEd KiNgDoM", "countriesV3.1")]
        [InlineData("caN", "countriesV3")]
        [InlineData("UnItEd KiNgDoM", "countriesV3")]
        public void CheckGetByCCA2_Failures(string countryCode, string version)
        {
            var country = GetOrCache(version).GetByCCA2Code(countryCode);
            Assert.True(country == default);
        }

        [Theory]
        [InlineData("AU", "countriesV3.1")]
        [InlineData("aU", "countriesV3.1")]
        [InlineData("AU", "countriesV3")]
        [InlineData("aU", "countriesV3")]
        public void CheckIsValidCCA2_Success(string countryCode, string version)
        {
            Assert.True(GetOrCache(version).IsValidCCA2Code(countryCode));
        }


        [Theory]
        [InlineData("caN", "countriesV3.1")]
        [InlineData("UnItEd KiNgDoM", "countriesV3.1")]
        [InlineData("caN", "countriesV3")]
        [InlineData("UnItEd KiNgDoM", "countriesV3")]
        public void CheckIsValidCCA2_Failures(string countryCode, string version)
        {
            Assert.False(GetOrCache(version).IsValidCCA2Code(countryCode));
        }
    }
}
