using CSM_Foundation_Core.Convertion.Abstractions.Bases;
using CSM_Foundation_Core.Convertion.Abstractions.Interfaces;
using CSM_Foundation_Core.Errors.Abstractions.Bases;

namespace CSM_Foundation_Core.Core.Exceptions;

/// <summary>
///     <see cref="ConverterBaseError"/> Exception situations enumerator.
/// </summary>
public enum ConverterBaseErrorEvents {
    /// <summary>
    ///     When the <seealso cref="ConverterBase{T}"/> couldn't find <see cref="ConverterBase{T}"/> property.
    /// </summary>
    NO_DISCRIMINATOR,

    /// <summary>
    ///     When the <see cref="ConverterBase{T}"/> didn't find the correct variation configured based 
    ///     on the <see cref="IConverterVariant.Discriminator"/> value.
    /// </summary>
    NO_VARIATION,

    /// <summary>
    ///     When the <see cref="ConverterBase{TBase}.Variants"/> validations found an invalid variation.
    /// </summary>
    WRONG_VARIANTS,
}

/// <summary>
///     [Exception] for <see cref="ConverterBase{TBase}"/> operations.
/// </summary>
public class ConverterBaseError
    : ErrorBase<ConverterBaseErrorEvents> {

    /// <summary>
    ///     Creates a new <see cref="ConverterBaseError"/> instance.
    /// </summary>
    /// <param name="situation">
    ///     Exception situation.
    /// </param>
    /// 
    /// <param name="discriminator">
    ///     Discriminator when the variation convertion fails.
    /// </param>
    public ConverterBaseError(ConverterBaseErrorEvents situation, Type[]? wrongVariations = null, string discriminator = "")
        : base("CSM Converter Exception", situation) {

        wrongVariations ??= [];
        Data = new Dictionary<string, object?> {
            { nameof(discriminator), discriminator },
            { nameof(wrongVariations), wrongVariations },
        };
    }
}
