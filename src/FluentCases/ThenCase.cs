namespace FluentCases;

public sealed class ThenCase<TContext>
{
    private readonly TContext _context;

    internal ThenCase(TContext context)
    {
        _context = context;
    }

    public ThenCase<TContext> And(Action<TContext> assert)
    {
        if (assert == null)
        {
            throw new ArgumentNullException(nameof(assert));
        }

        assert(_context);

        return this;
    }
}
