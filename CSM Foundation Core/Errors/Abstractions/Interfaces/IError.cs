using System.Text.Json.Serialization;

using CSM_Foundation_Core.Errors.Models;

namespace CSM_Foundation_Core.Errors.Abstractions.Interfaces;

/// <summary>
///     Represents a CSM Exception thrown by the system.
/// </summary>
public interface IError {

    /// <summary>
    ///     Exception message.
    /// </summary>
    string Message { get; }

    /// <summary>
    ///     Exception stacking trace.
    /// </summary>
    string? StackTrace { get; }

    /// <summary>
    ///     An user friendly message, meant to be displayed instead of the complex framework exception messages.
    /// </summary>
    string Advise { get; }

    /// <summary>
    ///     The internal system exception object caught.
    /// </summary>
    Exception? Exception { get; }

    /// <summary>
    ///     Exception feedback data.
    /// </summary>
    ErrorFeedback[] Feedback { get; }

    /// <summary>
    ///     Data relevant during operation that triggered the exception.
    /// </summary>
    [JsonIgnore]
    IDictionary<string, object?> Data { get; }
}

/// <summary>
///     Represents a CSM Exception thrown by the system.
/// </summary>
/// <typeparam name="TEvent">
///     Exception scoped reasons enumerator.
/// </typeparam>
public interface IException<TEvent>
    : IError
    where TEvent : Enum {

    /// <summary>
    ///     Exception trigger event.
    /// </summary>
    TEvent Event { get; }
}