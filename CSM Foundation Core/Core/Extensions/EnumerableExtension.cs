namespace CSM_Foundation_Core.Core.Extensions;
public static class EnumerableExtension {
    public static bool Empty<T>(this IEnumerable<T> List) {
        return !List.Any();
    }
}
