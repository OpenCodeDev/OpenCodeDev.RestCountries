using OpenCodeDev.RestCountries.Tests.Engine;

namespace OpenCodeDev.RestCountries.Tests.ValidationTests
{
    public class CountryValidationExtTests : EngineTests
    {
        [Theory]
        [InlineData("us", "90210", "countriesV3.1")]
        [InlineData("us", "90210-1234", "countriesV3.1")]
        [InlineData("ca", "K1A0B1", "countriesV3.1")]
        public void IsPostalValid_Success(string countryCode, string postal, string version)
        {
            var item = GetOrCache(version);
            var country = item.GetByCCA2Code(countryCode);
            Assert.True(country!.IsPostalValid(postal));
        }

        [Theory]
        [InlineData("us", "90210-", "countriesV3.1")]
        [InlineData("us", "902101234", "countriesV3.1")]
        [InlineData("ca", "KAA0B1", "countriesV3.1")]
        public void IsPostalValid_Failures(string countryCode, string postal, string version)
        {
            var item = GetOrCache(version);
            var country = item.GetByCCA2Code(countryCode);
            Assert.False(country!.IsPostalValid(postal));
        }


        [Theory]
        [InlineData("us", "countriesV3.1")]
        [InlineData("ca", "countriesV3.1")]
        public void IsPostalRequired_Yes(string countryCode, string version)
        {
            var item = GetOrCache(version);
            var country = item.GetByCCA2Code(countryCode);
            Assert.True(country!.IsPostalRequired());
        }

        [Theory]
        [InlineData("mu", "countriesV3.1")]
        [InlineData("ca", "countriesV3")] // V3 does not support postal z
        public void IsPostalRequired_No(string countryCode, string version)
        {
            var item = GetOrCache(version);
            var country = item.GetByCCA2Code(countryCode);
            Assert.False(country!.IsPostalRequired());
        }


        [Theory]
        [InlineData("mu", "+230", "countriesV3.1")]
        [InlineData("mu", "+230", "countriesV3")]
        [InlineData("ca", "+1", "countriesV3.1")]
        [InlineData("ca", "+1", "countriesV3")]
        public void PhonePrefixes_Success(string countryCode, string expectedPrefix, string version)
        {
            var item = GetOrCache(version);
            var country = item.GetByCCA2Code(countryCode);
            var prefixes = country!.PhonePrefixes();
            Assert.True(prefixes.Contains(expectedPrefix));
        }


        [Theory]
        [InlineData("mu", "+2", "countriesV3.1")]
        [InlineData("ca", "+12", "countriesV3.1")]
        [InlineData("mu", "+2", "countriesV3")]
        [InlineData("ca", "+12", "countriesV3")]
        public void PhonePrefixes_Failure(string countryCode, string expectedPrefix, string version)
        {
            var item = GetOrCache(version);
            var country = item.GetByCCA2Code(countryCode);
            var prefixes = country!.PhonePrefixes();
            Assert.False(prefixes.Contains(expectedPrefix));
        }


        [Theory]
        [InlineData("mu", "countriesV3.1", true)]
        [InlineData("mu", "countriesV3", true)]
        [InlineData("ca", "countriesV3.1", true)]
        [InlineData("ca", "countriesV3", true)]
        public void HasFlagPNG_Tests(string countryCode, string version, bool expected)
        {
            var item = GetOrCache(version);
            var country = item.GetByCCA2Code(countryCode);
            var result = country!.HasPNGFlag();
            if (expected) Assert.True(result);
            else Assert.False(result);

        }

        [Theory]
        [InlineData("mu", "countriesV3.1", true)]
        [InlineData("mu", "countriesV3", true)]
        [InlineData("ca", "countriesV3.1", true)]
        [InlineData("ca", "countriesV3", true)]
        public void HasFlagSVG_Tests(string countryCode, string version, bool expected)
        {
            var item = GetOrCache(version);
            var country = item.GetByCCA2Code(countryCode);
            var result = country!.HasSVGFlag();
            if (expected) Assert.True(result);
            else Assert.False(result);

        }

        [Theory]
        [InlineData("mu", "countriesV3.1", true)]
        [InlineData("mu", "countriesV3", false)] // ALT text not supported on V3
        [InlineData("ca", "countriesV3.1", true)]
        public void HasFlagALTText_Tests(string countryCode, string version, bool expected)
        {
            var item = GetOrCache(version);
            var country = item.GetByCCA2Code(countryCode);
            var result = country!.HasALTTextForFlag();
            if (expected) Assert.True(result);
            else Assert.False(result);

        }

        [Theory]
        [InlineData("mu", "MUR", "countriesV3.1", true)]
        [InlineData("ca", "USD", "countriesV3.1", false)]
        [InlineData("ca", "CAD", "countriesV3.1", true)]
        public void IsValidCurrency_Tests(string countryCode, string currencyCode, string version, bool expected)
        {
            var item = GetOrCache(version);
            var country = item.GetByCCA2Code(countryCode);
            var result = country!.IsValidCurrency(currencyCode);
            if (expected) Assert.True(result);
            else Assert.False(result);

        }


        [Theory]
        [InlineData("mu", "countriesV3.1", true)]
        [InlineData("mu", "countriesV3", true)] // ALT text not supported on V3
        [InlineData("ca", "countriesV3.1", true)]
        public void GetFlagURL_Tests(string countryCode, string version, bool expected)
        {
            var item = GetOrCache(version);
            var country = item.GetByCCA2Code(countryCode);
            try
            {
                var result = country!.GetFlagURL();
                if (expected) Assert.True(true);
                else Assert.True(false);
            }
            catch (Exception)
            {
                if (!expected) Assert.True(true);
                else Assert.True(false);
            }

        }


    }
}
