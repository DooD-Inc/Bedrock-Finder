using Amplifier;

namespace BedrockFinder.Libraries;
public static class SugarExtensions
{
    public static string ToDescriptiveString(this TimeSpan span)
    {
        string time = (span.Days > 365 ? span.Days / 365 + "y " : "") +
        (span.Days > 0 ? span.Days % 365 + "d " : "") +
        (span.Hours > 0 ? span.Hours + "h " : "") +
        (span.Minutes > 0 ? span.Minutes + "m " : "") +
        (span.Seconds > 0 ? span.Seconds + "s " : "");
        return time == string.Empty ? "< s" : time;
    }
    public static Device ClearName(this Device device)
    {
        device.Name = device.Name.Replace("Core", "").Replace("(TM)", "").Replace("(tm)", "").Replace("(R)", "").Replace("(r)", "").Replace("(C)", "").Replace("(c)", "").Replace(" ", " ").Replace("  ", " ").Split('@')[0];
        return device;
    }
}