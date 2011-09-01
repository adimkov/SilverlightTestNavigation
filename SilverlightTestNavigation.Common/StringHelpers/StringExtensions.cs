/// <summary>
/// Extension methods for string.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Apply format to string.
    /// </summary>
    /// <param name="str">String format.</param>
    /// <param name="args">Format arguments.</param>
    /// <returns>String with applied format.</returns>
    public static string FormatString(this string str, params object[] args)
    {
        return string.Format(str, args);
    }
}
