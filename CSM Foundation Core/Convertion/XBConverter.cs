using CSM_Foundation_Core.Exceptions;

namespace CSM_Foundation_Core.Convertion;

/// <summary>
///     <see cref="XBConverter"/> Exception situations enumerator.
/// </summary>
public enum XBConverterEvents {
    /// <summary>
    ///     When the <seealso cref="BConverter{T}"/> couldn't find <see cref="BConverter{T}"/> property.
    /// </summary>
    NO_DISCRIMINATOR,

    /// <summary>
    ///     When the <see cref="BConverter{T}"/> didn't find the correct variation configured based 
    ///     on the <see cref="IConverterVariation.Discriminator"/> value.
    /// </summary>
    NO_VARIATION,

    /// <summary>
    ///     When the <see cref="BConverter{TBase}.Variations"/> validations found an invalid variation.
    /// </summary>
    WRONG_VARIATIONS,
}

/// <summary>
///     [Exception] for <see cref="BConverter{TBase}"/> operations.
/// </summary>
public class XBConverter
    : BException<XBConverterEvents> {

    /// <summary>
    ///     Creates a new <see cref="XBConverter"/> instance.
    /// </summary>
    /// <param name="situation">
    ///     Exception situation.
    /// </param>
    /// 
    /// <param name="discriminator">
    ///     Discriminator when the variation convertion fails.
    /// </param>
    public XBConverter(XBConverterEvents situation, Type[]? wrongVariations = null, string discriminator = "")
        : base("CSM Converter Exception", situation) {

        wrongVariations ??= [];
        Data = new Dictionary<string, object?> {
            { nameof(discriminator), discriminator },
            { nameof(wrongVariations), wrongVariations },
        };
    }
}
