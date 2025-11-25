using CSM_Foundation_Core.Errors.Abstractions.Bases;

namespace CSM_Foundation_Core.Core.Utils;


/// <summary>
///     Represents the current available system environments.
/// </summary>
public enum SystemEnvs {
    /// <summary>
    ///     Used on development scope.
    /// </summary>
    DEV,
    /// <summary>
    ///     Sensitive production scope.
    /// </summary>
    PROD,
    /// <summary>
    ///     Quality assurance playground.
    /// </summary>
    QA,
    /// <summary>
    ///     Research and complex testing playground.
    /// </summary>
    LAB,
}

/// <summary>
///     Represents the possible exception throwing events for <see cref="XSystemUtils"/>.
/// </summary>
public enum XSystemUtilsEvents {
    /// <summary>
    ///     When a variable key is being tried to be gathered but it doesn't exist.
    /// </summary>
    VAR_KEY_NOT_EXIST,
}

/// <summary>
///     Represents an exception thrown by <see cref="SystemUtils"/> operations.
/// </summary>
public class XSystemUtils
    : ErrorBase<XSystemUtilsEvents> {

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="event">
    ///     Event that triggered the exception.
    /// </param>
    /// <param name="data">
    ///     Exception research data.
    /// </param>
    public XSystemUtils(XSystemUtilsEvents @event, IDictionary<string, object?>? data = null)
        : base($"System Utilities: {@event}({(int)@event})", @event, data: data) {
    }
}

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


    /// <summary>
    ///     Gets the current system runtime environment.
    /// </summary>
    /// <param name="varKey">
    ///     System environment variable key.
    /// </param>
    /// <returns>
    ///     The current system environment.
    /// </returns>
    /// <exception cref="XSystemUtils">
    ///     Thrown when the given <paramref name="varKey"/> isn't found.
    /// </exception>
    public static SystemEnvs GetEnv(string varKey = Constants.Framework.ASPNETCORE_ENVIRONEMNT) {

        string? envVarValue = GetVar(varKey);

        return envVarValue == null
            ? throw new XSystemUtils(
                    XSystemUtilsEvents.VAR_KEY_NOT_EXIST,
                    new Dictionary<string, object?> {
                        { "VAR_KEY", varKey },
                    }
                )
            : envVarValue.ToLower() switch {
                var env when env == Constants.Environments.DEV || env == Constants.Environments.DEVELOPMENT => SystemEnvs.DEV,
                var env when env == Constants.Environments.PROD || env == Constants.Environments.PRODUCTION => SystemEnvs.PROD,
                var env when env == Constants.Environments.QA || env == Constants.Environments.QUALITY => SystemEnvs.QA,
                var env when env == Constants.Environments.LAB || env == Constants.Environments.LABORATORY => SystemEnvs.LAB,

                _ => throw new XSystemUtils(XSystemUtilsEvents.VAR_KEY_NOT_EXIST),
            };
    }
}
