using System.Reflection;

namespace OpenCodeDev.RestCountries.Data
{
    public static class RestCountriesEmbed
    {
        public static string GetVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            if (assembly == default) throw new NullReferenceException("Assembly is Null.");
            var res = assembly.GetManifestResourceNames();
            var manifestStream = assembly.GetManifestResourceStream($"OpenCodeDev.RestCountries.Data.Resources.countries.json");
            if (manifestStream == default)
                throw new NullReferenceException($"Error cannot read countries.JSON");

            using (Stream stream = manifestStream)
            using (StreamReader reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }
    }
}
