namespace CSM_Foundation_Core.Errors.Models;

/// <summary>
///     Enumerates the severity of the exception feedback.
/// </summary>
public enum ExceptionFeedbackSeverity {
    /// <summary>
    ///     Information severity.
    /// </summary>
    Info,
    /// <summary>
    ///     Warning severity.
    /// </summary>
    Warn,
    /// <summary>
    ///     Error severity.
    /// </summary>
    Error,
}

/// <summary>
///     Represents a solution user friendly exception feedback message.
/// </summary>
public record ErrorFeedback {

    /// <summary>
    ///     Feedback message.
    /// </summary>
    public required string Message { get; init; }

    /// <summary>
    ///     Feedback severity.
    /// </summary>
    public required ExceptionFeedbackSeverity Severity { get; init; }
}
