namespace FluentCases;

public sealed class ThenCase<TContext>
{
    readonly TContext _context;

    internal ThenCase(TContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Asserts the context
    /// </summary>
    /// <param name="assert"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public ThenCase<TContext> And(Action<TContext> assert)
    {
        if (assert is null)
        {
            throw new ArgumentNullException(nameof(assert));
        }

        assert(_context);

        return this;
    }
}
