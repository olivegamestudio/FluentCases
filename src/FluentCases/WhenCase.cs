namespace FluentCases;

public sealed class WhenCase<TContext>
{
    readonly TContext _context;

    internal WhenCase(TContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Asserts the context
    /// </summary>
    /// <param name="assert"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public ThenCase<TContext> Then(Action<TContext> assert)
    {
        if (assert is null)
        {
            throw new ArgumentNullException(nameof(assert));
        }

        assert(_context);
        return new ThenCase<TContext>(_context);
    }
}
