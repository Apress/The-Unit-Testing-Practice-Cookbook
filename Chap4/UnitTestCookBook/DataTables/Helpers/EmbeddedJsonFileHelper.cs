using Newtonsoft.Json;

namespace Apress.UnitTests.DataTables.Helpers;

public static class EmbeddedJsonFileHelper
{
    public static T GetContent<T>(string filename)
    {
        return JsonConvert.DeserializeObject<T>(File.ReadAllText($"{filename}.json"));
    }
}
