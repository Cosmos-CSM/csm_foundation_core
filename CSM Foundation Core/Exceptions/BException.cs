using System.Text.Json.Serialization;

using CSM_Foundation_Core.Exceptions.Models;

namespace CSM_Foundation_Core.Exceptions;

/// <summary>
///     Represents a CSM Exception thrown by the system.
/// </summary>
public interface IException {

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
    ExceptionFeedback[] Feedback { get; }

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
    : IException
    where TEvent : Enum {

    /// <summary>
    ///     Exception trigger event.
    /// </summary>
    TEvent Event { get; }
}

/// <summary>
///     Represents a CSM Exception thrown by the system.
/// </summary>
/// <typeparam name="TEvent">
///     Exception scoped event enumerator.
/// </typeparam>
public abstract class BException<TEvent>
    : Exception, IException<TEvent>
    where TEvent : Enum {

    public string Advise { get; init; }

    public TEvent Event { get; init; }

    public Exception? Exception { get; init; }

    public ExceptionFeedback[] Feedback { get; init; }

    public new IDictionary<string, object?> Data { get; init; }

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="subject">
    ///     Exception subject.
    /// </param>
    /// <param name="event">
    ///     Exception trigger event.
    /// </param>
    /// <param name="exception">
    ///     Framework exception.
    /// </param>
    /// <param name="feedback">
    ///     User feedback messages.
    /// </param>
    /// <param name="data">
    ///     Operation data relevant for analysis of the exception.
    /// </param>
    public BException(string message, TEvent @event, Exception? exception = null, ExceptionFeedback[]? feedback = null, IDictionary<string, object?>? data = null)
        : base(message) {

        Event = @event;
        Exception = exception;
        Feedback = feedback ?? [];
        Data = data ?? new Dictionary<string, object?>();

        Advise = DetermineAdvise();
    }

    /// <summary>
    ///     Builds a configuration for the exception implementation, this configuration will determine what <see cref="Advise"/> to load based on the
    ///     given <see cref="Event"/> at the object construction time. 
    ///     
    ///     <para>
    ///         This is a <see langword="virtual"/> method 'cause it's optional, but it needs to be a factory method due to sometimes might Advises message contain
    ///         variable references and needs access to the stored properties.
    ///     </para>
    /// </summary>
    /// <returns></returns>
    protected virtual Dictionary<TEvent, string> BuildAdviseContext() => [];

    /// <summary>
    ///     Evaluates each advise configuration from <see cref="BuildAdviseContext"/> to determine based on the <see cref="Event"/> the advise to load.
    /// </summary>
    /// <returns>
    ///     The exception user friendly advise.
    /// </returns>
    private string DetermineAdvise() {
        Dictionary<TEvent, string> advises = BuildAdviseContext();

        string advise = Constants.Messages.DEFAULT_USER_ADVISE;
        foreach (KeyValuePair<TEvent, string> possibleAdvise in advises) {
            if (Event.Equals(possibleAdvise.Key)) {
                advise = possibleAdvise.Value;
                break;
            }
        }

        return advise;
    }
}
