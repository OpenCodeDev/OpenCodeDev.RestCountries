using OpenCodeDev.RestCountries.Entities.Mapping;
using OpenCodeDev.RestCountries.Tests.Engine;
using System.Collections;

namespace OpenCodeDev.RestCountries.Tests.Mapping
{

    public class TimeZoneDataSet : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]> {
            new object[] { "UTC-12", new TimeSpan(-12, 00,00) },
            new object[] { "UTC-12:00", new TimeSpan(-12, 00, 00) },
            new object[] { "UTC-12:00:00", new TimeSpan(-12, 00, 00) },
            new object[] { "UTC", new TimeSpan(00, 00, 00) },
            new object[] { "UTC+11:00", new TimeSpan(11, 00, 00) },
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class TimezoneOffsetParsingTests : EngineTests
    {
        [Theory]
        [ClassData(typeof(TimeZoneDataSet))]
        public void TimezoneConverter_Tests(string offset, TimeSpan timeSpan)
        {
            TimeSpan offsetTime = MappingExt.UTCOffsetConverter(offset);

            Assert.True(timeSpan == offsetTime);
        }
    }
}
