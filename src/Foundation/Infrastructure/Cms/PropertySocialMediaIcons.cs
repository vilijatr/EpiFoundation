using EPiServer.PlugIn;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Foundation.Infrastructure.Cms;

[PropertyDefinitionTypePlugIn]
public class PropertySocialMediaIcons : PropertyList<SocialMediaIcon>
{
}
public class SocialMediaIcon
{
    public virtual ContentReference Icon { get; set; }

    [JsonConverter(typeof(UrlConverter))]
    public virtual Url Link { get; set; }
}
public class UrlConverter : JsonConverter<Url>
{
    public override Url Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.GetString() != null)
        {
            return new Url(new Uri(reader.GetString()));
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, Url value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value == null || value.IsEmpty() ? string.Empty : value.ToString());
    }
}