using System;

namespace Transformers;

public class NullableStructsTransformer
{
    public static TResult? Transform<TSource, TResult>(
        TSource? source,
        Func<TSource, TResult> transformation)
        => source is null
            ? default
            : transformation(source);

    
    public static TResult? Transform<TSource, TResult>(
        TSource? source,
        Func<TSource, TResult> transformation)
        where TSource : struct
    {
        if (source is null)
        {
            return default;
        }
        else
        {
            return transformation(source.Value);
        }
    }

    public static TResult? TransformFixed<TSource, TResult>(
        TSource? source,
        Func<TSource, TResult> transformation)
        where TSource : struct
        where TResult : struct
        => source is null
            ? default(TResult?)
            : transformation(source.Value);        
}

