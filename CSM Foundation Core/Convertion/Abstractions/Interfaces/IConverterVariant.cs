using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CSM_Foundation_Core.Convertion.Abstractions.Interfaces;

/// <summary>
///     Represents a <see cref="IConverter{TBase}"/> handled variant.
/// </summary>
public interface IConverterVariant {

    /// <summary>
    ///     Unique runtime variation identification for transaction convertions.
    ///     
    ///     <para> 
    ///         Additional has <see cref="JsonPropertyOrderAttribute"/> set as 0 to always be the first
    ///         property to be converted.
    ///     </para>
    /// </summary>
    [JsonPropertyOrder(0), NotMapped]
    string Discriminator { get; }
}
