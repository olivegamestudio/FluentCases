namespace FluentCases;

public sealed class GivenCase<TContext>
{
    readonly TContext _context;
    
    internal GivenCase(TContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Arranges the context
    /// </summary>
    /// <param name="arrange"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public GivenCase<TContext> And(Action<TContext> arrange)
    {
        if (arrange is null)
        {
            throw new ArgumentNullException(nameof(arrange));
        }

        arrange(_context);
        return this;
    }
    
    /// <summary>
    /// Acts on the context
    /// </summary>
    /// <param name="act"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public WhenCase<TContext> When(Action<TContext> act)
    {
        if (act is null)
        {
            throw new ArgumentNullException(nameof(act));
        }

        act(_context);

        return new WhenCase<TContext>(_context);
    }
}
