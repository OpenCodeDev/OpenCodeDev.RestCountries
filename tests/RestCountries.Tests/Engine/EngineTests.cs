using OpenCodeDev.RestCountries.Embedded;

namespace OpenCodeDev.RestCountries.Tests.Engine
{
    public class EngineTests
    {
        protected Dictionary<string, RestCountries> _cache = new Dictionary<string, RestCountries>();


        protected RestCountries GetOrCache(string version)
        {

            if (_cache.ContainsKey(version)) return _cache[version];
            RestCountries item = new RestCountries(RestCountriesEmbed.GetVersion(version));
            _cache.Add(version, item);
            return item;
        }



        [Theory]
        [InlineData("countriesV3.1")]
        [InlineData("countriesV3")]
        public void CheckVersionAvailable_Success(string version)
        {
            var item = GetOrCache(version);
            var restCountry = item.GetAll();
            Assert.True(restCountry != null && restCountry.Count == item.Data.Count);

        }

        [Theory]
        [InlineData("countriesV")]
        [InlineData("countriesV1")]
        [InlineData("countriesV1.2.3")]
        public void CheckVersionAvailable_Failures(string version)
        {
            Assert.Throws(typeof(NullReferenceException), () => { GetOrCache(version); });

        }

    }
}
