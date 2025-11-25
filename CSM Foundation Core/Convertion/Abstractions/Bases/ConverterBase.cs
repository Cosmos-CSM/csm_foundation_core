using System.Text.Json;
using System.Text.Json.Serialization;

using CSM_Foundation_Core.Convertion.Abstractions.Interfaces;
using CSM_Foundation_Core.Core.Exceptions;

namespace CSM_Foundation_Core.Convertion.Abstractions.Bases;

/// <inheritdoc cref="IConverter{TBase}"/>
/// <typeparam name="TBase">
///     Type of the common inherited interface/class from the variants.
/// </typeparam>
public abstract class ConverterBase<TBase>
    : JsonConverter<TBase>, IConverter<TBase>
    where TBase : IConverterVariant {

    /// <summary>
    ///     Stores all the possible variations classes types to find the correct one.
    /// </summary>
    public Type[] Variants { get; init; }

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="variants">
    ///     Converter <typeparamref name="TBase"/> known variants.
    /// </param>
    public ConverterBase(Type[] variants) {
        Variants = variants;

        ValidateVariations();
    }

    /// <summary>
    ///     Validates if the configured <see cref="Variants"/> correctly inherit from the <typeparamref name="TBase"/>.
    /// </summary>
    /// <exception cref="ConverterBaseError">
    ///     Thrown when a wrong variation is found.
    /// </exception>
    void ValidateVariations() {
        if (Variants.Length == 0) return;

        IEnumerable<Type> wrongTypes = Variants.Where(
                (variation) => {
                    return !variation.IsAssignableTo(typeof(TBase));
                }
            );

        if (wrongTypes.Any()) {
            throw new ConverterBaseError(
                    ConverterBaseErrorEvents.WRONG_VARIANTS,
                    [.. wrongTypes]
                );
        }
    }

    public override TBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement element = document.RootElement;

        // Determine the type from the Discriminator property.
        string? discriminator;
        string discriminatorToken = nameof(IConverterVariant.Discriminator);
        try {
            discriminator = element.GetProperty(discriminatorToken).GetString();
        } catch {
            discriminator = element.GetProperty(discriminatorToken.ToLower()).GetString();
        }

        if (string.IsNullOrWhiteSpace(discriminator)) {
            throw new ConverterBaseError(ConverterBaseErrorEvents.NO_DISCRIMINATOR);
        }

        foreach (Type variation in Variants) {
            if (discriminator == variation.GetType().Name) {
                return (TBase?)element.Deserialize(variation.GetType(), options);
            }
        }

        throw new ConverterBaseError(
                ConverterBaseErrorEvents.NO_VARIATION,
                discriminator: discriminator
            );
    }

    public override void Write(Utf8JsonWriter writer, TBase value, JsonSerializerOptions options) {
        foreach (Type variation in Variants) {

            if (value.GetType().GUID == variation.GUID) {
                JsonSerializer.Serialize(writer, variation, options);
            }
        }

        throw new ConverterBaseError(ConverterBaseErrorEvents.NO_VARIATION);
    }
}
