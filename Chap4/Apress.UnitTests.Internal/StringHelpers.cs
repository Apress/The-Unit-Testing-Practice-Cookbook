using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Apress.UnitTests"), InternalsVisibleTo("AnotherAssembly1")]
[assembly: InternalsVisibleTo("AnotherAssembly2")]
namespace Apress.UnitTests.Internal;

internal static class StringHelpers
{
    internal static string Capitalize(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
    }
}
