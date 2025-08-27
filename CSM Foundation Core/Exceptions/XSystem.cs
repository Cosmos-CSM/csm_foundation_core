

using CSM_Foundation_Core.Exceptions.Models;

namespace CSM_Foundation_Core.Exceptions;


/// <summary>
///     Represents exception triggering events for <see cref="XSystem"/>.
/// </summary>
public enum XSystemEvents {

    /// <summary>
    ///     The inner framework related validations triggered an exception.
    /// </summary>
    FRAMEWORK,
}

/// <summary>
///     Represents a CSM native framework exception in order to provide solutions from a basic exception management system integrated.
/// </summary>
public class XSystem
    : BException<XSystemEvents> {

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="message">
    ///     Exception description message.
    /// </param>
    /// <param name="frameworkException">
    ///     Framework native exception caught.
    /// </param>
    /// <param name="feedback">
    ///     User feedback data.
    /// </param>
    /// <param name="data">
    ///     Internal debugging exception data.
    /// </param>
    public XSystem(string message, Exception? frameworkException = null, ExceptionFeedback[]? feedback = null, IDictionary<string, object?>? data = null)
        : base(message, XSystemEvents.FRAMEWORK, frameworkException, feedback ?? [], data ?? new Dictionary<string, object?>()) {
    }
}
