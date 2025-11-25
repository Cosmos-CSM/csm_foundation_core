using CSM_Foundation_Core.Convertion.Abstractions.Interfaces;

namespace CSM_Foundation_Core.Convertion.Abstractions.Bases;

/// <inheritdoc cref="IConverterVariant"/>
public abstract class ConverterVariantBase
    : IConverterVariant {

    public string Discriminator { get; init; }

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public ConverterVariantBase() {
        Discriminator = $"{GetType().GUID}";
    }
}
