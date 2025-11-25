namespace CSM_Foundation_Core.Abstractions.Interfaces;

/// <summary>
///     Represents a disposition manager wich stores objects in their context to be disposed at the end of a process.
/// </summary>
/// <typeparam name="TObject">
///     Type of the object being handled.
/// </typeparam>
/// <remarks>
///     Data Disposition managers are used for custom and specific use-cases where operations add data to the context databases
///     that is not necessary needed to preserve, this managers stores and groups that data to be disposed by their each own database context.
/// </remarks>
public interface IDisposer<TObject> {

    /// <summary>
    ///     Pushes the given <paramref name="object"/> into the Data Disposition tracker.
    /// </summary>
    /// <param name="object">
    ///     Instance to dispose.
    /// </param>
    void Push(TObject @object);

    /// <summary>
    ///     Pushes the given <paramref name="objects"/> into the Data Disposition tracker.
    /// </summary>
    /// <param name="objects">
    ///     Instances to dispose.
    /// </param>
    void Push(TObject[] objects);

    /// <summary>
    ///     Invokes the Data Disposition Stack to perform the Disposition operation, gathering the required database contexts and
    ///     removing tracked data.
    /// </summary>
    void Dispose();
}
