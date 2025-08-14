using System.Text.Json;

using CSM_Foundation_Core.Exceptions;

using Detail = System.Collections.Generic.KeyValuePair<string, object?>;
using Details = System.Collections.Generic.Dictionary<string, object?>;

namespace CSM_Foundation_Core.Utils;

/// <summary>
///     Provides utils methods related with the .Net Console integration.
/// </summary>
public static class ConsoleUtils {

    /// <summary>
    ///     Writes into the system console.
    /// </summary>
    /// <param name="severity"> 
    ///     Message severity.
    /// </param>
    /// <param name="title">
    ///     Message title.
    /// </param>
    /// <param name="color">
    ///     Foreground message color.
    /// </param>
    /// <param name="details">
    ///     Details about the message.
    /// </param>
    public static void Write(string severity, string title, ConsoleColor color, Details? details = null) {
        string msgBody = $"[{DateTime.UtcNow}] ({severity}): {title}";

        if (details != null) {
            msgBody += BuildDetailsBody(0, "\t", color, details);
        }

        Console.ForegroundColor = color;
        Console.WriteLine(msgBody);

        Restore();
    }

    /// <summary>
    ///     Writes an Announce severity console message.
    /// </summary>
    /// <param name="title"> 
    ///     Message title.
    /// </param>
    /// <param name="details">
    ///     Message details.
    /// </param>
    public static void Announce(string title, Details? details = null) {
        Write("Announce", title, ConsoleColor.Cyan, details);
    }

    /// <summary>
    ///     Writes a Note severity console message.
    /// </summary>
    /// <param name="title"> 
    ///     Message title.
    /// </param>
    /// <param name="details">
    ///     Message details.
    /// </param>
    public static void Note(string title, Details? details = null) {
        Write("Note", title, ConsoleColor.White, details);
    }

    /// <summary>
    ///     Writes a Success severity console message.
    /// </summary>
    /// <param name="title"> 
    ///     Message title.
    /// </param>
    /// <param name="details">
    ///     Message details.
    /// </param>
    public static void Success(string title, Details? details = null) {
        Write("Success", title, ConsoleColor.DarkGreen, details);
    }

    /// <summary>
    ///     Writes a Warning severity console message.
    /// </summary>
    /// <param name="title"> 
    ///     Message title.
    /// </param>
    /// <param name="details">
    ///     Message details.
    /// </param>
    public static void Warning(string title, Details? details = null) {
        Write("Warning", title, ConsoleColor.DarkYellow, details);
    }

    /// <summary>
    ///     Writes an Error severity console message.
    /// </summary>
    /// <param name="title"> 
    ///     Message title.
    /// </param>
    /// <param name="details">
    ///     Message details.
    /// </param>
    public static void Error(string title, Details? details = null) {
        Write("Error", title, ConsoleColor.DarkRed, details);
    }

    /// <summary>
    ///     Writes an Error severity console message.
    /// </summary>
    /// <param name="exception">
    ///     Exception to write down into the console.
    /// </param>
    public static void Exception(IException exception) {
        Write(
            "Exception",
            exception.Message,
            ConsoleColor.DarkRed,
            new Details {
                    { "Message", exception.Message },
                    { "Thrower", exception.GetType() },
                    { "Data", exception.Data },
                    { "Trace", exception.StackTrace?.ToString() },
                }
            );
    }

    /// <summary>
    ///     Composes the given <paramref name="details"/> information into a printable console text.
    /// </summary>
    /// <param name="depthLevel">
    ///     Current recursion depth level.
    /// </param>
    /// <param name="depthIndent">
    ///     Current recursion depth level for identation.
    /// </param>
    /// <param name="color">
    ///     Current written information foreground color.
    /// </param>
    /// <param name="details">
    ///     Details information to be written.
    /// </param>
    static string BuildDetailsBody(int depthLevel, string depthIndent, ConsoleColor color, Details details) {
        string detailsBody = string.Empty;

        foreach (Detail detail in details) {
            string key = detail.Key;
            object? content = detail.Value;
            try {
                string objectContent = JsonSerializer.Serialize(content);
                Details castedDetails = JsonSerializer.Deserialize<Details>(objectContent) ?? throw new Exception();
                string newObjectFormat = $"{depthIndent}[{key}]:";
                Console.WriteLine(newObjectFormat);
                detailsBody += BuildDetailsBody(depthLevel + 1, $"{depthIndent}\t", color, castedDetails);
            } catch {
                detailsBody += $"\n{depthIndent}[{key}]: {content}";
            }
        }

        return detailsBody;
    }

    /// <summary>
    ///     Restores the current <see cref="Console"/> configuration.
    /// </summary>
    static void Restore() {
        Console.ResetColor();
    }
}
