namespace OpenCodeDev.RestCountries.Tests.Engine
{
    public class EngineCCN3Tests : EngineTests
    {


        [Theory]
        [InlineData("032", "countriesV3.1")]
        [InlineData("380", "countriesV3")]
        public void CheckGetByCCN3_Success(string countryCode, string version)
        {
            var country = GetOrCache(version).GetByCCN3Code(countryCode);
            Assert.True(country != default);
        }

        [Theory]
        [InlineData("111", "countriesV3.1")]
        [InlineData("333", "countriesV3")]
        public void CheckGetByCCN3_Failure(string countryCode, string version)
        {
            var country = GetOrCache(version).GetByCCN3Code(countryCode);
            Assert.True(country == default);
        }

        [Theory]
        [InlineData("032", "countriesV3.1")]
        [InlineData("380", "countriesV3")]
        public void CheckIsValidCCN3_Success(string countryCode, string version)
        {
            Assert.True(GetOrCache(version).IsValidCCN3Code(countryCode));
        }


        [Theory]
        [InlineData("111", "countriesV3.1")]
        [InlineData("333", "countriesV3")]
        public void CheckIsValidCCN3_Failures(string countryCode, string version)
        {
            Assert.False(GetOrCache(version).IsValidCCN3Code(countryCode));
        }
    }
}
