namespace FluentCases;

public sealed class WhenCase<TContext>
{
    private readonly TContext _context;

    internal WhenCase(TContext context)
    {
        _context = context;
    }

    public ThenCase<TContext> Then(Action<TContext> assert)
    {
        if (assert == null)
        {
            throw new ArgumentNullException(nameof(assert));
        }

        assert(_context);

        return new ThenCase<TContext>(_context);
    }
}
