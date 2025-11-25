namespace CSM_Foundation_Core.Convertion.Abstractions.Interfaces;

/// <summary>
///     Represents a JSON converter.
/// </summary>
/// <typeparam name="TBase">
///     Type of the common inherited interface/class from the variants.
/// </typeparam>
public interface IConverter<TBase> {

    /// <summary>
    ///     Converter handled derived types from <typeparamref name="TBase"/>.
    /// </summary>
    public Type[] Variants { get; }
}
