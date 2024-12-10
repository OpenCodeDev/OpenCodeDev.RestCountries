using System.Reflection;

namespace OpenCodeDev.RestCountries.Embedded
{
    public static class RestCountriesEmbed
    {
        public static string GetVersion(string version = "countriesV3.1")
        {
            var assembly = Assembly.GetExecutingAssembly();
            if (assembly == default) throw new NullReferenceException("Assembly is Null.");
            var res = assembly.GetManifestResourceNames();
            var manifestStream = assembly.GetManifestResourceStream($"OpenCodeDev.RestCountries.Embedded.Resources.{version}.json");
            if (manifestStream == default)
                throw new NullReferenceException($"{version} is probably unsupported or contains typos... case-sensitive eg: 'countriesV3.1'");

            using (Stream stream = manifestStream)
            using (StreamReader reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }
    }
}
