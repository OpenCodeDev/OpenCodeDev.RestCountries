using OpenCodeDev.RestCountries.DataModels;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace OpenCodeDev.RestCountries.Mapping
{
    /// <summary>
    /// The reason for those extension is that inconsistencies were found in the RestCountries Json file when it comes to typing...
    /// An object with key/valueObj like: { "0":{"ff":1}, "1":{"ff":1}} can suddenly become []... which throw inconsistent error the work-around
    /// to fix that is the partially manually map the dictionaries if type is match expected type... that maintain compatibility with the original
    /// RestCounrties Json file and will be able to be updated in the future with no adjustement on our part.
    /// </summary>
    public static class DeserializeModelPopulatingExt
    {

        public static void Populate(this CountryDM model, JsonObject json)
        {
            var prop = json["currencies"];
            var type = prop?.GetType();
            if (prop != null && type != default && type.Name == nameof(JsonObject))
                model.Currencies.Populate(prop.AsObject());


            prop = json["translations"];
            type = prop?.GetType();
            if (prop != null && type != default && type.Name == nameof(JsonObject))
                model.Translations.Populate(prop.AsObject());

            prop = json["demonyms"];
            type = prop?.GetType();
            if (prop != null && type != default && type.Name == nameof(JsonObject))
                model.Demonyms.Populate(prop.AsObject());


            prop = json["flags"];
            type = prop?.GetType();
            if (prop != null && type != default && type.Name == nameof(JsonObject))
                model.Flags.PopulateFlags(prop.AsObject());
            else if (prop != null && type != default && type.Name == nameof(JsonArray))
                model.Flags.PopulateFlags(prop.AsArray());

            //if (json["currencies"])
        }

        public static void Populate(this Dictionary<string, CountryDemonymDM> model, JsonObject json)
        {
            foreach (var item in json)
                model.Add(item.Key, item.Value.Deserialize<CountryDemonymDM>(new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!);
            //if (json["currencies"])
        }

        public static void Populate(this Dictionary<string, CountryNameTranslatedDM> model, JsonObject json)
        {
            foreach (var item in json)
                model.Add(item.Key, item.Value.Deserialize<CountryNameTranslatedDM>(new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!);
            //if (json["currencies"])
        }

        public static void Populate(this Dictionary<string, CountryCurrencyDM> model, JsonObject json)
        {
            foreach (var item in json)
                model.Add(item.Key, item.Value.Deserialize<CountryCurrencyDM>(new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!);
            //if (json["currencies"])
        }

        public static void PopulateFlags(this Dictionary<string, string> model, JsonArray json)
        {
            foreach (var item in json)
                if (item!.AsValue().ToString().EndsWith(".svg", StringComparison.CurrentCultureIgnoreCase))
                    model.Add("SVG", item!.AsValue().ToString());
                else if (item!.AsValue().ToString().EndsWith(".png", StringComparison.CurrentCultureIgnoreCase))
                    model.Add("PNG", item!.AsValue().ToString());
        }
        public static void PopulateFlags(this Dictionary<string, string> model, JsonObject json)
        {
            foreach (var item in json)
                model.Add(item.Key, item.Value!.AsValue().ToString());

        }
    }
}
