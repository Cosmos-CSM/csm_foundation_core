namespace CSM_Foundation_Core.Utils;


/// <summary>
///     Utilities class to provide better handling of system / environemnt matters.
/// </summary>
public static class SystemUtils {


    /// <summary>
    ///     Gets a system environment variable.
    /// </summary>
    /// <param name="varKey">
    ///     Variable key.
    /// </param>
    public static string? GetVar(string varKey) {
        string? var = Environment.GetEnvironmentVariable(varKey);

        return var;
    }

    /// <summary>
    ///     Sets a system environment variable.
    /// </summary>
    /// <param name="varKey">
    ///     Variable key.
    /// </param>
    /// <param name="varValue">
    ///     Variable value.
    /// </param>
    public static void SetVar(string varKey, string? varValue) {
        Environment.SetEnvironmentVariable(varKey, varValue);
    }
}
